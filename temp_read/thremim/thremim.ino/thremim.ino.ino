int ValorSensor = 0;
int nota = 0;
const int Buzzer = 5;
const int sensor = 0;
void setup(){
}
void loop(){
ValorSensor = analogRead(sensor);
nota = map(ValorSensor, 1023, 0, 1000, 6000);
tone(Buzzer, nota, 20);
delay(10);
}
