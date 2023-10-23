namespace TrapprKeepr.Services;
public class VaultKeepsService
{
    private readonly VaultKeepsRepository _vkrepo;
    public VaultKeepsService(VaultKeepsRepository vkrepo)
    {
        _vkrepo = vkrepo;
    }
    // STUB Create VaultKeep
    internal VaultKeep Create(VaultKeep vaultKeepData)
    {
        VaultKeep newVaultKeep = _vkrepo.Create(vaultKeepData);
        return newVaultKeep;
    }
    // STUB Get All VaultKeep
    internal List<VaultKeep> GetAllVaultKeeps()
    {
        List<VaultKeep> vaultKeeps = _vkrepo.GetAllVaultKeeps();
        return vaultKeeps;
    }
    // STUB Get VaultKeep by Vault Id - See in Vault Controller - View Model Continued
    internal List<VaultKeepsViewModel> GetVaultKeepsByVaultId(int vaultId)
    {
        List<VaultKeepsViewModel> myKeeps = _vkrepo.GetVaultKeepsByVaultId(vaultId);
        return myKeeps;
    }

    // STUB Get Keeps by Vault Id - See in Vault Controller
    internal List<Keep> GetKeepsByVaultId(int vaultId)
    {
        List<Keep> keeps = _vkrepo.GetKeepsByVaultId(vaultId);
        return keeps;
    }
    // STUB Get VaultKeep by Id - and show all the Keeps in that Keep
    internal VaultKeep GetVaultKeepById(int vaultKeepId, string userId)
    {
        VaultKeep foundVaultKeep = _vkrepo.GetVaultKeepById(vaultKeepId, userId);
        if (foundVaultKeep == null) throw new Exception($"Unable to find Keep {vaultKeepId}");
        return foundVaultKeep;
    }

    // STUB DELETE VaultKeep
    internal (VaultKeep, string) DeleteVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep originalVaultKeep = this.GetVaultKeepById(vaultKeepId, userId);
        if (originalVaultKeep == null) throw new Exception("Vault Keep Not Found");
        if (originalVaultKeep.CreatorId != userId) throw new Exception("Access Denied: Cannot Delete a Keep You did not Create");

        _vkrepo.DeleteVaultKeep(vaultKeepId);
        return (originalVaultKeep, "Keep successfully deleted.");
    }
}






// In the DeleteVaultKeep method, you're returning a tuple of VaultKeep and a string, but the repository method just deletes without returning the deleted object. You should modify the repository method if you want to return the deleted object or change the return type to just string or void.

