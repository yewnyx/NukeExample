using System;
using System.Linq;
using System.Threading;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Unity;
using Nuke.Common.Utilities.Collections;
using xyz.yewnyx.build.Nuke;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;

class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Platform to target")] BuildTarget BuildTarget;

    Target EnsurePlatform => _ => _
        .Requires(() => BuildTarget)
        .Executes(() =>
        {
            // UnityTasks.Unity(_ => _
            //     .SetHubVersion("6000.0.5f1")
            //     .SetProjectPath(RootDirectory)
            //     .EnableQuit()
            //     .EnableMinimalOutput()
            //     .SetExecuteMethod("xyz.yewnyx.build.BuildScript.SwitchPlatforms")
            //     .AddCustomArguments("-buildTarget", BuildTarget.UnityBuildTarget)
            // );
            //
            // // Wait for Unity to finish
            // Thread.Sleep(TimeSpan.FromSeconds(5));
        });

    Target Compile => _ => _
        .Requires(() => BuildTarget)
        .DependsOn(EnsurePlatform)
        .Executes(() =>
        {
            var outputFolder = RootDirectory / "Builds" / BuildTarget / Configuration;
            outputFolder.CreateOrCleanDirectory();
            var outputPath = outputFolder / "Game.exe";
            
            UnityTasks.Unity(_ => _
                .SetHubVersion("6000.0.5f1")
                .SetProjectPath(RootDirectory)
                .EnableBatchMode()
                .EnableNoGraphics()
                .EnableQuit()
                .SetExecuteMethod("xyz.yewnyx.build.BuildScript.Build")
                .AddCustomArguments("-buildTarget", BuildTarget.UnityBuildTarget)
                .AddCustomArguments("-standaloneBuildSubtarget", "Server")
                .AddCustomArguments("-outputPath", outputPath));
        });

}
