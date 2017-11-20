using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpLogger {
    class CSharpLogger {

        private string DateTimeFmt;
        private bool ToConsole;
        private bool Append;
        private string FName;

        static private CSharpLogger Instance = null;

        private enum Level {
            TRACE,
            INFO,
            DEBUG,
            WARNING,
            ERROR
        }

        static public CSharpLogger Log(string filename = null, bool append = false, string datetimeformat = "h:mm:ss tt") {
            if (Instance == null)
                Instance = new CSharpLogger(filename, append, datetimeformat);
            return Instance;
        }

        private CSharpLogger(string filename = null, bool append = false, string datetimeformat = "h:mm:ss tt")
        {
            DateTimeFmt = datetimeformat;
            ToConsole = (filename == null);
            Append = append;
            FName = filename;
            if (!ToConsole)
                Write("", Append); //If Append == false, will create a new empty file.

        }


        public void Debug(string text)
        {
            FormatString(Level.DEBUG, text);
        }


        public void Error(string text)
        {
            FormatString(Level.ERROR, text);
        }


        public void Info(string text)
        {
            FormatString(Level.INFO, text);
        }


        public void Trace(string text)
        {
            FormatString(Level.TRACE, text);
        }


        public void Warning(string text)
        {
            FormatString(Level.WARNING, text);
        }


        private void FormatString(Level level, string text)
        {
            string prefix;
            switch (level)
            {
                case Level.TRACE: prefix = "["+DateTime.Now.ToString(DateTimeFmt) + "][TRACE]   "; break;
                case Level.INFO: prefix = "["+DateTime.Now.ToString(DateTimeFmt) + "][INFO]    "; break;
                case Level.DEBUG: prefix = "["+DateTime.Now.ToString(DateTimeFmt) + "][DEBUG]   "; break;
                case Level.WARNING: prefix = "["+DateTime.Now.ToString(DateTimeFmt) + "][WARNING] "; break;
                case Level.ERROR: prefix = "["+DateTime.Now.ToString(DateTimeFmt) + "][ERROR]   "; break;
                default: prefix = ""; break;
            }

            if (ToConsole) {
                OutputToConsole(level, prefix + text);
            }
            else {
                Write(prefix + text);
            }
        }

        private void OutputToConsole(Level level, string s) {
            switch (level) {
                case Level.TRACE: Console.ForegroundColor = ConsoleColor.White; break;
                case Level.INFO: Console.ForegroundColor = ConsoleColor.Green ; break;
                case Level.DEBUG: Console.ForegroundColor = ConsoleColor.Cyan ; break;
                case Level.WARNING: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case Level.ERROR: Console.ForegroundColor = ConsoleColor.Red ; break;
                default: Console.ForegroundColor = ConsoleColor.White; break;
            }
            Console.WriteLine(s);
            Console.ResetColor();
        }
        private void Write(string text, bool app = true)
        {

            try
            {
                using (StreamWriter Writer = new StreamWriter(FName, app, Encoding.UTF8))
                {
                    if (text != "") Writer.WriteLine(text);
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
