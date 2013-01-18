

//some definitions

const int PINZSTEP = 1; 
const int PINZDIRECTION = 2;
const int PINPLATTEMP  = 3;   // platform temperature (input analog)
const int PINESTOP = 4;       // emergency stop (input digital)
const int PINZLIMITMIN = 5;   // Z limit minimum (input digital)
const int PINZLIMITMAX = 6;   // Z limit maximum (input digital)

float curzpos = 0; // current position of the z axis (in mm)
float feedrate = 1; // 1 mm/sec = ~ 157.4803149606299 steps/sec
float Zmmperstep = 0.00635;// 20 tpi and a 200 steps/rev motor - 
/*

20tpi 
200 steps per turn

1 full rev would be 1/20th of an inch

0.00025" per step
0.00635 mm per step

*/

/*
This is the firmware to control the UVDLP printer
*/
// the setup routine runs once when you press reset:
void setup() 
{
  // initialize serial communication at 115200 bits per second:
  Serial.begin(115200);
  SetupPins();
}

/*
This function sets up the Input / output map
*/
void SetupPins()
{
  /*
  // set up the stepp motor pins
   pinMode(PINZSTEP, OUTPUT);
   pinMode(PINZDIRECTION, OUTPUT);
   // set up the input pins
   pinMode(PINZLIMITMIN, INPUT);
   pinMode(PINZLIMITMAX, INPUT);
   */
}


char command[1024];
int idx = 0;

// the loop routine runs over and over again forever:
void loop() 
{
  int incomingByte = 0;
    if (Serial.available() > 0) 
    {
        // read the incoming byte:
        incomingByte = Serial.read();
        if(incomingByte != -1)
        {
          command[idx++] = incomingByte;
          if(incomingByte == '\n') // if we got a newline, parse the command...
          {
            ParseAndExecuteCommand();
            // say what you got:
//            Serial.print("I received: ");
//            Serial.println(command);        
            idx = 0; // reset position
          }
        }
    }
  delay(1);        // delay in between reads for stability
}

/*
This function will parse and execute the current command
*/
void ParseAndExecuteCommand()
{
  // put the command in a string for easier parsing
  String scommand = String(command); 
  if(scommand.startsWith("G")) // gcode
  {
  
  }else if (scommand.startsWith("M")) //mcode
  {
    
  }
}
