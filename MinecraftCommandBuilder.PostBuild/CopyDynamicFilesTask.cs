using System;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

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
            if (SourceDirectory == null || TargetDirectory == null)
            {
                Log.LogError("SourceDirectory and TargetDirectory must be set.");
                return false;
            }

            try
            {
                if (!Directory.Exists(TargetDirectory))
                {
                    Directory.CreateDirectory(TargetDirectory);
                }

                // Locate all `content/data/data` directories under the NuGet package root.
                var dataDirectories = Directory.GetDirectories(SourceDirectory, "data", SearchOption.AllDirectories)
                    .Where(dir =>
                        dir.EndsWith($"content{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}data",
                            StringComparison.OrdinalIgnoreCase));

                foreach (var dataDirectory in dataDirectories)
                {
                    // Recursively copy files from `content/data/data` to the target directory.
                    foreach (var file in Directory.GetFiles(dataDirectory, "*", SearchOption.AllDirectories))
                    {
                        var relativePath = GetRelativePath(dataDirectory, file);
                        var destFile = Path.Combine(TargetDirectory, relativePath);

                        var destDir = Path.GetDirectoryName(destFile);
                        if (!string.IsNullOrEmpty(destDir) && !Directory.Exists(destDir))
                        {
                            Directory.CreateDirectory(destDir);
                        }

                        File.Copy(file, destFile, true);
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

        /// <summary>
        /// Custom implementation of Path.GetRelativePath for .NET Standard 2.0.
        /// </summary>
        private static string GetRelativePath(string basePath, string path)
        {
            var baseUri = new Uri(AppendDirectorySeparator(basePath));
            var pathUri = new Uri(path);

            if (baseUri.Scheme != pathUri.Scheme)
            {
                throw new InvalidOperationException("Paths must have the same scheme.");
            }

            var relativeUri = baseUri.MakeRelativeUri(pathUri);
            return Uri.UnescapeDataString(relativeUri.ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        private static string AppendDirectorySeparator(string path) =>
            !path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal)
                ? $"{path}{Path.DirectorySeparatorChar}"
                : path;
    }
}
