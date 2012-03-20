// **********************************************************
// ******************   OpenLRS Tx Code   *******************
// ***  OpenLRS Designed by Melih Karakelle on 2010-2011  ***
// **  an Arudino based RC Rx/Tx system with extra futures **
// **       This Source code licensed under GPL            **
// **********************************************************
// Version Number     : 1.12
// Latest Code Update : 2012-02-14
// Supported Hardware : OpenLRS Tx boards (M1 & M2) (store.flytron.com)
// Project Forum      : http://forum.flytron.com/viewforum.php?f=7
// Google Code Page   : http://code.google.com/p/openlrs/
// **********************************************************

// ******************** OpenLRS DEVELOPERS ****************** 
// Melih Karakelle (http://www.flytron.com) (forum nick name: Flytron)
// Jan-Dirk Schuitemaker (http://www.schuitemaker.org/) (forum nick name: CrashingDutchman)
// Etienne Saint-Paul (http://www.gameseed.fr) (forum nick name: Etienne) 
// thUndead (forum nick name: thUndead) 


// ******************** BUTTON BASED CONFIGURATIONS *********************
// 
// If you want to temporary configure your Tx's output power on the field for booster usage(17dbm) or range test(1dbm) use the button of Tx module.
// It is wery simple procedure
// 1- Press the button when Tx off and hold
// 2- Power On your Tx
// 3- You will hear long(1 seconds) beep
// 4- Then tx module will beep(short) every seconds. 
// 5- Count the short beeps. 
// 6- If you release the button after first short beep, your Tx will work on 17dbm mode, you can use your tx with our 7W booster on this mode.
// 7- If you release the button after third short beep, your Tx will work on 1dbm mode, it is minimum output power of your Tx for range test. The range must be arround 40-100 meter in this mode.
// 8- you will hear another long beep after release the button, this mean the configuration done. 
// 9- If you want to turn back to default 20dbm mode, just trun off your tx and on again. 

#include "config.h"

#include <EEPROM.h>



void setup() {   
       
        //LED and other interfaces
        pinMode(Red_LED, OUTPUT); //RED LED
        pinMode(Green_LED, OUTPUT); //GREEN LED
        pinMode(BUZZER, OUTPUT); //Buzzer
        pinMode(BTN, INPUT); //Buton
        
        //EEPROM check and update
        eeprom_check(); //uncomment this line for changing the frequency/hopping channels/deviceID and other important varibles by PC software
        
        //RF module pins
        pinMode(SDO_pin, INPUT); //SDO
        pinMode(SDI_pin, OUTPUT); //SDI        
	pinMode(SCLK_pin, OUTPUT); //SCLK
        pinMode(IRQ_pin, INPUT); //IRQ
        pinMode(nSel_pin, OUTPUT); //nSEL
        
           
        pinMode(PPM_IN, INPUT); //PPM from TX 
        pinMode(RF_OUT_INDICATOR, OUTPUT);
        
        Serial.begin(SERIAL_BAUD_RATE);
        
        
       #if (CONTROL_TYPE == 0)
         PPM_Pin_Interrupt_Setup // turnon pinchange interrupts
       #endif
       
      
       for (unsigned char i=0;i<8;i++) // set defoult servo position values.
          SetServoPos(i,3000); // set the center position

         TCCR1B   =   0x00;   //stop timer
         TCNT1H   =   0x00;   //setup
         TCNT1L   =   0x00;
         ICR1     =   60005;   // used for TOP, makes for 50 hz
         TCCR1A   =   0x02;   
         TCCR1B   =   0x1A; //start timer with 1/8 prescaler for measuring 0.5us PPM resolution
}


#if (CONTROL_TYPE == 0) 
//##### PPM INPUT INTERRUPT #####
//Port change interrupt detects the PPM signal's rising edge and calculates the signal timing from Timer1's value.
	
