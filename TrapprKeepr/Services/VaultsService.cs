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
    // STUB Get All Vault
    internal List<Vault> GetAllVaults()
    {
        List<Vault> vaults = _vrepo.GetAllVaults();
        return vaults;
    }
    // STUB Get Vault by Id
    public Vault GetVaultById(int vaultId, string userId)
    {
        Vault vault = _vrepo.GetVaultById(vaultId, userId);
        if (vault == null) throw new Exception($"Unable to find Vault {vaultId}");
        if (vault.IsPrivate == true && vault.CreatorId != userId) throw new Exception($"{vault.Name} is Private");

        return vault;

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
}