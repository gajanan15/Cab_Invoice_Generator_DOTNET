// <copyright file="CabInvoiceGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Create Cab Invoice Generator Class.
    /// </summary>
    public class CabInvoiceGenerator
    {
        private static readonly double MINIMUMCOSTPERKILOMETER = 10.0;
        private static readonly int COSTPERTIME = 1;
        private static readonly double MINIMUMFARE = 5.0;

        /// <summary>
        /// Create Calculate Fare Method.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double premiumTotalFare = (distance * MINIMUMCOSTPERKILOMETER) + (time * COSTPERTIME);
            return Math.Max(premiumTotalFare, MINIMUMFARE);
        }
    }
}
