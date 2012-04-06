// **********************************************************
// **                   OpenLRS Functions                  **
// **       This Source code licensed under GPL            **
// **********************************************************
// Latest Code Update : 2012-02-14
// Supported Hardware : OpenLRS Tx boards (M1 & M2) (store.flytron.com)
// Project Forum      : http://forum.flytron.com/viewforum.php?f=7
// Google Code Page   : http://code.google.com/p/openlrs/
// **********************************************************

//############# RED LED BLINK #################
void Red_LED_Blink(unsigned short blink_count)
  {
  unsigned char i;
  for (i=0;i<blink_count;i++)
     {
     delay(100);
     Red_LED_ON;
     delay(100);
     Red_LED_OFF;
     }
  }
  
//############# GREEN LED BLINK #################
void Green_LED_Blink(unsigned short blink_count)
  {
  unsigned char i;
  for (i=0;i<blink_count;i++)
     {
     delay(100);
     Green_LED_ON;
     delay(100);
     Green_LED_OFF;
     }
  }  

//############# FREQUENCY HOPPING #################
#if (FREQUENCY_HOPPING==1)
void Hopping(void){

hopping_channel++;
if (hopping_channel>2) hopping_channel = 0;

_spi_write(0x79, hop_list[hopping_channel]);

    #if (DEBUG_MODE == 5)
      Serial.println(int(hop_list[hopping_channel]));
    #endif  

}
#endif

//############# RF POWER SETUP #################
void Power_Set(unsigned short level)
{
  //Power Level value between 0-7
  //0 = +1 dBm
  //1 = +2 dBm
  //2 = +5 dBm
  //3 = +8 dBm
  //4 = +11 dBm
  //5 = +14 dBm
  //6 = +17 dBm
  //7 = +20 dB 
  if (level<8) _spi_write(0x6d, level);  
  
}

//############# BUTTON CHECK #################
void Check_Button(void)
{
unsigned long loop_time;
byte btn_mode = 0;

 if (digitalRead(BTN)==0) // Check the button
    {
    delay(1000); // wait for 1000mS when buzzer ON 
    digitalWrite(BUZZER,LOW); // Buzzer off
    
    time = millis();  //set the current time
    loop_time = time; 
    
    while (digitalRead(BTN)==0) // wait for button reelase if it is already pressed.
        {
         loop_time = millis();
         
         if (loop_time > time + 1000)
            {
            time = millis();
            btn_mode++;
            digitalWrite(BUZZER,HIGH);
            delay(100);
            digitalWrite(BUZZER,LOW);
            }
           
          }     


    if (btn_mode == 0) //If you release the button when you hearing first long beep 
        Power_Set(6); //set the booster output power +17dbm
    
    if (btn_mode == 3) //If you release the button when you hearing 3th short beep 
        Power_Set(0); //set the minimum output power +1dbm  for range test 
        
    delay(500); 
    digitalWrite(BUZZER,HIGH);
    delay(500); 
    digitalWrite(BUZZER,LOW);  
    }
  
  
}

//############# BINDING #################
void Binding_Mode(unsigned int btn_press_time)
{
 
 //randomSeed(analogRead(7)); //use empty analog pin as random value seeder.
 //randNumber = random(300);
 
 //we will write this part soon
 
  
}



void SetServoPos (unsigned char channel,int value)
{
  unsigned char ch = channel*2;
  Servo_Buffer[ch] = value/256;
  Servo_Buffer[ch+1] = value%256;
}

// STARWARS IMPERIAL MARCH :)))
void march_beep ( int frequencyInHertz, long timeInMilliseconds)
{ 
    digitalWrite(Red_LED, HIGH);	 
    //use led to visualize the notes being played
    
    int x; 	 
    long delayAmount = (long)(1000000/frequencyInHertz);
    long loopTime = (long)((timeInMilliseconds*1000)/(delayAmount*2));
    for (x=0;x<loopTime;x++) 	 
    { 	 
        digitalWrite(BUZZER,HIGH);
        delayMicroseconds(delayAmount);
        digitalWrite(BUZZER,LOW);
        delayMicroseconds(delayAmount);
    } 	 
    
    digitalWrite(Red_LED, LOW);
    //set led back to low
    
    delay(20);
    //a little delay to make all notes sound separate
} 	 
  	 
void march()
{ 	 
    //Based from http://www.youtube.com/watch?gl=AU&hl=en-GB&v=uLPGTMISJIY
    #define c 261
    #define d 294
    #define e 329
    #define f 349
    #define g 391
    #define gS 415
    #define a 440
    #define aS 455
    #define b 466
    #define cH 523
    #define cSH 554
    #define dH 587
    #define dSH 622
    #define eH 659
    #define fH 698
    #define fSH 740
    #define gH 784
    #define gSH 830
    #define aH 880
        
    march_beep(a, 500); 
    march_beep(a, 500);     
    march_beep(a, 500); 
    march_beep(f, 350); 
    march_beep(cH, 150);
    
    march_beep(a, 500);
    march_beep(f, 350);
    march_beep(cH, 150);
    march_beep(a, 1000);
    //first bit
    
    march_beep(eH, 500);
    march_beep(eH, 500);
    march_beep(eH, 500);    
    march_beep(fH, 350); 
    march_beep(cH, 150);
    
    march_beep(gS, 500);
    march_beep(f, 350);
    march_beep(cH, 150);
    march_beep(a, 1000);
    //second bit...
    
    march_beep(aH, 500);
    march_beep(a, 350); 
    march_beep(a, 150);
    march_beep(aH, 500);
    march_beep(gSH, 250); 
    march_beep(gH, 250);
    
    march_beep(fSH, 125);
    march_beep(fH, 125);    
    march_beep(fSH, 250);
    delay(250);
    march_beep(aS, 250);    
    march_beep(dSH, 500);  
    march_beep(dH, 250);  
    march_beep(cSH, 250);  
    //start of the interesting bit
    
    march_beep(cH, 125);  
    march_beep(b, 125);  
    march_beep(cH, 250);      
    delay(250);
    march_beep(f, 125);  
    march_beep(gS, 500);  
    march_beep(f, 375);  
    march_beep(a, 125); 
    
    march_beep(cH, 500); 
    march_beep(a, 375);  
    march_beep(cH, 125); 
    march_beep(eH, 1000); 
    //more interesting stuff (this doesn't quite get it right somehow)
    
    march_beep(aH, 500);
    march_beep(a, 350); 
    march_beep(a, 150);
    march_beep(aH, 500);
    march_beep(gSH, 250); 
    march_beep(gH, 250);
    
    march_beep(fSH, 125);
    march_beep(fH, 125);    
    march_beep(fSH, 250);
    delay(250);
    march_beep(aS, 250);    
    march_beep(dSH, 500);  
    march_beep(dH, 250);  
    march_beep(cSH, 250);  
    //repeat... repeat
    
    march_beep(cH, 125);  
    march_beep(b, 125);  
    march_beep(cH, 250);      
    delay(250);
    march_beep(f, 250);  
    march_beep(gS, 500);  
    march_beep(f, 375);  
    march_beep(cH, 125); 
           
    march_beep(a, 500);            
    march_beep(f, 375);            
    march_beep(c, 125);            
    march_beep(a, 1000);       
    //and we're done \ó/    
}


void Plane_Hit(void)
{
  
 digitalWrite(BUZZER,HIGH);
 //hit_counter++;
 
}
