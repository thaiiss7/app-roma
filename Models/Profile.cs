namespace AppRoma.Models;

public class Profile
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public ICollection<Like> Likes { get; set; }
}