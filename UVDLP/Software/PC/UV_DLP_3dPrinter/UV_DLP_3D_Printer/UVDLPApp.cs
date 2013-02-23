using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Engine3D;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using UV_DLP_3D_Printer.Drivers;
using UV_DLP_3D_Printer.Slicing;
using UV_DLP_3D_Printer;
using System.Drawing;
namespace UV_DLP_3D_Printer
{
    public enum eAppEvent 
    {
        eModelLoaded,
        eGCodeLoaded,
        eGCodeSaved
    }
    public delegate void AppEventDelegate(eAppEvent ev, String Message);
    /*
     This represents the main application object
     */
    public class UVDLPApp
    {
        public AppEventDelegate AppEvent;
        private static UVDLPApp m_instance = null;
        public String m_PathMachines;
        public String m_PathProfiles;
        public String m_apppath;
        // the current application configuration object
        public AppConfig m_appconfig;
        public string appcofnginame; // the full filename
        // the simple 3d graphic engine we're using along with OpenGL
        public Engine3d m_engine3d = new Engine3d();
        // the current model we're working with
        public Object3d m_obj = null;
        // the current machine configuration
        public MachineConfig m_printerinfo = new MachineConfig();
        // the current building / slicing profile
        public SliceBuildConfig m_buildparms;
        // the interface to the printer
        public DeviceInterface m_deviceinterface;// = new PrinterInterface();
        // the generated or loaded GCode File;
        public GCodeFile m_gcode;
        // the slicer we're using 
        public Slicer m_slicer;//
        //current slice file
        public SliceFile m_slicefile;
        public BuildManager m_buildmgr;


        private static String m_appconfigname = "CreationConfig.xml";
        public static String m_pathsep = "\\";
        public static UVDLPApp Instance() 
        {
            if (m_instance == null) 
            {
                m_instance = new UVDLPApp();
            }
            return m_instance;
        }

        private UVDLPApp() 
        {
            m_appconfig = new AppConfig();
            m_printerinfo = new MachineConfig();
            m_buildparms = new SliceBuildConfig();
            m_deviceinterface = new DeviceInterface();
            m_buildmgr = new BuildManager();
            m_slicer = new Slicer();
            m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            m_gcode = null;
        }
        public enum Platform
        {
            Windows,
            Linux,
            Mac
        }

