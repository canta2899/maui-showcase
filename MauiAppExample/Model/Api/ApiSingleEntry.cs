using System;
namespace MauiAppExample.Model;

public class ApiSingleEntry<T>
{
    public ApiData<T> Data { get; set; }
    public StrapiMetadata Meta { get; set; }
}
