// 代码生成时间: 2025-10-08 20:54:50
 * documentation, and maintainability.
 */

using System;
using System.Collections.Generic;

/// <summary>
/// A class responsible for managing the scheduling of medical resources.
/// </summary>
public class MedicalResourceScheduler
{
    /// <summary>
    /// A dictionary to hold the resources and their availability.
    /// </summary>
    private Dictionary<string, bool> resourceAvailability;

    /// <summary>
    /// Initializes a new instance of the MedicalResourceScheduler class.
    /// </summary>
    public MedicalResourceScheduler()
    {
        resourceAvailability = new Dictionary<string, bool>();
    }

    /// <summary>
    /// Adds a medical resource to the scheduler.
    /// </summary>
    /// <param name="resourceName">The name of the resource.</param>
    /// <exception cref="ArgumentException">Thrown when the resource already exists.</exception>
    public void AddResource(string resourceName)
    {
        if (resourceAvailability.ContainsKey(resourceName))
        {
            throw new ArgumentException($"Resource {resourceName} already exists.");
        }

        resourceAvailability.Add(resourceName, true);
    }

    /// <summary>
    /// Removes a medical resource from the scheduler.
    /// </summary>
    /// <param name="resourceName">The name of the resource.</param>
    /// <exception cref="KeyNotFoundException">Thrown when the resource does not exist.</exception>
    public void RemoveResource(string resourceName)
    {
        if (!resourceAvailability.ContainsKey(resourceName))
        {
            throw new KeyNotFoundException($"Resource {resourceName} not found.");
        }

        resourceAvailability.Remove(resourceName);
    }

    /// <summary>
    /// Checks out a medical resource, marking it as unavailable.
    /// </summary>
    /// <param name="resourceName">The name of the resource.</param>
    /// <returns>True if the resource was successfully checked out, otherwise false.</returns>
    public bool CheckOutResource(string resourceName)
    {
        if (!resourceAvailability.ContainsKey(resourceName) || !resourceAvailability[resourceName])
        {
            return false;
        }

        resourceAvailability[resourceName] = false;
        return true;
    }

    /// <summary>
    /// Checks in a medical resource, marking it as available.
    /// </summary>
    /// <param name="resourceName">The name of the resource.</param>
    /// <returns>True if the resource was successfully checked in, otherwise false.</returns>
    public bool CheckInResource(string resourceName)
    {
        if (!resourceAvailability.ContainsKey(resourceName) || resourceAvailability[resourceName])
        {
            return false;
        }

        resourceAvailability[resourceName] = true;
        return true;
    }

    /// <summary>
    /// Gets the availability status of a medical resource.
    /// </summary>
    /// <param name="resourceName">The name of the resource.</param>
    /// <returns>True if the resource is available, otherwise false.</returns>
    public bool GetResourceAvailability(string resourceName)
    {
        if (!resourceAvailability.ContainsKey(resourceName))
        {
            throw new KeyNotFoundException($"Resource {resourceName} not found.");
        }

        return resourceAvailability[resourceName];
    }
}
