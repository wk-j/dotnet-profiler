#! "netcoreapp2.0"

var process = new Process();
var info = new ProcessStartInfo {
    FileName = "mono",
    Arguments = "--version",
    UseShellExecute = true
};

process.StartInfo = info;

process.Start();

