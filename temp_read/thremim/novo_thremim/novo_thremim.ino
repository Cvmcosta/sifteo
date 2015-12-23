int ValorSensor = 0;
int nota = 0;
const int Buzzer = 5;
const int sensor = 0;
const int b2 = 11;
const int b1 = 12;
int estadob1 = 0;
int estadob2 = 0;
void setup(){
  pinMode(b1,INPUT);
  pinMode(b2,INPUT);
}
void loop(){
estadob1 = digitalRead(b1);
estadob2 = digitalRead(b2);
ValorSensor = analogRead(sensor);
if (ValorSensor > 70 && estadob1 == LOW && estadob2 == LOW){
 nota = 261 ; 
}

if (ValorSensor > 70 && estadob1 == HIGH && estadob2 == LOW){
 nota = 294 ; 
}

if (ValorSensor > 70 && estadob1 == LOW && estadob2 == HIGH){
 nota = 329 ; 
}

if (ValorSensor < 70 &&estadob1 == LOW && estadob2 == LOW){
  nota = 349 ;
}


if (ValorSensor < 70 &&estadob1 == HIGH && estadob2 == LOW){
  nota = 392 ;
}

if (ValorSensor < 70 && estadob1 == LOW && estadob2 == HIGH){
  nota = 440 ;
}
tone(Buzzer, nota, 200);
delay(10);
}
