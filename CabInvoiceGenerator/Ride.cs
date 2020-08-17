// <copyright file="Ride.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Create Class Ride.
    /// </summary>
    public class Ride
    {
        public RideTypeEnum.RideType rideType;
        public double Distance;
        public int Time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// Create Constructor.
        /// </summary>
        /// <param name="rideType"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(RideTypeEnum.RideType rideType, double distance, int time)
        {
            this.rideType = rideType;
            this.Distance = distance;
            this.Time = time;
        }
    }
}
