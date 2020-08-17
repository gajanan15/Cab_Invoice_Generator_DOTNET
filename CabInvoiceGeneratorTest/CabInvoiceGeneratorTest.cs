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
            double fare = this.cabInvoiceGenerator.CalculateFare(RideTypeEnum.RideType.NORMAL, distance, time);
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
            double fare = this.cabInvoiceGenerator.CalculateFare(RideTypeEnum.RideType.NORMAL, distance, time);
            Assert.AreEqual(5, fare);
        }

        /// <summary>
        /// Craete Test For Calculate Aggregate Of Total Fare.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnAggregateTotalFare()
        {
            Ride[] ride = { new Ride(RideTypeEnum.RideType.NORMAL, 2.0, 5), new Ride(RideTypeEnum.RideType.NORMAL, 2.0, 5) };
            InvoiceSummary summary = this.cabInvoiceGenerator.AddRide(RideTypeEnum.RideType.NORMAL, ride);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Create Test To Pass UserId And Ride And Check Invoice Summary.
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_ShouldReturnInvoiceSummary()
        {
            string userID = "abc@g.com";
            Ride[] ride = { new Ride(RideTypeEnum.RideType.NORMAL, 2.0, 5), new Ride(RideTypeEnum.RideType.NORMAL, 2.0, 5) };
            this.cabInvoiceGenerator.AddRide(userID, ride);
            InvoiceSummary summary = this.cabInvoiceGenerator.GetInvoiceSummary(RideTypeEnum.RideType.NORMAL, userID);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 50.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Create Test Premium Type Return Total Fare.
        /// </summary>
        [Test]
        public void GivenPremiumDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = this.cabInvoiceGenerator.CalculateFare(RideTypeEnum.RideType.PREMIUM, distance, time);
            Assert.AreEqual(40, fare);
        }

        /// <summary>
        /// Create Test Premium Type For Less Distance Return Minimum Fare.
        /// </summary>
        [Test]
        public void GivenPremiumLessDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = this.cabInvoiceGenerator.CalculateFare(RideTypeEnum.RideType.PREMIUM, distance, time);
            Assert.AreEqual(20, fare);
        }

        /// <summary>
        /// Create Test Premium Type For Multiple Rides.
        /// </summary>
        [Test]
        public void GivenPremiumMultipleRides_ShouldReturnInvoiceSummary()
        {
            Ride[] ride = { new Ride(RideTypeEnum.RideType.PREMIUM, 2.0, 5), new Ride(RideTypeEnum.RideType.PREMIUM, 0.1, 1) };
            InvoiceSummary summary = this.cabInvoiceGenerator.AddRide(RideTypeEnum.RideType.PREMIUM, ride);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}