open System.Diagnostics

let startProcess cmd args =
    use ps = new Process()
    let info = ProcessStartInfo()
    info.FileName <- cmd
    info.Arguments <- args
    info.UseShellExecute <- true

    ps.StartInfo <- info
    ps.Start() |> ignore
    ps.WaitForExit()

startProcess "csc" "-out:/var/folders/75/3kz3lfh14fngqvly1lzkgk3c0000gn/T/a.exe resources/Program.cs"
startProcess "mono"  "--profile=log:report /var/folders/75/3kz3lfh14fngqvly1lzkgk3c0000gn/T/a.exe"
