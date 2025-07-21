namespace AppRoma.Models;

public class Like
{
    public Guid ID { get; set; }
    public Guid LikedProfileID { get; set; }
    public Guid LikedByProfielID { get; set; }

    public Profile LikedProfiles { get; set; }
    public Profile LikedByProfiles { get; set; }
}