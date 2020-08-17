// <copyright file="RideTypeEnum.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    public class RideTypeEnum
    {
        public double costPerKm;
        public int costPerMin;
        public double minimumFare;

        public enum RideType
        {
            NORMAL,
            PREMIUM
        }

        public RideTypeEnum()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RideTypeEnum"/> class.
        /// </summary>
        /// <param name="costPerKm"></param>
        /// <param name="costPerMin"></param>
        /// <param name="minimumFare"></param>
        public RideTypeEnum(double costPerKm, int costPerMin, double minimumFare)
        {
            this.costPerKm = costPerKm;
            this.costPerMin = costPerMin;
            this.minimumFare = minimumFare;
        }

        public RideTypeEnum GetRideValue(RideType rideType)
        {
            if (rideType.Equals(RideType.NORMAL))
            {
                return new RideTypeEnum(10, 1, 5);
            }

            if (rideType.Equals(RideType.PREMIUM))
            {
                return new RideTypeEnum(15, 2, 20);
            }
            else
            {
                return null;
            }
        }
    }
}
