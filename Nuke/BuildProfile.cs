using System;
using System.ComponentModel;
using System.IO;
using Nuke.Common.IO;
using Nuke.Common.Tooling;

namespace xyz.yewnyx.build.Nuke;

[TypeConverter(typeof(TypeConverter<BuildProfile>))]
public class BuildProfile : Enumeration
{
    public static BuildProfile AndroidDev = new() { Value = "Android Dev" };
    public static BuildProfile Android = new() { Value = "Android" };
    public static BuildProfile iOSDev = new() { Value = "iOS Dev" };
    public static BuildProfile iOS = new() { Value = "iOS" };
    public static BuildProfile LinuxServerDev = new() { Value = "Linux Server Dev" };
    public static BuildProfile LinuxServerMonoDev = new() { Value = "Linux Server Mono Dev" };
    public static BuildProfile LinuxServer = new() { Value = "Linux Server" };
    public static BuildProfile QuestDev = new() { Value = "Quest Dev" };
    public static BuildProfile Quest = new() { Value = "Quest" };
    public static BuildProfile WindowsDev = new() { Value = "Windows Dev" };
    public static BuildProfile WindowsMonoDev = new() { Value = "Windows Mono Dev" };
    public static BuildProfile WindowsServerDev = new() { Value = "Windows Server Dev" };
    public static BuildProfile WindowsServerMonoDev = new() { Value = "Windows Server Mono Dev" };
    public static BuildProfile WindowsServer = new() { Value = "Windows Server" };
    public static BuildProfile Windows = new() { Value = "Windows" };

    public static implicit operator string(BuildProfile buildProfile) => buildProfile.Value;
    
    public string Extension => Value switch
    {
        "Android Dev" => "-dev.apk",
        "Android" => ".apk",
        "iOS Dev" => "-dev.ipa",
        "iOS" => ".ipa",
        "Linux Server Dev" => "-dedicated-dev.x86_64",
        "Linux Server Mono Dev" => "-dedicated-dev-mono.x86_64",
        "Linux Server" => "-dedicated.x86_64",
        "Quest Dev" => ".apk",
        "Quest" => ".apk",
        "Windows Dev" => "-dev.exe",
        "Windows Mono Dev" => "-dev-mono.exe",
        "Windows Server Dev" => "dedicated-dev.exe",
        "Windows Server Mono Dev" => "dedicated-dev-mono.exe",
        "Windows Server" => "dedicated.exe",
        "Windows" => ".exe",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string GetOutputPath(AbsolutePath RootDirectory, string exeName) => RootDirectory / "Builds" / Value / $"{exeName}{Extension}";
    
    public string BuildProfilePath => Path.Combine("Assets", "Settings", "Build Profiles", $"{Value}.asset");
}