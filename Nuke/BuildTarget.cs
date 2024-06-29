using System;
using System.ComponentModel;
using Nuke.Common.Tooling;

namespace xyz.yewnyx.build.Nuke;

[TypeConverter(typeof(TypeConverter<BuildTarget>))]
public class BuildTarget : Enumeration
{
    public static BuildTarget Android = new BuildTarget { Value = nameof(Android) };
    public static BuildTarget iOS = new BuildTarget { Value = nameof(iOS) };
    public static BuildTarget Windows = new BuildTarget { Value = nameof(Windows) };
    public static BuildTarget LinuxDedicatedServer = new BuildTarget { Value = nameof(LinuxDedicatedServer) };

    public static implicit operator string(BuildTarget buildTarget) {
        return buildTarget.Value;
    }
    
    public string UnityBuildTarget {
        get {
            if (this == Android) { return "android"; }
            if (this == iOS) { return "ios"; }
            if (this == Windows) { return "win64"; }
            if (this == LinuxDedicatedServer) { return "linux64"; }
            throw new ArgumentException("Invalid target platform specified.");
        }
    }
}