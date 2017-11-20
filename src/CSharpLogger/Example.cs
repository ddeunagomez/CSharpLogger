using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLogger {
    class Example {
        static void Main(string[] args) {
            //Call this first if you want the log in a file.
            //CSharpLogger.Log(@"C:\Users\diego.DESKTOP-LECRLQ6\Desktop\testing.log");

            CSharpLogger.Log().Trace("Tracing text");
            CSharpLogger.Log().Debug("Debugging text");
            CSharpLogger.Log().Info("Info text");
            CSharpLogger.Log().Error("Error text");
            CSharpLogger.Log().Warning("Warning text");
            Console.ReadKey();
        }
    }
}
