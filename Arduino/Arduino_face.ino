
#include<Servo.h>
Servo servolHorizontal; //横舵机
Servo servolVertical;  //竖舵机
int angleHorizontal = 90;
int angleVertical = 90; 
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.flush();
  servolHorizontal.attach(5);  //横5口
  servolVertical.attach(6);    //竖6口
  servolHorizontal.write(angleHorizontal);
  servolVertical.write(angleVertical);
  
}

void loop() {
  if(Serial.available()>0){
      char ch = Serial.read();
      switch(ch){
      case '0':
        if(angleHorizontal+2 < 180){
          angleHorizontal = angleHorizontal +2;
          servolHorizontal.write(angleHorizontal); 
        }
        break;
      case '1':
        if(angleHorizontal -2 > 0){
          angleHorizontal = angleHorizontal - 2;
          servolHorizontal.write(angleHorizontal);
        }
        break;
      case '3':
        if(angleVertical+2 < 180){
          angleVertical = angleVertical +2;
          servolVertical.write(angleVertical); 
        }
        break;
      case '2':
        if(angleVertical -2 > 0){
          angleVertical = angleVertical - 2;
          servolVertical.write(angleVertical);
        }
        break;
      }
      delay(10);
   }
    
}
    
  // put your main code here, to run repeatedly:

