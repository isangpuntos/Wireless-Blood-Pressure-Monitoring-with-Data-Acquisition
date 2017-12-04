#include <SoftwareSerial.h>

#define rxPin 2
#define txPin 3
SoftwareSerial mySerial =  SoftwareSerial(rxPin, txPin);

int error_flag=0;
int systolic;
int diastolic;
int pressure=0;
int array_pressure[250];
int MAP;
int f = 0;
int j = 0;
int i = 0;
int k = 0;
int inflate_indicator = 0;
int ignore_counter = 0;
unsigned long inflate_time = 0;
unsigned long time = 0;
unsigned long previous_time = 0;
unsigned long clear_previous_time = 0;
unsigned long ignore_time = 0;
unsigned long prev_millis = 0;
unsigned long LCD_timer=0;
unsigned long check_timer=0;
float array_voltage[250];
float aval;
float voltage1 = 0;
float voltage0 = 0;
float high = 1.75;
float prev_voltage=2;
char indicator = 'q';

void setup()
{
pinMode(rxPin, INPUT);
pinMode(txPin, OUTPUT);
Serial.begin(57600);
mySerial.begin(9600);
pinMode(4,OUTPUT);
pinMode(5,OUTPUT);
pinMode(6,INPUT);
pinMode(7,INPUT);
pinMode(8,INPUT);
Serial.print("r\n");
mySerial.print("\033E");
mySerial.print("\033E");
mySerial.println(" WBPMS Ver 1.0");
}

void inflate_cuff()
{
 inflate_time = millis();
 pressure = map(analogRead(0),38,1013,0,400);
  while(pressure<190)
  {
    time=millis();
   if(pressure<30&&time-inflate_time>10000)
   {
   error_flag=1;
   Serial.print("rrrrrrrrrrrrrrrr\n");
   pressure=0;
   break;
   }
   pressure = map(analogRead(0),38,1013,0,400);
   voltage1 = analogRead(1)*5.0;
   voltage1 /= 1023.0;
   digitalWrite(4,HIGH);
   digitalWrite(5,HIGH);
   mySerial.println("Inflating...");
   mySerial.print(pressure);
   delay(100);
   mySerial.print("\033E");
   
 }
 time=0;
}

void deflate_cuff()
{
  digitalWrite(4,LOW); 
  delay(500);
    Serial.print("s\n");
    delay(500);
    Serial.print("s\n");
  //--------------------------------------------------------------  
 clear_previous_time = ignore_time = previous_time = millis();
  while(pressure>50)
  { 
     time = millis();
     //-------------------------------------------------------
     if((time-clear_previous_time)>200)
     {       
       mySerial.print("\033E");
       mySerial.println("Deflating...");
       mySerial.print(pressure);
       clear_previous_time = time;
     } 
     //-------------------------------------------------------
      if((time-ignore_time)>10&&i<250)
      {
         aval = analogRead(0);
         pressure = map(aval,38,1013,0,400);
         voltage1 = analogRead(1)*5.0;
         voltage1 /= 1023.0;
         voltage0 = aval*5.0;
         voltage0 /= 1023.0;
       
        if(voltage1>0&&voltage1<1.75)
         {
           ignore_counter++;
           if(ignore_counter>=95)
           {
           if(k<20)
           {  
            i = 0; 
            k=0;
            }
           }
         }
         
         if(voltage1>=1.75)
         {    
         ignore_counter=0;
          if(voltage1>high)
          {
            high = voltage1;
            MAP = pressure;
            array_pressure[i] = pressure;
            array_voltage[i] = voltage1;
            i++;
          } 
          k++;
       }
      
       Serial.print(voltage1);
          Serial.print("\n");
       ignore_time = time;
      }
     //-------------------------------------------------------  
     if((time-previous_time) > 1000 && f == 0)
     {
       digitalWrite(5,LOW);
       f = 1;
       previous_time = time;
     }
     //-------------------------------------------------------
     if((time-previous_time) > 40 && f == 1)
     {
       digitalWrite(5,HIGH);
       f = 0;
       previous_time = time;
     }
     //--------------------------------------------------------
 }
   //------------------------------------------------------------
   for(j = 0; j<i; j++)
    {
      if(array_voltage[j]/high>=0.80)
      {
       if(systolic == 0)
        systolic = array_pressure[j];
      }   
    } 
    diastolic = 1.5*(MAP - systolic/3.0);
   if(systolic<diastolic||systolic-diastolic>79||systolic-diastolic<10)
   {
     error_flag=1;
   Serial.print("rrrrrrrrrrrrrrrr\n");
   }
  if(error_flag==0)
  {
    digitalWrite(5,LOW);
    mySerial.print("\033E");
    delay(1000);
    Serial.print(systolic);
    Serial.print(":");
    Serial.print(diastolic);
    Serial.print("\n");
  }
  
 while(1)
 {
   if (error_flag==0)
   {
   mySerial.print("Sys/Dia:  Con:");
   mySerial.println("");
   mySerial.print(systolic);
   mySerial.print("/");
   mySerial.print(diastolic);

   if(systolic>139&&systolic<=159||diastolic<=99&&diastolic>89)
   {
   mySerial.print("      S1");
   }
   else if(systolic>159&&systolic<=179||diastolic>99&&diastolic<109)
   {
   mySerial.print("      S2");
   }
   else if(systolic>179&&systolic<=209||diastolic>109&&diastolic<=119)
   {
   mySerial.print("      S3");
   }
   else if(systolic<91||diastolic<61)
   {
   mySerial.print("      LB");
   }
   else if(systolic>91&&systolic<=139||diastolic>70&&diastolic<=89)
   {
   mySerial.print("      N");
   }
   delay(10000);
   mySerial.print("\033E");
  }
 
  else if (error_flag==1)
  {
  mySerial.print("\033E");
  mySerial.print("Invalid reading\n");
  
  digitalWrite(5,LOW);
  delay(10000);
  }
 }
}

void loop()
{ 
 char conn_check;
 LCD_timer = millis();
 digitalWrite(7,LOW);
   
 if(digitalRead(6)==LOW&&digitalRead(7)==LOW)
 {
   if(LCD_timer - prev_millis>499)
   {
     mySerial.print("\033E");
     mySerial.println(" WBPMS Ver 1.0");
     prev_millis = LCD_timer;
   }
 }
 else if(digitalRead(6)==HIGH&&digitalRead(7)==LOW&&indicator=='c')
 {
 inflate_cuff();
 deflate_cuff();
 }
 else if(digitalRead(6)==LOW&&digitalRead(7)==HIGH)
 {
   delay(1000);
 Serial.print("c\n");
  
  if(Serial.available()>0&&check_timer<1000)
   {
    indicator = Serial.read();
    if(indicator=='c') 
    {
      mySerial.print("\033E");
      mySerial.println("Connection OK");
      delay(1000);
    }  
   }
 }
}