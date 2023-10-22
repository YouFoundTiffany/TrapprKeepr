namespace TrapprKeepr.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }
  // STUB Get Account By Email
  internal Account GetByEmail(string userEmail)
  {
    string sql = "SELECT * FROM accounts WHERE email = @userEmail";
    return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
  }

  // STUB Get Account By Id
  internal Account GetById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Account>(sql, new { id });
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

  // STUB Edit Account
  internal Account Edit(Account update)
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

  // // STUB Get User Profile
  // internal Profile GetProfile(string id)
  // {
  //   string sql = @"
  //       SELECT *
  //       FROM accounts
  //       WHERE id = @id";
  //   return _db.QueryFirstOrDefault<Profile>(sql, new { id });
  // }
  // // STUB Get User Keeps
  // internal List<Keep> GetUserKeeps(string id)
  // {
  //   string sql = @"
  //     SELECT *
  //     FROM keeps
  //     WHERE creatorId = @id";
  //   return _db.Query<Keep>(sql, new { id }).ToList();
  // }
  // STUB Get User Vaults
  internal List<Vault> GetUserVaults(string id)
  {
    string sql = @"
      SELECT *
      FROM vault
      WHERE creatorId = @id";
    return _db.Query<Vault>(sql, new { id }).ToList();
  }

}

