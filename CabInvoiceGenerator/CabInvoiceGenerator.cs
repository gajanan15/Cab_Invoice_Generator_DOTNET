// <copyright file="CabInvoiceGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Create Cab Invoice Generator Class.
    /// </summary>
    public class CabInvoiceGenerator
    {
        public static double MINIMUM_COST_PER_KILOMETER = 10.0;
        public static int COST_PER_TIME = 1;
        public static double MINIMUM_FARE = 5.0;
        private RideRepository rideRepository;
        private RideTypeEnum type = new RideTypeEnum();
        private Regex userIDPattern = new Regex(@"^((?=[^@|#|&|%|$]*[@|&|#|%|$][^@|#|&|%|$]*$)*(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9#@$?]{8,})$");

        public CabInvoiceGenerator()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// Create Calculate Fare Method.
        /// </summary>
        /// <param name="rideType"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(RideTypeEnum.RideType rideType, double distance, int time)
        {
            this.SetValue(rideType);
            double premiumTotalFare = (distance * MINIMUM_COST_PER_KILOMETER) + (time * COST_PER_TIME);
            return Math.Max(premiumTotalFare, MINIMUM_FARE);
        }

        public void SetValue(RideTypeEnum.RideType rideType)
        {
            RideTypeEnum ride = this.type.GetRideValue(rideType);
            MINIMUM_COST_PER_KILOMETER = ride.costPerKm;
            COST_PER_TIME = ride.costPerMin;
            MINIMUM_FARE = ride.minimumFare;
        }

        /// <summary>
        /// Create Method For Multiple Ride And Calculate Aggregate Fare.
        /// </summary>
        /// <param name="rideType"></param>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary AddRide(RideTypeEnum.RideType rideType, Ride[] rides)
        {
            double totalFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(rideType, ride.Distance, ride.Time);
            }

            return new InvoiceSummary(rides.Length, totalFare);
        }

        public void AddRide(string userId, Ride[] rides)
        {
            if (this.userIDPattern.IsMatch(userId))
            {
                this.rideRepository.AddRide(userId, rides);
            }
            else
            {
                throw new CustomException("Invalid UserID", CustomException.ExceptionType.INVALID_UERID);
            }
        }

        public InvoiceSummary GetInvoiceSummary(RideTypeEnum.RideType type, string userID)
        {
           return this.AddRide(type, this.rideRepository.GetRides(userID));
        }
    }
}