        public void RaiseAppEvent(eAppEvent ev, String message) 
        {
            if (AppEvent != null) 
            {
                AppEvent(ev, message);
            }
        }
        public bool LoadModel(String filename) 
        {
            try
            {
                RaiseAppEvent(eAppEvent.eModelLoaded, "Model Loaded");
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
        void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers) 
        {
            String path = "";
            switch (ev) 
            {
                case Slicer.eSliceEvent.eSliceStarted:
                    // if we're exporting images
                    if (m_buildparms.exportimages) 
                    {
                        // get the model name
                        String modelname = m_obj.m_fullname;
                        // strip off the file extension
                        path = Path.GetDirectoryName(modelname);
                        path += UVDLPApp.m_pathsep;
                        path += Path.GetFileNameWithoutExtension(modelname);// strip off the file extension
                        if (!Directory.Exists(path)) // check and see if a directory of that name exists,
                        {
                            Directory.CreateDirectory(path);// if not, create it
                        }
                    }
                    break;
                case Slicer.eSliceEvent.eLayerSliced:
                    //save the rendered image slice
                    //render the slice
                   
                    if (m_buildparms.exportimages)
                    {
                        // get the model name
                        String modelname = m_obj.m_fullname;
                        // strip off the file extension
                        path = Path.GetDirectoryName(modelname);
                        path += UVDLPApp.m_pathsep;
                        path += Path.GetFileNameWithoutExtension(modelname);// strip off the file extension
                        Bitmap bmp = null;
                        String imagename = path + m_pathsep + Path.GetFileNameWithoutExtension(modelname) + String.Format("{0:0000}",layer) + ".png";
                        bmp = UVDLPApp.Instance().m_slicefile.RenderSlice(layer);
                        bmp.Save(imagename);
                    }
                    break;
                case Slicer.eSliceEvent.eSliceCompleted:
                    m_gcode = GCodeGenerator.Generate(m_slicefile, m_printerinfo);
                    /*
                    //get the path of the current object file
                    path = Path.GetDirectoryName(m_obj.m_fullname);
                    string fn = Path.GetFileNameWithoutExtension(m_obj.m_fullname);
                    if (!UVDLPApp.Instance().m_gcode.Save(path + UVDLPApp.m_pathsep + fn + ".gcode")) 
                    {
                        DebugLogger.Instance().LogRecord("Cannot save GCode File " + path + m_pathsep + fn + ".gcode");
                    }
                     * */
                    SaveGCode();
                    break;
                case Slicer.eSliceEvent.eSliceCancelled:
                    DebugLogger.Instance().LogRecord("Slicing Cancelled");
                    break;


            }
        }

        public void LoadGCode() 
        {
            try
            {
                //get the path of the current object file
                String path = Path.GetDirectoryName(m_obj.m_fullname);
                string fn = Path.GetFileNameWithoutExtension(m_obj.m_fullname);
                if (!UVDLPApp.Instance().m_gcode.Load(path + UVDLPApp.m_pathsep + fn + ".gcode"))
                {
                    DebugLogger.Instance().LogRecord("Cannot load GCode File " + path + m_pathsep + fn + ".gcode");
                }
                RaiseAppEvent(eAppEvent.eGCodeLoaded, "");
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        public void SaveGCode() 
        {
            try
            {
                //get the path of the current object file
                String path = Path.GetDirectoryName(m_obj.m_fullname);
                string fn = Path.GetFileNameWithoutExtension(m_obj.m_fullname);
                if (!UVDLPApp.Instance().m_gcode.Save(path + UVDLPApp.m_pathsep + fn + ".gcode"))
                {
                    DebugLogger.Instance().LogRecord("Cannot save GCode File " + path + m_pathsep + fn + ".gcode");
                }
                RaiseAppEvent(eAppEvent.eGCodeSaved, "");
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        // a public property to get the 3d engine
        public Engine3d Engine3D { get { return m_engine3d; } }

        public static Platform RunningPlatform()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    // Well, there are chances MacOSX is reported as Unix instead of MacOSX.
                    // Instead of platform check, we'll do a feature checks (Mac specific root folders)
                    if (Directory.Exists("/Applications")
                        & Directory.Exists("/System")
                        & Directory.Exists("/Users")
                        & Directory.Exists("/Volumes"))
                        return Platform.Mac;
                    else
                        return Platform.Linux;

                case PlatformID.MacOSX:
                    return Platform.Mac;

                default:
                    return Platform.Windows;
            }
        }

        public void SaveCurrentMachineConfig() 
        {
            try
            {
                m_printerinfo.Save(m_appconfig.m_curmachineeprofilename);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
        public void SaveCurrentSliceBuildConfig()
        {
            try
            {
                m_buildparms.Save(m_appconfig.m_cursliceprofilename);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        public void SetupDriver() 
        {
            DebugLogger.Instance().LogRecord("Changing driver type to " + m_printerinfo.m_driverconfig.m_drivertype.ToString());
            m_deviceinterface.Driver = DriverFactory.Create(m_printerinfo.m_driverconfig.m_drivertype);
        }

        public void DoAppStartup() 
        {
            m_apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //get the path separater 
            if (RunningPlatform() == Platform.Windows)
            {
                m_pathsep = "\\";
            }
            else
            {
                m_pathsep = "/";
            }
            // define some default paths
            m_PathMachines = m_apppath + "\\Machines";
            m_PathProfiles = m_apppath + "\\Profiles";

            // set up directories if they don't exist
            if (!Directory.Exists(m_PathMachines)) 
            {
                Utility.CreateDirectory(m_PathMachines);
            }
            if (!Directory.Exists(m_PathProfiles))
            {
                Utility.CreateDirectory(m_PathProfiles);
            }
            // load the current application configuration
            if (!m_appconfig.Load(m_apppath + m_pathsep + m_appconfigname))
            {
                m_appconfig.CreateDefault();
                m_appconfig.Save(m_apppath + m_pathsep + m_appconfigname);
            }

            //load the current machine configuration file
            if (!m_printerinfo.Load(m_appconfig.m_curmachineeprofilename)) 
            {
                m_printerinfo.Save(m_appconfig.m_curmachineeprofilename);
            }
            //load the current slicing profile
            if (!m_buildparms.Load(m_appconfig.m_cursliceprofilename)) 
            {
                m_buildparms.CreateDefault();
                m_buildparms.Save(m_appconfig.m_cursliceprofilename);
            }

            SetupDriver();
        }

    }
}
