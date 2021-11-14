using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using NLog;
using System.Runtime.InteropServices;
using System.IO;

namespace BrunnerDX
{
    
    public class CLS2SimAutomation
    {
        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        private string programPath;

        Logger logger = LogManager.GetCurrentClassLogger();

        public CLS2SimAutomation(string programPath)
        {
            this.programPath = programPath;
        }

        public void Open(Process returnFocus = null)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    this.StartInExternalControl(returnFocus);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, ex.Message);
                }
            });
            thread.Start();
        }

        void SetExternalControlOption(XmlDocument doc, bool value)
        {
            XmlNode nodeExternalControl = doc.SelectSingleNode("//setting[@id='340' and @name='APP_REMOTECONTROL_EXTERNALCONTROL']//boolean");
            XmlNode nodeAutoConnect = doc.SelectSingleNode("//setting[@id='130' and @name='APP_HARDWARE_AUTO_CONNECT']//boolean");

            nodeExternalControl.InnerText = value ? "true" : "false";
            nodeAutoConnect.InnerText = value ? "true" : "false";
        }

        void StartInExternalControl(Process returnFocus = null)
        {
            var xmlFile = Path.Combine(this.programPath, @"Settings\connection.stx");
            var clsExeFile = Path.Combine(this.programPath, @"CLS2Sim.exe");

            logger.Info($"Starting {clsExeFile} ...");
            var doc = new XmlDocument();
            doc.Load(xmlFile);
            SetExternalControlOption(doc, true);
            doc.Save(xmlFile);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = clsExeFile
                }
            };

            process.Start();
            process.WaitForInputIdle();

            foreach (int second in Enumerable.Range(1, 5))
            {
                Thread.Sleep(1000);
                if (returnFocus != null)
                {
                    SetForegroundWindow(returnFocus.MainWindowHandle);
                }
            }

            SetExternalControlOption(doc, false);
            doc.Save(xmlFile);
        }
    }
}
