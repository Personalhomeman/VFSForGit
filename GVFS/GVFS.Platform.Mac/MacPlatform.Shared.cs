﻿using System;
using System.IO;

namespace GVFS.Platform.Mac
{
    public partial class MacPlatform
    {
        public const string DotGVFSRoot = ".gvfs";

        public static string GetDataRootForGVFSImplementation()
        {
            return Path.Combine(
                Environment.GetEnvironmentVariable("HOME"),
                "Library",
                "Application Support",
                "GVFS");
        }

        public static string GetDataRootForGVFSComponentImplementation(string componentName)
        {
            return Path.Combine(GetDataRootForGVFSImplementation(), componentName);
        }

        public static bool TryGetGVFSEnlistmentRootImplementation(string directory, out string enlistmentRoot, out string errorMessage)
        {
            return POSIX.POSIXPlatform.TryGetGVFSEnlistmentRootImplementation(directory, DotGVFSRoot, out enlistmentRoot, out errorMessage);
        }

        public static string GetNamedPipeNameImplementation(string enlistmentRoot)
        {
            return POSIX.POSIXPlatform.GetNamedPipeNameImplementation(enlistmentRoot, DotGVFSRoot);
        }
    }
}
