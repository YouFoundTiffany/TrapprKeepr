namespace TrapprKeepr.Models;

public class Vault
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public bool? IsPrivate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
}


public class VaultKeepsViewModel : Vault
{
    public int KeepId { get; set; }
    public string ProfileId { get; set; }

}