﻿using System;

namespace Student_Journal_Manager.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException() : base("Conflict occurred.")
        {
        }

        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
