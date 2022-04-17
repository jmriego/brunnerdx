using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BrunnerDX
{
    internal class BrunnerDXGuiOptions: IDisposable
    {
        public bool hasFinishedInitializing = false;
        private Timer saveTimer;

        public BrunnerDXGuiOptions()
        {
            saveTimer = new Timer(1000);
            saveTimer.AutoReset = false;
            saveTimer.Stop();
            saveTimer.Elapsed += (o, e) => this.Save();
        }

        // Force options
        public int forceMultiplier
        {
            get { return (int)Properties.Settings.Default.Force; }
            set { Properties.Settings.Default.Force = value; this.StartSaveTimer();  }
        }

        public bool defaultSpring
        {
            get { return Properties.Settings.Default.DefaultSpring; }
            set { Properties.Settings.Default.DefaultSpring = value; this.StartSaveTimer();  }
        }

        //Connection options
        public string comPort
        {
            get { return Properties.Settings.Default.ComPort; }
            set { Properties.Settings.Default.ComPort = value; this.StartSaveTimer();  }
        }

        public string ip
        {
            get { return Properties.Settings.Default.IP; }

            set { Properties.Settings.Default.IP = value; this.StartSaveTimer(); }
        }

        public int port
        {
            get { return Properties.Settings.Default.Port; }
            set { Properties.Settings.Default.Port = value; this.StartSaveTimer();  }
        }

        // CLS2Sim Auto open options
        public bool autoConnect
        {
            get { return Properties.Settings.Default.AutoConnect; }
            set { Properties.Settings.Default.AutoConnect = value; this.StartSaveTimer();  }
        }

        public bool autoOpenCLS2Sim
        {
            get { return Properties.Settings.Default.AutoOpenCLS2Sim; }
            set { Properties.Settings.Default.AutoOpenCLS2Sim = value; this.StartSaveTimer();  }
        }

        public string CLS2SimPath
        {
            get { return Properties.Settings.Default.AutoOpenCLS2SimPath; }
            set { Properties.Settings.Default.AutoOpenCLS2SimPath = value; this.StartSaveTimer();  }
        }

        // trimming strength options
        public int trimStrengthXY
        {
            get { return Properties.Settings.Default.TrimStrengthXY < 100 ? Properties.Settings.Default.TrimStrengthXY : 100; }
            set { Properties.Settings.Default.TrimStrengthXY = value; this.StartSaveTimer();  }
        }

        public int trimStrengthZ
        {
            get { return Properties.Settings.Default.TrimStrengthZ < 100 ? Properties.Settings.Default.TrimStrengthZ : 100; }
            set { Properties.Settings.Default.TrimStrengthZ = value; this.StartSaveTimer();  }
        }

        // button mapping options
        public int CenterTrimMapping
        {
            get { return Properties.Settings.Default.CenterTrim; }
            set { Properties.Settings.Default.CenterTrim = value; this.StartSaveTimer();  }
        }

        public int ReleaseTrimMapping
        {
            get { return Properties.Settings.Default.ReleaseTrim; }
            set { Properties.Settings.Default.ReleaseTrim = value; this.StartSaveTimer();  }
        }

        public int DecTrimXMapping
        {
            get { return Properties.Settings.Default.DecTrimX; }
            set { Properties.Settings.Default.DecTrimX = value; this.StartSaveTimer();  }
        }

        public int IncTrimXMapping
        {
            get { return Properties.Settings.Default.IncTrimX; }
            set { Properties.Settings.Default.IncTrimX = value; this.StartSaveTimer();  }
        }

        public int DecTrimYMapping
        {
            get { return Properties.Settings.Default.DecTrimY; }
            set { Properties.Settings.Default.DecTrimY = value; this.StartSaveTimer();  }
        }

        public int IncTrimYMapping
        {
            get { return Properties.Settings.Default.IncTrimY; }
            set { Properties.Settings.Default.IncTrimY = value; this.StartSaveTimer();  }
        }

        public void Dispose()
        {
            saveTimer.Dispose();
        }

        private void StartSaveTimer()
        {
            if (this.hasFinishedInitializing)
            {
                saveTimer.Stop();
                saveTimer.Start();
            }
        }
        private void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
