
#include <Servo.h> 
#include <IRremote.h>
 
Servo myservo;
int RECV_PIN = 11;
IRrecv irrecv(RECV_PIN);
decode_results results; 
                
int pos = 0; 
int go = 0 ;
 
void setup() 
{ 
  myservo.attach(9);
  myservo.write(pos);
  irrecv.enableIRIn();
} 
 
void loop()
{
    if (irrecv.decode(&results)) {
      switch(results.value){
        case 0xE17A807F: go = 90; break;
        case 0xE17A40BF: go = 179; break;
        case 0xE17AC03F: go = 0; break;
      }
      irrecv.resume();
    }
      myservo.write(go);             
      delay(15);                     
}
