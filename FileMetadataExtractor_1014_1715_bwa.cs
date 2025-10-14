// 代码生成时间: 2025-10-14 17:15:46
using System;
using System.IO;
using System.Linq;

namespace UnityFileMetadataExtractor
{
    /// <summary>
    /// A class to extract metadata from files.
    /// </summary>
    public class FileMetadataExtractor
    {
        // Method to extract metadata from a file.
        public static FileInfo ExtractMetadata(string filePath)
        {
            // Check if the provided file path is null or whitespace.
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or whitespace.");
            }

            // Try to get the file information.
            try
            {
                // Check if the file exists.
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The specified file does not exist.");
                }

                // Get the file information.
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo;
            }
            catch (FileNotFoundException ex)
            {
                // Handle the case where the file is not found.
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that may occur.
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        // Main method for demonstration purposes.
        public static void Main(string[] args)
        {
            // Example usage of the ExtractMetadata method.
            string testFilePath = "path_to_your_file_here";
            FileInfo fileInfo = ExtractMetadata(testFilePath);
            if (fileInfo != null)
            {
                Console.WriteLine($"File Name: {fileInfo.Name}
Creation Time: {fileInfo.CreationTime}
Last Access Time: {fileInfo.LastAccessTime}
Last Write Time: {fileInfo.LastWriteTime}
Length: {fileInfo.Length} bytes");
            }
        }
    }
}