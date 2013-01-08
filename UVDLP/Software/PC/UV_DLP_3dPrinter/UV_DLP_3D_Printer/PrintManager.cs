using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer
{
    /*
     * This class controls print jobs from start to finish. It feeds the generated sliced images
     * one at a time, along with control information over the PrinterInterface
     */
    public enum ePrintStat
    {
        ePrintStarted,
        ePrintCancelled,
        eLayerCompleted
    }

    public delegate void delPrintStatus(ePrintStat printstat);
    class PrintManager
    {
        public delPrintStatus PrintStatus; // the delegate to let the rest of the world know
        public PrintManager() 
        {
        
        }
        // This function is called to start the print job
        public void StartPrint() 
        {
            if (PrintStatus != null) 
            {
                PrintStatus(ePrintStat.ePrintStarted);
            }
        }
        // This function manually cancels the print job
        public void CancelPrint() 
        {
            if (PrintStatus != null)
            {
                PrintStatus(ePrintStat.ePrintCancelled);
            }
        
        }
    }
}
