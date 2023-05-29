using System;
namespace MauiAppExample.Exceptions;

public class SerializerException : Exception
{
    public SerializerException(string message, Exception inner) : base(message, inner)
    {
    }
}

