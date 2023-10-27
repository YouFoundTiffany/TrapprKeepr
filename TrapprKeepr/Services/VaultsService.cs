// VAULTS SERVICE
namespace TrapprKeepr.Services;
public class VaultsService
{
    private readonly VaultsRepository _vrepo;
    public VaultsService(VaultsRepository vrepo)
    {
        _vrepo = vrepo;
    }
    // STUB Create Vault
    internal Vault Create(Vault vaultData)
    {
        Vault newVault = _vrepo.Create(vaultData);
        return newVault;
    }


    // STUB EDIT Vault
    internal Vault EditVault(Vault updateVaultData, int vaultId, string userId)
    {
        Vault originalVault = this.GetVaultById(vaultId, userId);
        if (originalVault == null) throw new Exception("Vault Not Found");
        if (originalVault.CreatorId != userId) throw new Exception("Access Denied: Cannot Edit a Vault You did not Create");
        originalVault.Name = updateVaultData.Name ?? originalVault.Name;
        originalVault.Description = updateVaultData.Description ?? originalVault.Description;
        originalVault.Img = updateVaultData.Img ?? originalVault.Img;
        // return originalVault;
        _vrepo.EditVault(originalVault);
        return originalVault;
    }
    // STUB DELETE VAULT
    internal (Vault, string) DeleteVault(int vaultId, string userId)
    {
        Vault originalVault = this.GetVaultById(vaultId, userId);
        if (originalVault == null) throw new Exception("Vault Not Found");
        if (originalVault.CreatorId != userId) throw new Exception("Access Denied: Cannot Delete a Vault You did not Create");

        _vrepo.DeleteVault(vaultId);
        return (originalVault, "Vault successfully deleted.");
    }







    // ❤️‍🔥❤️‍🔥 SACRED! OG CODE! ❤️‍🔥❤️‍🔥
    //STUB GetVaultById GET A SINGLE VAULT BUT IT'S ID - Keep this copy of Original Code So I can rever back if needed
    internal Vault GetVaultById(int vaultId, string userId)
    {
        Vault vault = _vrepo.GetVaultById(vaultId);
        if (vault == null) throw new Exception("Unable to find Vault ${vaultId}");
        if (vault.IsPrivate == true && vault.CreatorId != userId) throw new Exception("${vault.Name} is not yours!");
        return vault;
    }
    // ❤️‍🔥❤️‍🔥 SACRED! OG CODE! ❤️‍🔥❤️‍🔥
    // WE WANT VAULTS   ✨ FOR PROFILES!!!!!!!!- Keep this copy of Original Code So I can rever back if needed
    // STUB Get LIST OF ALL A user's vaults using their profile/account ID :D working w SD
    // SO LONG AS THEY ARE NOT PRIVATED  - Keep this copy of Original Code So I can rever back if needed
    internal List<Vault> GetVaultsByProfileId(string profileId, string userId)
    {
        List<Vault> vaults = _vrepo.GetVaultsByProfileId(profileId);
        vaults = vaults.FindAll(vault => vault.IsPrivate == false || vault.CreatorId == userId);
        return vaults;
    }

    // WE WANT VAULTS   ✨   FOR ACCOUNTSSSS!! MY VAULTS
    //STUB Get LIST OF ALL A user's vaults using their profile/account ID :D working w SD
    // SO LONG AS THEY ARE NOT PRIVATED
    internal List<Vault> GetVaultsByAccountId(string accountId)
    {
        List<Vault> myVaults = _vrepo.GetVaultsByAccountId(accountId);

        //    DO NOT need this as we are interacting at the ACcount Level :D
        // myVaults = myVaults.FindAll(vault => vault.IsPrivate == false || vault.CreatorId == accountId);

        return myVaults;

    }
}
