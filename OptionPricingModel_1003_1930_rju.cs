// 代码生成时间: 2025-10-03 19:30:38
using System;

namespace OptionPricing
{
    public enum OptionType
    {
        Call,
        Put
    }

    public class OptionPricingModel
    {
        private double S; // Underlying asset price
        private double K; // Strike price
        private double T; // Time to maturity (in years)
        private double r; // Risk-free interest rate
        private double sigma; // Volatility of the underlying asset
        private OptionType optionType; // Type of the option (Call or Put)

        // Constructor
        public OptionPricingModel(double underlyingAssetPrice, double strikePrice, double timeToMaturity, double riskFreeRate, double volatility, OptionType type)
        {
            S = underlyingAssetPrice;
            K = strikePrice;
            T = timeToMaturity;
            r = riskFreeRate;
            sigma = volatility;
            optionType = type;
        }

        // European Call Option Pricing
        public double CalculateCallOptionPrice()
        {
            double d1 = (Math.Log(S / K) + (r + 0.5 * sigma * sigma) * T) / (sigma * Math.Sqrt(T));
            double d2 = d1 - sigma * Math.Sqrt(T);
            double callOptionPrice = S * Math.Exp(-r * T) * N(d1) - K * Math.Exp(-r * T) * N(d2);
            return callOptionPrice;
        }

        // European Put Option Pricing
        public double CalculatePutOptionPrice()
        {
            double d1 = (Math.Log(S / K) + (r + 0.5 * sigma * sigma) * T) / (sigma * Math.Sqrt(T));
            double d2 = d1 - sigma * Math.Sqrt(T);
            double putOptionPrice = K * Math.Exp(-r * T) * N(-d2) - S * Math.Exp(-r * T) * N(-d1);
            return putOptionPrice;
        }

        // Cumulative Normal Distribution Function (CDF)
        private double N(double x)
        {
            double t = 1.0 / (1.0 + 0.3275911 * Math.Abs(x));
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;
            double norm = (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t;
            norm = 1 - norm * Math.Exp(-x * x / 2);
            if (x >= 0)
                return norm;
            else
                return 1 - norm;
        }
    }
}
