using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Profiling;

public class DebugInfo : MonoBehaviour {
    private void Awake() {
        var temp = Application.GetStackTraceLogType(LogType.Log);
        Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);

        try {
            var exe = string.IsNullOrWhiteSpace(Assembly.GetExecutingAssembly().Location)
                ? ""
                : Path.GetFullPath(Assembly.GetExecutingAssembly().Location);
            Debug.Log($"Executing Assembly: {exe}");
            Debug.Log($"{nameof(Application.version)}: {Application.version}");
            Debug.Log($"{nameof(Application.unityVersion)}: {Application.unityVersion}");
            Debug.Log($"{nameof(Application.companyName)}: {Application.companyName}");
            Debug.Log($"{nameof(Application.productName)}: {Application.productName}");
            Debug.Log($"{nameof(Application.dataPath)}: {Application.dataPath}");
            Debug.Log($"{nameof(Application.persistentDataPath)}: {Application.persistentDataPath}");
            Debug.Log($"{nameof(Application.streamingAssetsPath)}: {Application.streamingAssetsPath}");
            Debug.Log($"{nameof(Application.temporaryCachePath)}: {Application.temporaryCachePath}");
            Debug.Log($"{nameof(Application.consoleLogPath)}: {Application.consoleLogPath}");
            Debug.Log($"{nameof(Application.genuine)}: {Application.genuine}");
            Debug.Log($"{nameof(Application.identifier)}: {Application.identifier}");
            Debug.Log($"{nameof(Application.platform)}: {Application.platform}");
            Debug.Log($"{nameof(Application.systemLanguage)}: {Application.systemLanguage}");
            Debug.Log($"{nameof(Application.installerName)}: {Application.installerName}");
            Debug.Log($"{nameof(Application.installMode)}: {Application.installMode}");
            Debug.Log($"{nameof(Application.sandboxType)}: {Application.sandboxType}");
            Debug.Log($"{nameof(Application.runInBackground)}: {Application.runInBackground}");
            Debug.Log($"{nameof(Application.isMobilePlatform)}: {Application.isMobilePlatform}");
            Debug.Log($"{nameof(Application.isConsolePlatform)}: {Application.isConsolePlatform}");

            Debug.Log($"{nameof(SystemInfo.deviceModel)}: {SystemInfo.deviceModel}");
            Debug.Log($"{nameof(SystemInfo.deviceType)}: {SystemInfo.deviceType}");
            Debug.Log($"{nameof(SystemInfo.operatingSystem)}: {SystemInfo.operatingSystem}");
            Debug.Log($"{nameof(SystemInfo.operatingSystemFamily)}: {SystemInfo.operatingSystemFamily}");

            Debug.Log($"{nameof(SystemInfo.processorType)}: {SystemInfo.processorType}");
            Debug.Log($"{nameof(SystemInfo.processorFrequency)}: {SystemInfo.processorFrequency}");
            Debug.Log($"{nameof(SystemInfo.processorCount)}: {SystemInfo.processorCount}");

            Debug.Log($"{nameof(SystemInfo.graphicsDeviceVendor)}: {SystemInfo.graphicsDeviceVendor}");
            Debug.Log($"{nameof(SystemInfo.graphicsDeviceName)}: {SystemInfo.graphicsDeviceName}");
            Debug.Log($"{nameof(SystemInfo.graphicsDeviceVendorID)}: {SystemInfo.graphicsDeviceVendorID}");
            Debug.Log($"{nameof(SystemInfo.graphicsDeviceID)}: {SystemInfo.graphicsDeviceID}");
            Debug.Log($"{nameof(SystemInfo.graphicsDeviceType)}: {SystemInfo.graphicsDeviceType}");
            Debug.Log($"{nameof(SystemInfo.graphicsDeviceVersion)}: {SystemInfo.graphicsDeviceVersion}");

            const long mb = 1024 * 1024;

            Debug.Log(
                $"{nameof(Profiler.GetTotalAllocatedMemoryLong) + "Mb"}: {Profiler.GetTotalAllocatedMemoryLong() / mb}");
            Debug.Log(
                $"{nameof(Profiler.GetTotalReservedMemoryLong) + "Mb"}: {Profiler.GetTotalReservedMemoryLong() / mb}");
            Debug.Log(
                $"{nameof(Profiler.GetTotalUnusedReservedMemoryLong) + "Mb"}: {Profiler.GetTotalUnusedReservedMemoryLong() / mb}");
            Debug.Log($"{nameof(SystemInfo.systemMemorySize) + "Mb"}: {SystemInfo.systemMemorySize}");
            Debug.Log($"{nameof(GC.GetTotalMemory) + "Mb"}: {GC.GetTotalMemory(false) / mb}");

            Debug.Log($"{nameof(SystemInfo.graphicsMemorySize) + "Mb"}: {SystemInfo.graphicsMemorySize}");

            Debug.Log($"{nameof(SystemInfo.batteryLevel)}: {SystemInfo.batteryLevel}");
            Debug.Log($"{nameof(SystemInfo.batteryStatus)}: {SystemInfo.batteryStatus}");
            Debug.Log($"{nameof(SystemInfo.copyTextureSupport)}: {SystemInfo.copyTextureSupport}");
            Debug.Log($"{nameof(SystemInfo.graphicsMultiThreaded)}: {SystemInfo.graphicsMultiThreaded}");
            Debug.Log($"{nameof(SystemInfo.graphicsShaderLevel)}: {SystemInfo.graphicsShaderLevel}");
            Debug.Log($"{nameof(SystemInfo.graphicsUVStartsAtTop)}: {SystemInfo.graphicsUVStartsAtTop}");
            Debug.Log(
                $"{nameof(SystemInfo.hasDynamicUniformArrayIndexingInFragmentShaders)}: {SystemInfo.hasDynamicUniformArrayIndexingInFragmentShaders}");
            Debug.Log($"{nameof(SystemInfo.hasHiddenSurfaceRemovalOnGPU)}: {SystemInfo.hasHiddenSurfaceRemovalOnGPU}");
            Debug.Log($"{nameof(SystemInfo.hasMipMaxLevel)}: {SystemInfo.hasMipMaxLevel}");
            Debug.Log(
                $"{nameof(SystemInfo.maxComputeBufferInputsCompute)}: {SystemInfo.maxComputeBufferInputsCompute}");
            Debug.Log($"{nameof(SystemInfo.maxComputeBufferInputsDomain)}: {SystemInfo.maxComputeBufferInputsDomain}");
            Debug.Log(
                $"{nameof(SystemInfo.maxComputeBufferInputsFragment)}: {SystemInfo.maxComputeBufferInputsFragment}");
            Debug.Log(
                $"{nameof(SystemInfo.maxComputeBufferInputsGeometry)}: {SystemInfo.maxComputeBufferInputsGeometry}");
            Debug.Log($"{nameof(SystemInfo.maxComputeBufferInputsHull)}: {SystemInfo.maxComputeBufferInputsHull}");
            Debug.Log($"{nameof(SystemInfo.maxComputeBufferInputsVertex)}: {SystemInfo.maxComputeBufferInputsVertex}");
            Debug.Log($"{nameof(SystemInfo.maxComputeWorkGroupSize)}: {SystemInfo.maxComputeWorkGroupSize}");
            Debug.Log($"{nameof(SystemInfo.maxComputeWorkGroupSizeX)}: {SystemInfo.maxComputeWorkGroupSizeX}");
            Debug.Log($"{nameof(SystemInfo.maxComputeWorkGroupSizeY)}: {SystemInfo.maxComputeWorkGroupSizeY}");
            Debug.Log($"{nameof(SystemInfo.maxComputeWorkGroupSizeZ)}: {SystemInfo.maxComputeWorkGroupSizeZ}");
            Debug.Log($"{nameof(SystemInfo.maxCubemapSize)}: {SystemInfo.maxCubemapSize}");
            Debug.Log($"{nameof(SystemInfo.maxTextureSize)}: {SystemInfo.maxTextureSize}");
            Debug.Log($"{nameof(SystemInfo.npotSupport)}: {SystemInfo.npotSupport}");
            Debug.Log($"{nameof(SystemInfo.renderingThreadingMode)}: {SystemInfo.renderingThreadingMode}");
            Debug.Log(
                $"{nameof(SystemInfo.supportedRandomWriteTargetCount)}: {SystemInfo.supportedRandomWriteTargetCount}");
            Debug.Log($"{nameof(SystemInfo.supportedRenderTargetCount)}: {SystemInfo.supportedRenderTargetCount}");
            Debug.Log($"{nameof(SystemInfo.usesLoadStoreActions)}: {SystemInfo.usesLoadStoreActions}");
            Debug.Log($"{nameof(SystemInfo.usesReversedZBuffer)}: {SystemInfo.usesReversedZBuffer}");

            Debug.Log($"{nameof(SystemInfo.supports2DArrayTextures)}: {SystemInfo.supports2DArrayTextures}");
            Debug.Log($"{nameof(SystemInfo.supports32bitsIndexBuffer)}: {SystemInfo.supports32bitsIndexBuffer}");
            Debug.Log($"{nameof(SystemInfo.supports3DRenderTextures)}: {SystemInfo.supports3DRenderTextures}");
            Debug.Log($"{nameof(SystemInfo.supports3DTextures)}: {SystemInfo.supports3DTextures}");
            Debug.Log($"{nameof(SystemInfo.supportsAccelerometer)}: {SystemInfo.supportsAccelerometer}");
            Debug.Log($"{nameof(SystemInfo.supportsAsyncCompute)}: {SystemInfo.supportsAsyncCompute}");
            Debug.Log($"{nameof(SystemInfo.supportsAsyncGPUReadback)}: {SystemInfo.supportsAsyncGPUReadback}");
            Debug.Log($"{nameof(SystemInfo.supportsAudio)}: {SystemInfo.supportsAudio}");
            Debug.Log($"{nameof(SystemInfo.supportsComputeShaders)}: {SystemInfo.supportsComputeShaders}");
            Debug.Log($"{nameof(SystemInfo.supportsCubemapArrayTextures)}: {SystemInfo.supportsCubemapArrayTextures}");
            Debug.Log($"{nameof(SystemInfo.supportsGeometryShaders)}: {SystemInfo.supportsGeometryShaders}");
            Debug.Log($"{nameof(SystemInfo.supportsGraphicsFence)}: {SystemInfo.supportsGraphicsFence}");
            Debug.Log($"{nameof(SystemInfo.supportsGyroscope)}: {SystemInfo.supportsGyroscope}");
            Debug.Log($"{nameof(SystemInfo.supportsHardwareQuadTopology)}: {SystemInfo.supportsHardwareQuadTopology}");
            Debug.Log($"{nameof(SystemInfo.supportsInstancing)}: {SystemInfo.supportsInstancing}");
            Debug.Log($"{nameof(SystemInfo.supportsMipStreaming)}: {SystemInfo.supportsMipStreaming}");
            Debug.Log($"{nameof(SystemInfo.supportsMotionVectors)}: {SystemInfo.supportsMotionVectors}");
            Debug.Log(
                $"{nameof(SystemInfo.supportsMultisampleAutoResolve)}: {SystemInfo.supportsMultisampleAutoResolve}");
            Debug.Log($"{nameof(SystemInfo.supportsMultisampledTextures)}: {SystemInfo.supportsMultisampledTextures}");
            Debug.Log(
                $"{nameof(SystemInfo.supportsRawShadowDepthSampling)}: {SystemInfo.supportsRawShadowDepthSampling}");
            Debug.Log($"{nameof(SystemInfo.supportsRayTracing)}: {SystemInfo.supportsRayTracing}");
            Debug.Log(
                $"{nameof(SystemInfo.supportsSeparatedRenderTargetsBlend)}: {SystemInfo.supportsSeparatedRenderTargetsBlend}");
            Debug.Log($"{nameof(SystemInfo.supportsSetConstantBuffer)}: {SystemInfo.supportsSetConstantBuffer}");
            Debug.Log($"{nameof(SystemInfo.supportsShadows)}: {SystemInfo.supportsShadows}");
            Debug.Log($"{nameof(SystemInfo.supportsSparseTextures)}: {SystemInfo.supportsSparseTextures}");
            Debug.Log(
                $"{nameof(SystemInfo.supportsStoreAndResolveAction)}: {SystemInfo.supportsStoreAndResolveAction}");
            Debug.Log($"{nameof(SystemInfo.supportsTessellationShaders)}: {SystemInfo.supportsTessellationShaders}");
            Debug.Log(
                $"{nameof(SystemInfo.supportsTextureWrapMirrorOnce)}: {SystemInfo.supportsTextureWrapMirrorOnce}");
            Debug.Log($"{nameof(SystemInfo.supportsVibration)}: {SystemInfo.supportsVibration}");
        } finally {
            Application.SetStackTraceLogType(LogType.Log, temp);
        }
    }
}