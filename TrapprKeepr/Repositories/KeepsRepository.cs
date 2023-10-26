namespace TrapprKeepr.Repositories;

public class KeepsRepository
{
    private readonly IDbConnection _kdb;
    public KeepsRepository(IDbConnection kdb)
    {
        _kdb = kdb;
    }
    // STUB Create Keep
    internal Keep Create(Keep keepData)
    {
        string sql = @"
            INSERT INTO keeps
            (name, description, img, creatorId)
            VALUES
            (@Name, @Description, @Img, @CreatorId);

            SELECT
            act.*,
            kee.*
            FROM keeps kee
            JOIN accounts act ON act.id = kee.creatorId
            WHERE kee.id = LAST_INSERT_ID()
            ;";

        Keep newKeep = _kdb.Query<Account, Keep, Keep>(sql, (account, keep) =>
        {
            keep.Creator = account;
            return keep;
        }, keepData).FirstOrDefault();
        return newKeep;
    }
    // STUB Get All Keeps
    internal List<Keep> GetAllKeeps()
    {
        string sql = @"
            SELECT
            kee.*,
            act.*
            FROM keeps kee
            JOIN accounts act ON act.id = kee.creatorId
            ;";

        List<Keep> keeps = _kdb.Query<Keep, Account, Keep>(sql, (keep, account) =>
        {
            keep.Creator = account;
            return keep;
        }).ToList();
        return keeps;
    }

    // STUB Get Keep by Id
    internal Keep GetKeepById(int keepId, string userId)
    {
        string sql = @"
            SELECT
            kee.*,
            act.*
            FROM keeps kee
            JOIN accounts act ON kee.creatorId = act.id
            WHERE kee.id = @keepId
            ;";
        Keep foundKeep = _kdb.Query<Keep, Account, Keep>(sql, (keep, creator) =>
        {
            keep.Creator = creator;
            return keep;
        }, new { keepId }).FirstOrDefault();
        return foundKeep;
    }
    // STUB EDIT Keep
    public void EditKeep(Keep updateData)
    {
        string sql = @"
            UPDATE keeps
            SET
                name = @Name,
                description = @Description,
                img = @Img,
                views = @Views
            WHERE id = @Id
            ;";
        _kdb.Execute(sql, updateData);
    }
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

    //     Keep updatedKeep = _kdb.QueryFirstOrDefault<Keep>(sql, originalKeep);
    //     return updatedKeep;
    // }
    // STUB DELETE Keep
    internal void DeleteKeep(int keepId)
    {
        string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";
        _kdb.Execute(sql, new { keepId });

    }


}
