using System;
namespace MauiAppExample.Model;

public class Post
{
    public string Title { get; set; }
    public string FullText { get; set; }
    public ApiSingleEntry<Asset> Asset { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime PublishedAt { get; set; }
}

