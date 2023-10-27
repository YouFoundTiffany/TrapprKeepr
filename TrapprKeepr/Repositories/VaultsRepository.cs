// VAULTS REPOSITORY
namespace TrapprKeepr.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _vdb;
    public VaultsRepository(IDbConnection vdb)
    {
        _vdb = vdb;
    }
    // STUB Create Vault
    // NOTE model of bool should have default, and you must also include in your sql so that in case of an unauthorized user is trying to make a vault.
    internal Vault Create(Vault vaultData)
    {
        string sql = @"
            INSERT INTO vaults
            (name, description, img, creatorId, isPrivate)
            VALUES
            (@Name, @Description, @Img, @CreatorId, @isPrivate);

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



    // ⭐⭐AUTO-INCREMENTING VIEWS and KEPTS COUNTS⭐⭐
    // public List<Vault> Get()
    // {
    //     string sql = @"
    //    SELECT
    //         vaults.*,
    //         COUNT(vaultkeeps.id) AS keepCount,
    //         accounts.*
    //     FROM vaults
    //     LEFT JOIN vaultkeeps ON vaultkeeps.vaultId = vaults.id
    //     JOIN accounts ON accounts.id = vaults.creatorId
    //     GROUP BY (vaults.id)
    //     ORDER BY (vaults.visits) DESC
    //     ;";

    //     List<Vault> vaults = _vdb.Query<Vault, Account, Vault>(sql, (vault, account) =>
    //     {
    //         vault.Creator = account;
    //         return vault;
    //     }).ToList();
    //     return vaults;
}
// ⭐⭐AUTO-INCREMENTING VIEWS and KEPTS COUNTS⭐⭐
// public Vault GetVaultsByProfileId(int id)
// {
//     string sql = @"
//     SELECT
//         vaults.*,
//         COUNT(vaultkeeps.id) AS keepCount,
//         accounts.*
//     FROM vaults
//     JOIN accounts ON accounts.id = vaults.creatorId
//     LEFT JOIN vaultkeeps ON vaultkeeps.vaultId = vaults.id
//     WHERE vaults.id = @id
//     GROUP BY (vaults.id)
//     ;";
//     Vault vault = _vdb.Query<Vault, Account, Vault>(sql, (vault, account) =>
//     {
//         vault.Creator = account;
//         return vault;
//     }, new { id }).FirstOrDefault();
//     return vault;
// }






// ❤️‍🔥❤️‍🔥 SACRED! OG CODE! ❤️‍🔥❤️‍🔥
// // STUB Get All Vaults - Keep this copy of Original Code So I can rever back if needed
internal List<Vault> GetAllVaults(string userId)
{
    string sql = @"
        SELECT
        vau.*,
        act.*
        FROM vaults vau
        JOIN accounts act ON act.id = vau.creatorId
        WHERE vau.isPrivate = 0 OR (vau.isPrivate = 1 AND vau.creatorId = @userId)
        ;";

    return _vdb.Query<Vault, Account, Vault>(sql, (vault, account) =>
    {
        vault.Creator = account;
        return vault;
    }, new { userId }).ToList();
}

// STUB Get All Keeps - Keep this copy of Original Code So I can rever back if needed

// ❤️‍🔥❤️‍🔥 SACRED! OG CODE! ❤️‍🔥❤️‍🔥
// STUB Get Vault by Id -- Keep this copy of Original Code So I can rever back if needed
internal List<Vault> GetVaultsByProfileId(string profileId)
{
    string sql = @"
    SELECT
    vau.*,
    act.*
    FROM vaults vau
    JOIN accounts act ON vau.creatorId = act.id
    WHERE act.id = @profileId
    ;";
    List<Vault> vaults = _vdb.Query<Vault, Account, Vault>(sql, (vault, account) =>
  {
      vault.Creator = account;
      return vault;
  }, new { profileId }).ToList();
    return vaults;
}






// ACCOUNTS!!!! GET ALL VAULTS FOR ACCOUNTS    -MY VAULTS
internal List<Vault> GetVaultsByAccountId(string accountId)
{
    string sql = @"
        SELECT
        vau.*,
        act.*
        FROM vaults vau
        JOIN accounts act ON vau.creatorId = act.id
        WHERE act.id = @accountId
        ;";


    List<Vault> vaults = _vdb.Query<Vault, Account, Vault>(sql, (vaults, account) =>
     {
         vaults.Creator = account;
         return vaults;
     }, new { accountId }).ToList();
    return vaults;
}


//   THIS IS FOR A SINGLUAR VAULT FOR A PARTICULAR USER
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



// STUB EDIT Vault
public void EditVault(Vault updateData)
{
    string sql = @"
            UPDATE vaults
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @isPrivate
            WHERE id = @Id
            ;";
    _vdb.Execute(sql, updateData);
}

// STUB DELETE VAULT
internal void DeleteVault(int vaultId)
{
    string sql = @"
        DELETE
        FROM vaults
        WHERE id = @vaultId
        LIMIT 1
        ;";
    _vdb.Execute(sql, new { vaultId });
}
}
