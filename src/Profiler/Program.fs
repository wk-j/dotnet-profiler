open System.IO
open System.Diagnostics

type PS = StartProcess.Processor

let startProcess cmd args =
    use ps = new Process()
    let info = ProcessStartInfo()
    info.FileName <- cmd
    info.Arguments <- args
    info.UseShellExecute <- false

    ps.StartInfo <- info
    ps.Start() |> ignore
    ps.WaitForExit()

[<EntryPoint>]
let main argv =
    let source = argv.[0]
    let fullName = FileInfo(source).FullName
    let out = Path.Combine(Path.GetTempPath(), "a.exe")

    if File.Exists(out) then File.Delete(out)

    let compile = "-out:{out} {source}"
                    .Replace("{out}", out)
                    .Replace("{source}", fullName)
    let report  = "--profile=log:report {out}"
                    .Replace("{out}", out)

    startProcess "csc" compile
    startProcess "mono" report
    0