// 代码生成时间: 2025-09-24 16:50:38
using System;
using System.IO;
using System.IO.Compression;

/// <summary>
/// A utility class for decompressing files in Unity.
/// </summary>
public class FileDecompressor
{
    /// <summary>
    /// Decompresses a compressed file to a specified destination.
    /// </summary>
    /// <param name="compressedFilePath">The path of the compressed file.</param>
    /// <param name="destinationFolderPath">The destination folder path.</param>
    /// <returns>True if decompression is successful, otherwise false.</returns>
    public bool DecompressFile(string compressedFilePath, string destinationFolderPath)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(compressedFilePath))
            {
                Debug.LogError("The compressed file does not exist.");
                return false;
            }

            // Create the destination folder if it does not exist
            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
            }

            // Decompress the file
            ZipFile.ExtractToDirectory(compressedFilePath, destinationFolderPath);

            return true;
        }
        catch (Exception ex)
        {
            // Log the exception and return false
            Debug.LogError($"An error occurred while decompressing the file: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Logs debug messages in Unity.
    /// </summary>
    /// <param name="message">The message to log.</param>
    private void DebugLog(string message)
    {
        #if UNITY_EDITOR
        UnityEngine.Debug.Log(message);
        #endif
    }
}
