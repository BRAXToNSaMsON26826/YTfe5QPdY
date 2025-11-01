// 代码生成时间: 2025-11-02 06:43:11
using System;
using UnityEngine;

/// <summary>
/// Medical Insurance Settlement System
/// </summary>
public class MedicalInsuranceSystem
{
    /// <summary>
    /// Settle the medical insurance for a given patient bill.
    /// </summary>
    /// <param name="billAmount">The amount of the medical bill.</param>
    /// <param name="insuranceCoverage">The insurance coverage percentage.</param>
    /// <returns>The amount the patient needs to pay.</returns>
    public double SettleMedicalBill(double billAmount, double insuranceCoverage)
    {
        // Validate input parameters
        if (billAmount <= 0)
        {
            Debug.LogError("Bill amount must be positive.");
            throw new ArgumentException("Bill amount must be positive.");
        }

        if (insuranceCoverage < 0 || insuranceCoverage > 100)
        {
            Debug.LogError("Insurance coverage must be between 0 and 100.");
            throw new ArgumentOutOfRangeException("Insurance coverage must be between 0 and 100.");
        }

        // Calculate the amount covered by insurance
        double insuranceAmount = billAmount * (insuranceCoverage / 100);

        // Calculate the remaining amount to be paid by the patient
        double patientAmount = billAmount - insuranceAmount;

        // Ensure the patient amount is not negative
        if (patientAmount < 0)
        {
            Debug.LogError("Patient amount cannot be negative.");
            throw new InvalidOperationException("Patient amount cannot be negative.");
        }

        return patientAmount;
    }

    /// <summary>
    /// Main method for demonstration purposes.
    /// </summary>
    private void Start()
    {
        try
        {
            double billAmount = 1000.0; // Example bill amount
            double insuranceCoverage = 80.0; // Example insurance coverage percentage

            double patientAmount = SettleMedicalBill(billAmount, insuranceCoverage);
            Debug.Log("Patient Amount to Pay: " + patientAmount);
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred: " + ex.Message);
        }
    }
}
