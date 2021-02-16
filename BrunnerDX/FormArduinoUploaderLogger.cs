using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

using ArduinoUploader;

namespace BrunnerDX
{
    class FormArduinoUploaderLogger: IArduinoUploaderLogger
    {
        private BrunnerDXGui form;

        public FormArduinoUploaderLogger(BrunnerDXGui form)
        {
            this.form = form;
        }

        public void Error(string message, Exception exception)
        {
            this.form.ConsoleLogText(message, Color.Red);
        }

        public void Warn(string message)
        {
            this.form.ConsoleLogText(message, Color.Orange);
        }

        public void Info(string message)
        {
            this.form.ConsoleLogText(message, Color.Black);
        }

        public void Debug(string message)
        {
            this.form.ConsoleLogText(message, Color.Blue);
        }

        public void Trace(string message)
        {
            this.form.ConsoleLogText(message, Color.DarkRed);
        }
    }
}
