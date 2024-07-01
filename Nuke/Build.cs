using System.IO.Compression;
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
    public static int Main () => Execute<Build>(x => x.PlayerBuild);

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

    Target PlayerBuild => _ => _
        .Requires(() => BuildProfile)
        .DependsOn(SwitchProfile)
        .Executes(() =>
        {
            var outputFolder = BuildProfile.GetOutputFolder(RootDirectory);
            outputFolder.CreateOrCleanDirectory();
            
            var shipFolder = BuildProfile.GetShipFolder(RootDirectory);
            shipFolder.CreateOrCleanDirectory();
            
            var dontShipFolder = BuildProfile.GetDontShipFolder(RootDirectory);
            dontShipFolder.CreateOrCleanDirectory();
            
            var outputPath = BuildProfile.GetOutputPath(RootDirectory, "NukeExample");
            
            UnityTasks.Unity(_ => _
                .SetHubVersion("6000.0.5f1")
                .SetProjectPath(RootDirectory)
                .EnableBatchMode()
                .EnableNoGraphics()
                .SetExecuteMethod("xyz.yewnyx.build.BuildScript.Build")
                .AddCustomArguments("-activeBuildProfile", BuildProfile.BuildProfilePath)
                .AddCustomArguments("-outputPath", outputPath));
            
            var dontShipDirectories = (outputFolder / "Ship").GlobDirectories("*_BurstDebugInformation_DoNotShip",
                "*_BackUpThisFolder_ButDontShipItWithYourGame");
            foreach (var directory in dontShipDirectories) {
                directory.MoveToDirectory(dontShipFolder);
            }
            
            var dontShipArchive = BuildProfile.GetDontShipArchive(RootDirectory, "NukeExample", "zip");
            dontShipFolder.ZipTo(dontShipArchive, compressionLevel: CompressionLevel.SmallestSize);
            dontShipFolder.DeleteDirectory();
        });

}
