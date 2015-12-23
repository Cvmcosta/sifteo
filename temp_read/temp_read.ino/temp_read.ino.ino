int temp_in = 0;
const int lm = 0;
float temp = 0;
void setup() {
  Serial.begin(9600);
  analogReference(INTERNAL);
}

void loop() {
  temp = analogRead(lm);
  temp = temp_in * 0.1075268817204301;
  Serial.print("temperature = ");
  Serial.println(temp); 
}
