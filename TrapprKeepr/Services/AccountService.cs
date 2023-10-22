namespace TrapprKeepr.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }
  // STUB Get Account By EMAIL
  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  // STUB GetOrCreateProfile
  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }
  // // STUB Edit Account
  // internal Account Edit(Account editData, string userEmail)
  // {
  //   Account original = GetProfileByEmail(userEmail);
  //   original.Name = editData.Name?.Length > 0 ? editData.Name : original.Name;
  //   original.Picture = editData.Picture?.Length > 0 ? editData.Picture : original.Picture;
  //   original.CoverImg = editData.CoverImg?.Length > 0 ? editData.CoverImg : original.CoverImg;
  //   return _repo.Edit(original);
  // }

  // // STUB Get User Profile
  // public Profile GetProfile(string id)
  // {
  //   return _repo.GetProfile(id);
  // }

  // // STUB Get User Keeps
  // public List<Keep> GetUserKeeps(string id)
  // {
  //   return _repo.GetUserKeeps(id);
  // }

  // STUB Get User Vaults
  public List<Vault> GetUserVaults(string id)
  {
    return _repo.GetUserVaults(id);
  }

}
