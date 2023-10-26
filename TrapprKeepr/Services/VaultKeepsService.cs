namespace TrapprKeepr.Services;
public class VaultKeepsService
{
    private readonly VaultKeepsRepository _vkRepo;
    private readonly VaultsService _vService;
    public VaultKeepsService(VaultKeepsRepository vkRepo, VaultsService vService)

    {
        _vkRepo = vkRepo;
        _vService = vService;
    }
    // STUB Create VaultKeep
    internal VaultKeep Create(VaultKeep vaultKeepData, string userId)
    {

        Vault vault = _vService.GetVaultById(vaultKeepData.VaultId, userId);

        if (vaultKeepData.CreatorId != vault.CreatorId) throw new Exception("Access Denied: You don't own ${vaultId}");
        VaultKeep newVaultKeep = _vkRepo.Create(vaultKeepData);
        return newVaultKeep;
    }
    // STUB Get All VaultKeep
    internal List<VaultKeep> GetAllVaultKeeps()
    {
        List<VaultKeep> vaultKeeps = _vkRepo.GetAllVaultKeeps();
        return vaultKeeps;
    }

    // STUB Get VaultKeep by Vault Id - See in Vault Controller - View Model Continued
    internal List<VaultKeepsViewModel> GetVaultKeepsByVaultId(int vaultId, string userId)
    {
        _vService.GetVaultById(vaultId, userId);
        List<VaultKeepsViewModel> myKeeps = _vkRepo.GetVaultKeepsByVaultId(vaultId);
        return myKeeps;
    }


    // STUB Get VaultKeep by Id - and show all the Keeps in that Keep
    internal VaultKeep GetVaultKeepById(int vaultKeepId, string userId)
    {
        VaultKeep foundVaultKeep = _vkRepo.GetVaultKeepById(vaultKeepId, userId);
        if (foundVaultKeep == null) throw new Exception($"Unable to find Keep {vaultKeepId}");
        return foundVaultKeep;
    }

    // STUB DELETE VaultKeep
    internal (VaultKeep, string) DeleteVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep originalVaultKeep = this.GetVaultKeepById(vaultKeepId, userId);
        if (originalVaultKeep == null) throw new Exception("Vault Keep Not Found");
        if (originalVaultKeep.CreatorId != userId) throw new Exception("Access Denied: Cannot Delete a Keep You did not Create");

        _vkRepo.DeleteVaultKeep(vaultKeepId);
        return (originalVaultKeep, "Keep successfully deleted.");
    }
}






// In the DeleteVaultKeep method, you're returning a tuple of VaultKeep and a string, but the repository method just deletes without returning the deleted object. You should modify the repository method if you want to return the deleted object or change the return type to just string or void.

