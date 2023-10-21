namespace TrapprKeepr.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Vault Create(Vault vaultData)
    {
        string sql = @"
        INSERT INTO vaults
        (name, description, img, isPrivate, creatorId, creator)
        VAULTS
        (@Name, @Description, @Img, @IsPrivate, @CreatorId, @Creator)

        SELECT
        act.*,
        vau.*
        FROM vaults vau
        JOIN accounts act ON act.id = vau.creatorId
        WHERE vau.id = LAST_INSERT_ID()
        ;";

        Vault newVault = _db.Query<Account, Vault, Vault>(sql, (account, vault) =>
        {

            vault.Creator = account;
            return vault;
        }, vaultData).FirstOrDefault();
        return newVault;
    }
}
