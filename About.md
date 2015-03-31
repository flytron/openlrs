# About #

OpenLRS is an open source RC receiver/transmitter module that configurable for any channel (400-460mhz) or any protocol or extra features as telemetry.

Rx/Tx modules including 100mW RFM22B RF unit and Atmega328 processor with Arduino Bootloader.
You can upload our codes or write your own.

<b>Frequency Hopping or What You Want</b>

Our original code does 3 channel frequency hopping (not FHSS, FH only) for reducing the risks.  Standard refresh rate is same with your transmitter (50hz), if one of channels disables by an external source refresh rate reducing to %66 (33hz) , if you lose 2 of 3 channels you can still fly with %33 (15hz) refresh rate.
If you do not like it, you can write your own hopping codes or just use 1 solid channel.

<b>3.3v I2C for All Digital Sensors</b>

The receiver includes an 3.3v I2C port for all sensor boards on the market. You can plug our BMP085 board and you got an altimeter or variometer. You can measure the G forces with an accelerometer or stabilize your plane with a gyroscope sensor.

<b>Serial or Parallel PPM selectable</b>

If you are using an autopilot/multicopter controller with serial PPM. You dont need any firmware change. Just plug a jumper (binding plugs of 2.4ghz receivers) between channel 1 and 3's signal outputs. OpenLRS Rx detects the jumper when startup and gives 2 short blink. This mean it's giving serial PPM signal from 8th channel.

<b>You dont need external multicopter controllers or autopilots</b>

OpenLRS Rx module, including serial and I2C ports for your future projects. Just include a WiiMotionPlus and upload your code for making a basic quadrocopter. Add a Wii Nunchuck and you have 6DOF IMU. or just buy a 9DOF IMU and connect. Our 3.3v I2C port compatible with all of modern I2C sensors. You can connect your GPS or other Serial equipments with serial port.

<b>Telemetry</b>

OpenLRS Rx/Tx modules is including a Tranceiver, that's mean, you can use it as a transmitter or a telemetry transmitter. Just imagine, you can follow your plane's voltage levels or sensors of your quadrocopter. And you can change the configuration by your PC.

<b>You can use your Receiver as a Transmitter</b>

If you dont need the Futaba Tx module's advantages, you dont need our M1 modules too. Just order 2 receivers and update the one of them as a transmitter. Because M1 module and Rx modules using same RF modules (RFM22B) . Only you should change the pinouts of transmitter code. (I will share a code about that in a few days)

<b>Product Pages for Order</b>

http://www.flytron.com/16-openlrs