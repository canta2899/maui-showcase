using System;
namespace MauiAppExample.Data;

public class SerializerException : Exception
{
    public SerializerException(string message, Exception inner) : base(message, inner)
    {
    }
}

