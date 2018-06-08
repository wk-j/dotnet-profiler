#addin "wk.StartProcess"
#addin "wk.ProjectParser"

using PS = StartProcess.Processor;

using ProjectParser;

var name = "Profiler";
var project = $"src/{name}/{name}.fsproj";
var info = Parser.Parse(project);
var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
var currentDir = new System.IO.DirectoryInfo(".").FullName;

Task("Pack").Does(() => {
    CleanDirectory("publish");
    DotNetCorePack(project, new DotNetCorePackSettings {
        OutputDirectory = "publish"
    });
});

Task("Publish-Nuget")
    .IsDependentOn("Pack")
    .Does(() => {
        var npi = EnvironmentVariable("npi");
        var nupkg = new DirectoryInfo("publish").GetFiles("*.nupkg").LastOrDefault();
        var package = nupkg.FullName;
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = npi
        });
});

Task("Uninstall").Does(() => {
    PS.StartProcess($"dotnet tool uninstall -g wk.{name}");
});

Task("Install")
    .IsDependentOn("Pack")
    .Does(() => {
        Information(info.Version);
        PS.StartProcess($"dotnet tool install -g wk.{name} --add-source {currentDir}/publish --version {info.Version}");
});

Task("Reinstall")
    .IsDependentOn("Uninstall")
    .IsDependentOn("Install");


Task("A").Does(() => {
    PS.StartProcess("csc -out:temp/a.exe  resources/Program.cs");
    PS.StartProcess("mono --profile=log:report temp/a.exe");
});

var target = Argument("target", "default");
RunTarget(target);