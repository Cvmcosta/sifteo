#include <Servo.h> 
#include <IRremote.h>
 
Servo myservo1;
Servo myservo2;
int RECV_PIN = 11;
const int led1 = 2;
const int led2 = 3;
IRrecv irrecv(RECV_PIN);
decode_results results; 
                
int go = 0 ;
 
void setup() 
{ 
  pinMode(led1,OUTPUT);
  pinMode(led2,OUTPUT);
  myservo1.attach(9);
  myservo2.attach(10);
  myservo1.write(go);
  myservo2.write(go);
  irrecv.enableIRIn();
} 
 
void loop() 
{ 
  digitalWrite(led1,HIGH);
  digitalWrite(led2,HIGH);
  if (irrecv.decode(&results)) {
    switch(results.value){
      case 0xE17A807F: go = 90; break;
      case 0xE17A40BF: go = 179; break;
      case 0xE17AC03F: go = 0; break; 
    }
    irrecv.resume(); 
  }
   myservo1.write(go);
   myservo2.write(go);              
   delay(15);                      

} 

