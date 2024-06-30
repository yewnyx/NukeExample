using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.Unity;
using xyz.yewnyx.build.Nuke;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;

namespace xyz.yewnyx.build; 

class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.SwitchProfile);

    [Parameter("Build Profile")] BuildProfile BuildProfile;

    Target SwitchProfile => _ => _
        .Requires(() => BuildProfile)
        .Executes(() =>
        {
            UnityTasks.Unity(_ => _
                .SetHubVersion("6000.0.5f1")
                .SetProjectPath(RootDirectory)
                .SetExecuteMethod("xyz.yewnyx.build.BuildScript.SwitchProfile")
                .AddCustomArguments("-activeBuildProfile", BuildProfile.BuildProfilePath)
            );
        });

    Target Compile => _ => _
        .Requires(() => BuildProfile)
        .DependsOn(SwitchProfile)
        .Executes(() =>
        {
            var outputFolder = RootDirectory / "Builds" / BuildProfile;
            outputFolder.CreateOrCleanDirectory();
            var outputPath = outputFolder / "Game.exe";
            
            UnityTasks.Unity(_ => _
                .SetHubVersion("6000.0.5f1")
                .SetProjectPath(RootDirectory)
                .EnableBatchMode()
                .EnableNoGraphics()
                .EnableQuit()
                .SetExecuteMethod("xyz.yewnyx.build.BuildScript.Build")
                .AddCustomArguments("-activeBuildProfile", BuildProfile.BuildProfilePath)
                .AddCustomArguments("-outputPath", outputPath));
        });

}
