﻿using System;

namespace InternshipAuthenticationService.Models.Exceptions
{
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException()
        {
        }
        public InvalidRoleException(string message)
            : base(message)
        {
        }

        public InvalidRoleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
