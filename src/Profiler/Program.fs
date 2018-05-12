open System.IO

(*
csc -out:temp/a.exe  resources/Program.cs
mono --profile=log:report temp/a.exe
*)

open StartProcess;
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

[<EntryPoint>]
let main argv =
    let source = argv.[0]
    let out = Path.Combine(Path.GetTempPath(), "a.exe")

    let compile = "-out:{out} {source}" .Replace("{out}", out) .Replace("{source}", source)
    let report =  "--profile=log:report {out}" .Replace("{out}", out)

    printfn "csc %s" compile
    printfn "mono %s" report

    startProcess "csc" compile
    startProcess "mono" report

    0