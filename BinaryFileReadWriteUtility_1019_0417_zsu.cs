// 代码生成时间: 2025-10-19 04:17:28
using System;
using System.IO;
using UnityEngine;

/// <summary>
/// A utility class for reading and writing binary files.
/// </summary>
public static class BinaryFileReadWriteUtility
{
    /// <summary>
    /// Reads the binary data from the specified file path.
    /// </summary>
    /// <param name="filePath">The path to the binary file.</param>
    /// <returns>The byte array containing the binary data.</returns>
    public static byte[] ReadBinaryFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                // Read all bytes from the file
                return File.ReadAllBytes(filePath);
            }
            else
            {
                Debug.LogError("The file does not exist: " + filePath);
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error reading binary file: " + ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Writes the binary data to the specified file path.
    /// </summary>
    /// <param name="filePath">The path to the binary file.</param>
    /// <param name="data">The byte array containing the binary data to write.</param>
    public static void WriteBinaryFile(string filePath, byte[] data)
    {
        try
        {
            // Ensure the directory exists
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Write all bytes to the file
            File.WriteAllBytes(filePath, data);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error writing binary file: " + ex.Message);
        }
    }
}
