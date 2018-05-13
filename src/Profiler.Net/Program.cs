using System;
using System.Diagnostics;
using PS = StartProcess.Processor;

namespace Profiler.Net {
    class Program {
        static void Start(string cmd) {
            var ps = new Process();
            ps.StartInfo = new ProcessStartInfo {
                FileName = "bash",
                Arguments = "-c mono",
                UseShellExecute = true
            };
            ps.Start();
            ps.WaitForExit();

        }
        static void Main(string[] args) {
            // PS.StartProcess("mon --version");
            // PS.StartProcess("bash -c mono");
            Start("");
        }
    }
}
