

//some definitions

int PINZSTEP = 1;         // step (output)
int PINZDIR = 2;         // direction (output)
int PINPLATTEMP  = 3;   // platform temperature (input analog)
int PINESTOP = 4;       // emergency stop (input digital)
int PINZLIMITMIN = 5;   // Z limit minimum (input digital)
int PINZLIMITMAX = 6;   // Z limit maximum (input digital)
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
            // say what you got:
            Serial.print("I received: ");
            Serial.println(command);        
            idx = 0; // reset position
          }
        }
    }
  delay(1);        // delay in between reads for stability
}
