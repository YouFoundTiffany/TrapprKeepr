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
    // STUB Get Vault by Id - and show all the Keeps in that Vault
    internal Vault GetVaultById(int vaultId)
    {
        Vault foundVault = _vrepo.GetVaultById(vaultId);
        if (foundVault == null) throw new Exception($"Unable to find vault {vaultId}");
        return foundVault;
    }
    // STUB EDIT VAULT
    internal Vault EditVault(int vaultId, Vault vaultData)
    {
        Vault originalVault = GetVaultById(vaultId);

        originalVault.Name = vaultData.Name ?? originalVault.Name;
        originalVault.Description = vaultData.Description ?? originalVault.Description;
        originalVault.Img = vaultData.Img ?? originalVault.Img;
        originalVault.IsPrivate = vaultData.IsPrivate ?? originalVault.IsPrivate;

        Vault vault = _vrepo.EditVault(originalVault);

        return vault;
    }
    // STUB DELETE VAULT
    internal Vault DeleteVault(int vaultId)
    {
        Vault vault = GetVaultById(vaultId);
        _vrepo.DeleteVault(vaultId);
        return vault;
    }
}