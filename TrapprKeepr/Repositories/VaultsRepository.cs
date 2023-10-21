namespace TrapprKeepr.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _vdb;
    public VaultsRepository(IDbConnection vdb)
    {
        _vdb = vdb;
    }
    // STUB Create Vault
    internal Vault Create(Vault vaultData)
    {
        string sql = @"
            INSERT INTO vaults
            (name, description, img, creatorId)
            VALUES
            (@Name, @Description, @Img, @CreatorId);

            SELECT
            act.*,
            vau.*
            FROM vaults vau
            JOIN accounts act ON act.id = vau.creatorId
            WHERE vau.id = LAST_INSERT_ID()
            ;";

        Vault newVault = _vdb.Query<Account, Vault, Vault>(sql, (account, vault) =>
        {
            vault.Creator = account;
            return vault;
        }, vaultData).FirstOrDefault();
        return newVault;
    }
    // STUB Get All Vaults
    internal List<Vault> GetAllVaults()
    {
        string sql = @"
            SELECT
            vau.*,
            act.*
            FROM vaults vau
            JOIN accounts act ON act.id = vau.creatorId
            ;";

        List<Vault> vaults = _vdb.Query<Vault, Account, Vault>(sql, (vault, account) =>
        {
            vault.Creator = account;
            return vault;
        }).ToList();
        return vaults;
    }
    // STUB Get Vault by Id
    internal Vault GetVaultById(int vaultId)
    {
        string sql = @"
            SELECT
            vau.*,
            act.*
            FROM vaults vau
            JOIN accounts act ON vau.creatorId = act.id
            WHERE vau.id = @vaultId
            ;";
        Vault foundVault = _vdb.Query<Vault, Account, Vault>(sql, (vault, creator) =>
        {
            vault.Creator = creator;
            return vault;
        }, new { vaultId }).FirstOrDefault();
        return foundVault;
    }
    // STUB EDIT VAULT
    internal Vault EditVault(Vault originalVault)
    {
        string sql = @"
            UPDATE vaults
            SET
            name = @name,
            description = @description,
            img = @img,
            isPrivate = @isPrivate
            WHERE id = @id
            LIMIT 1;
            SELECT * FROM vaults WHERE id = @id
            ;";

        Vault updatedVault = _vdb.QueryFirstOrDefault<Vault>(sql, originalVault);
        return updatedVault;
    }
    // STUB DELETE VAULT
    internal void DeleteVault(int vaultId)
    {
        string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";
        _vdb.Execute(sql, new { vaultId });
    }
}
