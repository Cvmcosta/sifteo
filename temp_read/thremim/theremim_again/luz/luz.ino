const int ldr = 0;
int leitura = 0;

void setup() {
  Serial.begin(9600);
}

void loop() {
  leitura = analogRead(ldr);
  Serial.println(leitura);
  delay(500);
}
