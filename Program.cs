using System;
using System.IO;

namespace fda
{
    class Program
    {
        static void Main(string[] args)
        {
            string target = @"F:\DEV\funtohard\node_modules";

            // Handle command line argument if provided
            if (args.Length > 0)
            {
                target = args[0];
            }

            Console.WriteLine($"Attempting to delete: {target}");

            try
            {
                FastDelete.DeleteDir(target);
                Console.WriteLine("Directory deletion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deletion: {ex.Message}");
            }
        }
    }

    public static class FastDelete
    {
        public static void DeleteDir(string target)
        {
            if (!Directory.Exists(target))
            {
                Console.WriteLine($"Directory does not exist: {target}");
                return;
            }

            try
            {
                // Use long path prefix for Windows long path support
                string longPath = target.StartsWith(@"\\?\") ? target : @"\\?\" + Path.GetFullPath(target);
                DeleteDirRecursive(longPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete {target}: {ex.Message}");
                // Fallback to regular path
                try
                {
                    DeleteDirRecursive(target);
                }
                catch (Exception fallbackEx)
                {
                    Console.WriteLine($"Fallback deletion also failed: {fallbackEx.Message}");
                }
            }
        }

        private static void DeleteDirRecursive(string target)
        {
            if (!Directory.Exists(target)) return;

            // Delete children first (depth-first)
            try
            {
                foreach (string dir in Directory.GetDirectories(target))
                {
                    DeleteDirRecursive(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enumerating subdirectories in {target}: {ex.Message}");
            }

            try
            {
                foreach (string file in Directory.GetFiles(target))
                {
                    try
                    {
                        // Remove read-only and other restrictive attributes
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete file {file}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enumerating files in {target}: {ex.Message}");
            }

            try
            {
                Directory.Delete(target, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete directory {target}: {ex.Message}");
            }
        }
    }
}
