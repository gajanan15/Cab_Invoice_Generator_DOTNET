// <copyright file="CabInvoiceGeneratorTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using NUnit.Framework;
    using CabInvoiceGenerator;

    /// <summary>
    /// Create Test Class.
    /// </summary>
    public class CabInvoiceGeneratorTest
    {
        private CabInvoiceGenerator cabInvoiceGenerator;

        /// <summary>
        /// Craete SetUp Method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }

        /// <summary>
        /// Craete Test For Calculate Total Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// Craete Test For Calculate Minimum Fare.
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, fare);
        }

        /// <summary>
        /// Craete Test For Calculate Aggregate Of Total Fare.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnAggregateTotalFare()
        {
            Ride[] ride = { new Ride(2.0, 5), new Ride(2.0, 5) };
            InvoiceSummary summary = this.cabInvoiceGenerator.AddRide(ride);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}