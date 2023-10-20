namespace TrapprKeepr.Models;

public class VaultKeep
{
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdtedAt { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    // TODO ? OR WHAT VIEW DO I WANT OR NEED ON THE FRONT END?
    // public Keep Keep { get; set; }

}
// Do I need a ViewModel?
// TODO ? OR WHAT VIEW DO I WANT OR NEED ON THE FRONT END?
