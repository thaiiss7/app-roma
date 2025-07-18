namespace AppRoma.Models;

public class Like
{
    public bool Liked { get; set; }
    public ICollection<Profile> Profiles { get; set; }
}