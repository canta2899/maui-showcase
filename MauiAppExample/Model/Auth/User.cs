namespace MauiAppExample.Model.Auth;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Provider { get; set; }

    public bool Confirmed { get; set; }

    public bool Blocked { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}