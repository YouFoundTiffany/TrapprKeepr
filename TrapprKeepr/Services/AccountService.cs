namespace TrapprKeepr.Services;

public class AccountService
{
  private readonly AccountsRepository _arepo;

  public AccountService(AccountsRepository arepo)
  {
    _arepo = arepo;
  }
  // STUB Get Account By EMAIL
  internal Account GetProfileByEmail(string email)
  {
    return _arepo.GetByEmail(email);
  }

  // STUB GetOrCreateProfile
  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _arepo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _arepo.Create(userInfo);
    }
    return profile;
  }

  // STUB Get User Vaults
  public List<Vault> GetUserVaults(string id)
  {
    return _arepo.GetUserVaults(id);
  }


  // STUB Edit Profile
  internal Account Edit(Account editprofileData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editprofileData.Name?.Length > 0 ? editprofileData.Name : original.Name;
    original.Picture = editprofileData.Picture?.Length > 0 ? editprofileData.Picture : original.Picture;
    original.CoverImg = editprofileData.CoverImg?.Length > 0 ? editprofileData.CoverImg : original.CoverImg;
    return _arepo.Edit(original);
  }

  // STUB Get User Profile
  public Profile GetProfile(string id)
  {
    return _arepo.GetProfile(id);
  }

  // STUB Get User Keeps
  public List<Keep> GetUserKeeps(string id)
  {
    return _arepo.GetUserKeeps(id);
  }



}