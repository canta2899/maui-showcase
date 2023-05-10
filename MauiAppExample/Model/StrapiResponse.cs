namespace MauiAppExample.Model;

public class StrapiResponse<T>
{
    public IEnumerable<StrapiData<T>> Data { get; set; }
    public StrapiMetadata Meta { get; set; }
}

