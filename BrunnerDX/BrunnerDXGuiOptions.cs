using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BrunnerDX
{
    internal class BrunnerDXGuiOptions
    {
        public bool hasFinishedInitializing = false;
        private Timer saveTimer;

        public BrunnerDXGuiOptions()
        {
            saveTimer = new Timer(1000);
            saveTimer.AutoReset = false;
            saveTimer.Stop();
            saveTimer.Elapsed += (o, e) => Properties.Settings.Default.Save();
        }

        // Force options
        public double forceMultiplier
        {
            get { return Properties.Settings.Default.Force; }
            set { Properties.Settings.Default.Force = value; this.Save();  }
        }

        public bool defaultSpring
        {
            get { return Properties.Settings.Default.DefaultSpring; }
            set { Properties.Settings.Default.DefaultSpring = value; this.Save();  }
        }

        //Connection options
        public string comPort
        {
            get { return Properties.Settings.Default.ComPort; }
            set { Properties.Settings.Default.ComPort = value; this.Save();  }
        }

        public string ip
        {
            get { return Properties.Settings.Default.IP; }

            set { Properties.Settings.Default.IP = value; this.Save(); }
        }

        public int port
        {
            get { return Properties.Settings.Default.Port; }
            set { Properties.Settings.Default.Port = value; this.Save();  }
        }

        // CLS2Sim Auto open options
        public bool autoConnect
        {
            get { return Properties.Settings.Default.AutoConnect; }
            set { Properties.Settings.Default.AutoConnect = value; this.Save();  }
        }

        public bool autoOpenCLS2Sim
        {
            get { return Properties.Settings.Default.AutoOpenCLS2Sim; }
            set { Properties.Settings.Default.AutoOpenCLS2Sim = value; this.Save();  }
        }

        public string CLS2SimPath
        {
            get { return Properties.Settings.Default.AutoOpenCLS2SimPath; }
            set { Properties.Settings.Default.AutoOpenCLS2SimPath = value; this.Save();  }
        }

        // trimming strength options
        public int trimStrengthXY
        {
            get { return Properties.Settings.Default.TrimStrengthXY; }
            set { Properties.Settings.Default.TrimStrengthXY = value; this.Save();  }
        }

        public int trimStrengthZ
        {
            get { return Properties.Settings.Default.TrimStrengthZ; }
            set { Properties.Settings.Default.TrimStrengthZ = value; this.Save();  }
        }

        // button mapping options
        public int centerTrimMapping
        {
            get { return Properties.Settings.Default.CenterTrim; }
            set { Properties.Settings.Default.CenterTrim = value; this.Save();  }
        }

        public int ReleaseTrimMapping
        {
            get { return Properties.Settings.Default.ReleaseTrim; }
            set { Properties.Settings.Default.ReleaseTrim = value; this.Save();  }
        }

        public int decTrimXMapping
        {
            get { return Properties.Settings.Default.DecTrimX; }
            set { Properties.Settings.Default.DecTrimX = value; this.Save();  }
        }

        public int incTrimXMapping
        {
            get { return Properties.Settings.Default.IncTrimX; }
            set { Properties.Settings.Default.IncTrimX = value; this.Save();  }
        }

        public int decTrimYMapping
        {
            get { return Properties.Settings.Default.DecTrimY; }
            set { Properties.Settings.Default.DecTrimY = value; this.Save();  }
        }

        public int incTrimYMapping
        {
            get { return Properties.Settings.Default.IncTrimY; }
            set { Properties.Settings.Default.IncTrimY = value; this.Save();  }
        }

        private void Save()
        {
            if (this.hasFinishedInitializing)
            {
                saveTimer.Start();
            }
        }
    }
}
