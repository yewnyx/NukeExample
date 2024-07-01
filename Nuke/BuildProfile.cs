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
        "iOS Dev" => "Dev.ipa",
        "iOS" => ".ipa",
        "Linux Server Dev" => "DedicatedServerDev.x86_64",
        "Linux Server Mono Dev" => "DedicatedServerDevMono.x86_64",
        "Linux Server" => "DedicatedServer.x86_64",
        "Quest Dev" => "Dev.apk",
        "Quest" => ".apk",
        "Windows Dev" => "Dev.exe",
        "Windows Mono Dev" => "DevMono.exe",
        "Windows Server Dev" => "DedicatedServerDev.exe",
        "Windows Server Mono Dev" => "DedicatedServerDevMono.exe",
        "Windows Server" => "DedicatedServer.exe",
        "Windows" => ".exe",
        _ => throw new ArgumentOutOfRangeException()
    };

    public AbsolutePath GetOutputFolder(AbsolutePath RootDirectory) => RootDirectory / "Builds" / Value.Replace(" ", "");
    public AbsolutePath GetShipFolder(AbsolutePath RootDirectory) => GetOutputFolder(RootDirectory) / "Ship";
    public AbsolutePath GetDontShipFolder(AbsolutePath RootDirectory) => GetOutputFolder(RootDirectory) / "DontShip";
    public AbsolutePath GetOutputPath(AbsolutePath RootDirectory, string exeName) => GetShipFolder(RootDirectory) / $"{exeName}{Extension}";
    
    public string BuildProfilePath => Path.Combine("Assets", "Settings", "Build Profiles", $"{Value}.asset");
}