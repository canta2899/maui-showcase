namespace MauiAppExample.Model;

public class ApiMultiEntry<T>
{
    public IEnumerable<ApiData<T>> Data { get; set; }
    public StrapiMetadata Meta { get; set; }
}

