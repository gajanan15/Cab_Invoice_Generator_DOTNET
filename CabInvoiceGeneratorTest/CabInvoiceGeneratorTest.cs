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
            Assert.AreEqual(5.0d, fare);
        }
    }
}