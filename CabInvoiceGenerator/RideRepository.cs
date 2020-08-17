// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// Create Class Ride Repository.
    /// </summary>
    public class RideRepository
    {
        private Dictionary<string, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userID, Ride[] ride)
        {
            bool ridesList = this.userRides.ContainsKey(userID);
            if (!ridesList)
            {
                this.userRides.Add(userID, new List<Ride>(ride));
            }
        }

        public Ride[] GetRides(string userID)
        {
            return this.userRides[userID].ToArray();
        }
    }
}
