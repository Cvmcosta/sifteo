const int LM35 = 0;
float temperatura = 0;
int ADClido = 0;
const int Buzzer = 12;
const int LED[] = {
11,10,9,8,7,6,5,4,3,2};
void setup(){
analogReference(INTERNAL);
pinMode(Buzzer, OUTPUT);
for(int x = 0; x < 10; x++){
pinMode(LED[x], OUTPUT);
}
Serial.begin(9600);
}
void loop(){
ADClido = analogRead(LM35);
temperatura = ADClido * 0.1075268817204301;
Serial.print("Temperatura = ");
Serial.print(temperatura);
Serial.println(" *C");
if(temperatura > 30.50){
digitalWrite(LED[0], HIGH);
}
else{
digitalWrite(LED[0], LOW);
}
if(temperatura > 31.00){
digitalWrite(LED[1], HIGH);
}
else{
digitalWrite(LED[1], LOW);
}
if(temperatura > 31.50){
digitalWrite(LED[2], HIGH);
}
else{
digitalWrite(LED[2], LOW);
}
if(temperatura > 32.00){
digitalWrite(LED[3], HIGH);
}
else{
digitalWrite(LED[3], LOW);
}
if(temperatura > 32.50){
digitalWrite(LED[4], HIGH);
}
else{
digitalWrite(LED[4], LOW);
}
if(temperatura > 33.00){
digitalWrite(LED[5], HIGH);
}
else{
digitalWrite(LED[5], LOW);
}
if(temperatura > 33.50){
digitalWrite(LED[6], HIGH);
}
else{
digitalWrite(LED[6], LOW);
}
if(temperatura > 34.00){
digitalWrite(LED[7], HIGH);
}
else{
digitalWrite(LED[7], LOW);
}
if(temperatura > 34.50){
digitalWrite(LED[8], HIGH);
}
else{
digitalWrite(LED[8], LOW);
}
if(temperatura > 35.00){
digitalWrite(LED[9], HIGH);
digitalWrite(Buzzer,HIGH);
}
else{
digitalWrite(LED[9], LOW);
digitalWrite(Buzzer,LOW);
}
}
