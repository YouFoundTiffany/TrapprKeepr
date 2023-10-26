namespace TrapprKeepr.Repositories;

public class ProfilesRepository
{
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
        _db = db;
    }


    // STUB Create Account :Profile
    internal Account Create(Account newAccount)
    {
        string sql = @"
            INSERT INTO accounts
              (name, picture, email, id, coverImg)
            VALUES
              (@Name, @Picture, @Email, @Id, @CoverImg)";
        _db.Execute(sql, newAccount);
        return newAccount;
    }

    // STUB Get User Profile
    internal Profile GetProfile(string id)
    {
        string sql = @"
        SELECT *
        FROM accounts
        WHERE id = @id";
        return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    // STUB Get Profile By Email
    internal Profile GetByEmail(string userEmail)
    {
        string sql = "SELECT * FROM accounts WHERE email = @userEmail";
        return _db.QueryFirstOrDefault<Profile>(sql, new { userEmail });
    }

    // STUB Edit Profile
    internal Profile Edit(Profile update)
    {
        string sql = @"
            UPDATE accounts
            SET
              name = @Name,
              picture = @Picture
              coverImg = @CoverImg
            WHERE id = @Id;";
        _db.Execute(sql, update);
        return update;
    }
    // STUB Get User Keeps
    internal List<Keep> GetUserKeeps(string id)
    {
        string sql = @"
      SELECT *
      FROM keeps
      WHERE creatorId = @id";
        return _db.Query<Keep>(sql, new { id }).ToList();
    }

 // FIXME


    // STUB Get User Vaults
    internal List<Vault> GetUserVaults(int vaultId, string userId)
    {
        string sql = @"
            SELECT

            FROM vault
            WHERE creatorId = @id";
        return _db.Query<Vault>(sql, new { userId }).ToList();
    }








    // // STUB GetById Get the Account info by the Logged in Account Holder Id
    // // FIXME But right now I am joining the Keeps table!?
    //  internal Account GetById(int keepId, string userId)
    // {
    //     string sql = @"
    //     SELECT *
    //     kee.*,
    //     act.*
    //     FROM accounts act ON kee.creatorId = act.id
    //     WHERE kee.id = @keepId
    //      ;";
    //      Keep foundKeep = _db.Query<Keep, Account, Keep>(sql, (keep, creator)=>
    //      {
    //         keep.Creator = creator;
    //         return keep;
    //      }, new {keepId, userId}).FirstOrDefault();
    //    return foundKeep;
    // }
}