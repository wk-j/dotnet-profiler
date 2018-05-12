open System.IO

(*
csc -out:temp/a.exe  resources/Program.cs
mono --profile=log:report temp/a.exe
*)

open StartProcess;

[<EntryPoint>]
let main argv =
    let source = argv.[0]
    let out = Path.Combine(Path.GetTempPath(), "a.exe")

    let compile = "-out:{out} {source}" .Replace("{out}", out) .Replace("{source}", source)
    let report =  "--profile=log:report {out}" .Replace("{out}", out)

    Processor.StartProcess("csc", compile)
    Processor.StartProcess("mono", report)
    0