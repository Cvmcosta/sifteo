const int LDR = 0;
const int Led = 6;
int ValorLido = 0;
void setup() {
Serial.begin(9600);
pinMode(Led, OUTPUT);
}
void loop() {
Serial.println(ValorLido);
ValorLido = analogRead(LDR);
if (ValorLido < 70){
digitalWrite(Led, HIGH);
}
else{
digitalWrite(Led, LOW);
}
}
