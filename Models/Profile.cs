namespace AppRoma.Models;

public class Profile
{
    public Guid ID { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string ?Location { get; set; }
    public string ?Interests { get; set; }
    public ICollection<Like> Likes { get; set; } = [];
    public ICollection<Like> ReceivedLikes { get; set; } = [];
}