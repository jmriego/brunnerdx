using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

using NLog;

using ArduinoUploader;

namespace BrunnerDX
{
    class FormArduinoUploaderLogger: IArduinoUploaderLogger
    {
        private NLog.Logger Logger;

        public FormArduinoUploaderLogger(NLog.Logger logger)
        {
            this.Logger = logger;
        }

        public void Error(string message, Exception exception)
        {
            this.Logger.Error(exception, message);
        }

        public void Warn(string message)
        {
            this.Logger.Warn(message);
        }

        public void Info(string message)
        {
            this.Logger.Info(message);
        }

        public void Debug(string message)
        {
            this.Logger.Debug(message);
        }

        public void Trace(string message)
        {
            this.Logger.Trace(message);
        }
    }
}
