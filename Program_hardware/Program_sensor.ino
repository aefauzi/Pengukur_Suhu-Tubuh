#include <Wire.h>
#include <Adafruit_MLX90614.h>
const int pinBuzzer = 2;
Adafruit_MLX90614 mlx = Adafruit_MLX90614();
float ling, object;

void setup() {
  Serial.begin(9600);
  Serial.println("Adafruit MLX90614 test");  
  mlx.begin();  
  pinMode(pinBuzzer, OUTPUT);
}

void loop() {
  ling= mlx.readAmbientTempC();
  object= mlx.readObjectTempC();
  Serial.print(ling); Serial.print(";"); Serial.println(object); 
  if (object > 37) {
      digitalWrite(pinBuzzer, HIGH);
  }
  if (object < 37) {
      digitalWrite(pinBuzzer, LOW);
  }
        //  Serial.print("Ambient = "); Serial.print(ling); 
//  Serial.print("*C\tObject = "); Serial.print(object); Serial.println("*C");
//  Serial.print("Ambient = "); Serial.print(mlx.readAmbientTempF()); 
//  Serial.print("*F\tObject = "); Serial.print(mlx.readObjectTempF()); Serial.println("*F");
  delay(500);
}
