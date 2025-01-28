﻿using System;
using System.IO;
using Microsoft.Build.Framework;
using Task = Microsoft.Build.Utilities.Task;

namespace MinecraftCommandBuilder.PostBuild
{
    // ReSharper disable once UnusedType.Global
    public class CopyDynamicFilesTask : Task
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        [Required]
        public string SourceDirectory { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        [Required]
        public string TargetDirectory { get; set; }

        public override bool Execute()
        {
            LogMessage($"Copying dynamic files from {SourceDirectory} to {TargetDirectory}");

            if (string.IsNullOrEmpty(SourceDirectory) || string.IsNullOrEmpty(TargetDirectory))
            {
                Log.LogError("SourceDirectory and TargetDirectory must be set.");
                return false;
            }

            try
            {
                if (!Directory.Exists(TargetDirectory))
                {
                    LogMessage($"Creating directory {TargetDirectory}");
                    Directory.CreateDirectory(TargetDirectory);
                }

                foreach (var dir in Directory.GetDirectories(SourceDirectory, "*", SearchOption.AllDirectories))
                {
                    if (!dir.EndsWith("content/data/data", StringComparison.OrdinalIgnoreCase))
                    {
                        LogMessage($"Skipping directory {dir}");
                        continue;
                    }

                    var targetSubDir = Path.Combine(TargetDirectory, Path.GetFileName(dir));

                    if (!Directory.Exists(targetSubDir))
                    {
                        LogMessage($"Creating directory {targetSubDir}");
                        Directory.CreateDirectory(targetSubDir);
                    }

                    foreach (var file in Directory.GetFiles(dir, "*", SearchOption.AllDirectories))
                    {
                        var destFile = Path.Combine(targetSubDir, Path.GetFileName(file));
                        LogMessage($"Copying {file} to {destFile}");
                        File.Copy(file, destFile, overwrite: true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex);
                return false;
            }
        }

        private void LogMessage(string message) =>
            Log.LogMessage(MessageImportance.Normal, message);
    }
}
