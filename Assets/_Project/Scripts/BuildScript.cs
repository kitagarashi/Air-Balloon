using System;
using UnityEditor;
using UnityEngine;

public class BuildScript
{
    public static void PerformBuild()
    {
        // Настройка пакета и SDK
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, Environment.GetEnvironmentVariable("PACKAGE_NAME"));
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel23;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel34;

        // Конфигурация сборки
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/_Project/Scenes/Game.unity" }, // Укажите свои сцены
            locationPathName = "build/app.apk",
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        BuildPipeline.BuildPlayer(options);
    }
}