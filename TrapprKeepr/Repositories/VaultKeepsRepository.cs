namespace TrapprKeepr.Repositories;

public class VaultKeepsRepository
{
    private readonly IDbConnection _vkdb;
    public VaultKeepsRepository(IDbConnection vkdb)
    {
        _vkdb = vkdb;
    }
    // STUB Create VaultKeeps
    internal VaultKeep Create(VaultKeep vaultkeepData)
    {
        string sql = @"
           INSERT INTO vaultKeeps
           (vaultId, keepId, creatorId)
            VALUES
            (@VaultId, @KeepId, @CreatorId);


            SELECT
            act.*,
            vke.*
            FROM vaultKeeps vke
            JOIN accounts act ON act.id = vke.creatorId
            WHERE vke.id = LAST_INSERT_ID()
            ;";

        VaultKeep newVaultKeep = _vkdb.Query<Account, VaultKeep, VaultKeep>(sql, (account, vaultKeep) =>
        {
            vaultKeep.Creator = account;
            return vaultKeep;
        }, vaultkeepData).FirstOrDefault();
        return newVaultKeep;
    }
    // STUB Get All VaultKeeps
    internal List<VaultKeep> GetAllVaultKeeps()
    {
        string sql = @"
            SELECT
            vke.*,
            act.*
            FROM vaultKeeps vke
            JOIN accounts act ON act.id = vke.creatorId
            ;";

        List<VaultKeep> vaultKeeps = _vkdb.Query<VaultKeep, Account, VaultKeep>(sql, (vaultKeep, account) =>
        {
            vaultKeep.Creator = account;
            return vaultKeep;
        }).ToList();
        return vaultKeeps;
    }
    // STUB Get VaultKeeps by Vault Id VaultKeepsViewModel
    internal List<VaultKeepsViewModel> GetVaultKeepsByVaultId(int vaultId)
    {
        string sql = @"
    SELECT
    kee.*,
    vke.VaultId,
    kee.Id as KeepId,
    kee.CreatorId as ProfileId,
    prof.* -- This selects all columns from Profile
    FROM Keeps kee
    JOIN VaultKeeps vke ON kee.Id = vke.KeepId
    JOIN Profiles prof ON kee.CreatorId = prof.Id
    WHERE vke.VaultId = @VaultId;
    ";

        return _vkdb.Query<VaultKeepsViewModel, Profile, VaultKeepsViewModel>(
            sql,
            (keepModel, profile) =>
            {
                keepModel.Creator = profile;
                return keepModel;
            },
            new { VaultId = vaultId },
            splitOn: "ProfileId").ToList();
    }


    // FIXME GetVaultKeepsByProfileId failing postman for no-auth
    // STUB Get VaultKeep by Id
    internal VaultKeep GetVaultKeepById(int vaultKeepId, string userId)
    {
        string sql = @"
            SELECT
            vke.*,
            act.*
            FROM vaultKeeps vke
            JOIN accounts act ON vke.creatorId = act.id
            WHERE vke.id = @vaultKeepId
            ;";
        VaultKeep foundVaultKeep = _vkdb.Query<VaultKeep, Account, VaultKeep>(sql, (vaultKeep, creator) =>
        {
            vaultKeep.Creator = creator;
            return vaultKeep;
        }, new { vaultKeepId }).FirstOrDefault();
        return foundVaultKeep;
    }
    // STUB EDIT VaultKeep
    // public void EditVaultKeep(VaultKeep updateData)
    // {
    //     string sql = @"
    //         UPDATE vaultKeeps
    //         SET
    //             name = @Name,
    //             description = @Description,
    //             img = @Img
    //         WHERE id = @Id
    //         ;";
    //     _vkdb.Execute(sql, updateData);
    // }
    // STUB EDIT Keep
    // internal Keep EditKeep(Keep originalKeep)
    // {
    //     string sql = @"
    //         UPDATE keeps
    //         SET
    // name = @name,
    // description = @description,
    // img = @img,
    // views = @views,
    // kept = @kept,
    //         WHERE id = @id
    //         LIMIT 1;
    //         SELECT * FROM keeps WHERE id = @id
    //         ;";

    //     Keep updatedKeep = _vkdb.QueryFirstOrDefault<Keep>(sql, originalKeep);
    //     return updatedKeep;
    // }
    // STUB DELETE Keep
    internal void DeleteVaultKeep(int vaultKeepId)
    {
        string sql = "DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1;";
        _vkdb.Execute(sql, new { vaultKeepId });

    }
}
