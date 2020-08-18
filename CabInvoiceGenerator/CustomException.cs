// <copyright file="CustomException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    public class CustomException : Exception
    {
        public enum ExceptionType
        {
            INVALID_UERID
        }

        public ExceptionType type;

        public CustomException(string message, ExceptionType type)
            : base(message)
        {
            this.type = type;
        }
    }
}
