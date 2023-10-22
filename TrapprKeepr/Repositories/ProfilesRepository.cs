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
    // STUB Get User Vaults
    internal List<Vault> GetUserVaults(string id)
    {
        string sql = @"
      SELECT *
      FROM vault
      WHERE creatorId = @id";
        return _db.Query<Vault>(sql, new { id }).ToList();
    }
    // STUB GetById
    internal Account GetById(string id)
    {
        string sql = @"SELECT *
        FROM accounts
        WHERE id = @id";
        return _db.QueryFirstOrDefault<Account>(sql, new { id });
    }
}