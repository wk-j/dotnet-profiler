open System.IO

(*
csc -out:temp/a.exe  resources/Program.cs
mono --profile=log:report temp/a.exe
*)

open System.Diagnostics

type PS = StartProcess.Processor

let startProcess cmd args =
    use ps = new Process()
    let info = ProcessStartInfo()
    info.FileName <- cmd
    info.Arguments <- args
    info.UseShellExecute <- true

    ps.StartInfo <- info
    ps.Start() |> ignore
    ps.WaitForExit()

[<EntryPoint>]
let main argv =
    let source = argv.[0]
    let out = Path.Combine(Path.GetTempPath(), "a.exe")

    let compile = "csc -out:{out} {source}"
                    .Replace("{out}", out)
                    .Replace("{source}", source)
    let report  = "mono --profile=log:report {out}"
                    .Replace("{out}", out)

    startProcess "mono" "--version"

    //PS.StartProcess("mono --version")
    //PS.StartProcess (sprintf "%s" compile)
    //PS.StartProcess (sprintf "%s" report)
    0