ISR(PPM_Signal_Interrupt){

unsigned int time_temp;
unsigned int servo_temp;
unsigned int servo_temp2;

if (PPM_Signal_Edge_Check) // Only works with rising edge of the signal
		    {
			time_temp = TCNT1; // read the timer1 value
                        TCNT1 = 0; // reset the timer1 value for next
			if (channel_no<19) channel_no++; 
                        
					
			if (time_temp > 8000) // new frame detection : >4ms LOW
				{	
				channel_count = channel_no;
				channel_no = 0;
				transmitted = 0;                               
				}
                                else
                                {
                                if ((time_temp>1500) && (time_temp<4500)) // check the signal time and update the channel if it is between 750us-2250us
                                  {
                                  Servo_Buffer[channel_no] =  time_temp; // write the low byte of the value into the servo value buffer.                                    
                                  }
                               }
			}

}
#endif 

//############ MAIN LOOP ##############
void loop() {
  
unsigned char i;

//wdt_enable(WDTO_1S);

RF22B_init_parameter(); 
frequency_configurator(CARRIER_FREQUENCY); // Calibrate the RF module for this frequency, frequency hopping starts from this frequency.

Power_Set(7); // 100mW maximum RF output power

sei();

//march();  //Enable for StarWars Imperial March :)

digitalWrite(BUZZER, HIGH);
digitalWrite(BTN, HIGH);
Red_LED_ON ;
delay(100);	


Check_Button(); // Output power selection on startup. 

Red_LED_OFF;
digitalWrite(BUZZER, LOW);

digitalWrite(RF_OUT_INDICATOR,LOW);
digitalWrite(PPM_IN,HIGH);

transmitted = 0;
rx_reset;
	
time = millis();
old_time = time;

while(1)

              {    /* MAIN LOOP */	              
              time = millis();  
              if (_spi_read(0x0C)==0) // detect the locked module and reboot
                 {
                 Red_LED_ON;  
                 RF22B_init_parameter();
                 frequency_configurator(CARRIER_FREQUENCY);
                 rx_reset;
                 Red_LED_OFF;
                 }
              
              #if (CONTROL_TYPE==1)
              if (Serial.available()>3)    // Serial command received from the PC
                        {
                          int cmd = Serial.read();
                          if (cmd=='S')            // Command 'S'+ channel number(1 bytes) + position (2 bytes)
                          {
                            Red_LED_ON;
                            int ch = Serial.read();
                            Servo_Buffer[ch] = (Serial.read()*256 )+ Serial.read();
                            Red_LED_OFF;
                          }
                        }
              #endif       


              #if (TELEMETRY_ENABLED==1)
        
               if (nIRQ_0)
                 {
                  Red_LED_ON;  
                  send_read_address(0x7f); // Send the package read command
		  for(i = 0; i<RF_PACK_SIZE; i++) //read all buffer 
			{ 
			 RF_Rx_Buffer[i] = read_8bit_data(); 
			}  
		  rx_reset(); 
                  
                  #if (TELEMETRY_MODE == 1)  // OpenLRS Standard Telemetry mode                
                      #if (Rx_RSSI_Alert_Level>0) 
                        Tx_RSSI = ((Tx_RSSI/5)*4) + (_spi_read(0x26)/5); // Read the RSSI value
                      #endif
                      #if (Rx_RSSI_Alert_Level>0) 
                        Rx_RSSI = ((Rx_RSSI/5)*4) + (RF_Rx_Buffer[1]/5); // Rx Rssi value from telemetry data
                      #endif
                      if ((Rx_RSSI < Rx_RSSI_Alert_Level)||(Tx_RSSI < Tx_RSSI_Alert_Level)) // RSSI level alerts
                         digitalWrite(BUZZER, HIGH);
                         else
                         digitalWrite(BUZZER, LOW);
                      #if (TELEMETRY_OUTPUT_ENABLED==1)
                        for(i = 0; i<RF_PACK_SIZE; i++) //write serial
                           Serial.print(RF_Rx_Buffer[i]);
                        Serial.println();
                      #endif                  
                   #endif
                   
                   #if (TELEMETRY_MODE == 0)  // Transparent Bridge Telemetry mode                
                      #if (TELEMETRY_OUTPUT_ENABLED==1)
                        if (RF_Rx_Buffer[0]=='B') // Brige values
                           {
                             for(i = 2; i<RF_Rx_Buffer[1]+2; i++) //write serial
                              Serial.print(RF_Rx_Buffer[i]);
                           }   
                      #endif                  
                   #endif
                   
                   #if (TELEMETRY_MODE == 2)  // WarBird Mode               
                      if (RF_Rx_Buffer[0]=='W') 
                         if (RF_Rx_Buffer[1]=='H') // Hit
                           Plane_Hit();
                           else
                           digitalWrite(BUZZER,LOW);   
                   #endif
                   
                  
                  Red_LED_OFF;
                  Rx_Pack_Received = 0;
                 }	    
	      #endif

              

              #if (CONTROL_TYPE == 0)
              if ((transmitted==0) && (channel_count>3) && (channel_count<13))
              #else              
              if (time> old_time+20) // Automatic 50hz position transmit code for PC based serial control applications
              #endif        
                       {
                      old_time = time; 
		      //Green LED will be on during transmission  
	              Green_LED_ON ;


                      #if (TELEMETRY_MODE == 0) // Transparent Brige ground to air code
                          
                          byte total_rx_byte = Serial.available();  // Read the Serial RX buffer size
                          if (total_rx_byte>0)
                              {
                               RF_Tx_Buffer[0] = 'B';
                               if (total_rx_byte>RF_PACK_SIZE-2) total_rx_byte = RF_PACK_SIZE-2; // Limit the package size as RF_PACK_SIZE-2 = (38) byte
                               RF_Tx_Buffer[1]= total_rx_byte;
                               for (byte i=0;i<total_rx_byte;i++)
                                    RF_Tx_Buffer[2+i] = Serial.read();
                              }
                           else   
                       #endif  
                       
                      {
                      //"S" header for Servo Channel data
                      RF_Tx_Buffer[0] = 'S';
		      for(i = 0; i<RC_CHANNEL_COUNT; i++) // fill the rf-tx buffer with 18 channel (2x18 byte) servo signal
		          {
                          RF_Tx_Buffer[(i*2)+1] = Servo_Buffer[i+1] / 256;
                          RF_Tx_Buffer[(i*2)+2] = Servo_Buffer[i+1] % 256;
                          //Serial.print(" ");
                          //Serial.print(Servo_Buffer[i+1]);
			  }
                      //Serial.println();
                      }
                      
                     
                      	
                      #if (TELEMETRY_MODE == 2) // WARBIRD Mode , gun sound
                      if (Servo_Buffer[7]>3000) digitalWrite(BUZZER, HIGH);                      
                      #endif 

                      // Send the data over RF
    		      to_tx_mode();
    		      transmitted = 1;
    
                      #if (TELEMETRY_MODE == 2) // WARBIRD Mode , gun sound off
                      digitalWrite(BUZZER, LOW);                      
                      #endif 
    	              
                      //Green LED will be OFF
                      Green_LED_OFF; 
  
                      //Hop to the next frequency
                      #if (FREQUENCY_HOPPING==1)
                         Hopping();
                      #endif   
                      
                      
                      
                      #if (TELEMETRY_ENABLED==1) //Receiver mode enabled for the telemetry
                        rx_reset(); 
                        #if (Lost_Package_Alert != 0) // Lost Package Alert 
                          if (Rx_Pack_Received < Lost_Package_Alert) // last Rx packs didnt received
                              digitalWrite(BUZZER, LOW);
                              else
                              digitalWrite(BUZZER, HIGH);
                        #endif    
                        Rx_Pack_Received++;
                      #endif
                      
                      #if (DEBUG_MODE == 1)
                         if (time%100 < 10)
                         {
                           for(i = 0; i<RC_CHANNEL_COUNT; i++) // fill the rf-tx buffer with 8 channel (2x8 byte) servo signal
		             {
                             Serial.print(int( (Servo_Buffer[(2*i)]*256) + Servo_Buffer[1+(2*i)]));
                             Serial.print(' ');
			     }
                          Serial.println(' ');
                         }
                      #endif  
			  
	              }
		}
		 
}


