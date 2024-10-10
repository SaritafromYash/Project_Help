using System;

namespace dotnetapp.Exceptions
{
public class YogaClassBookingException : Exception
{
    public YogaClassBookingException(string message) : base(message)
    {
    }
}
}