namespace TrapprKeepr.Services;

public class ProfilesService
{
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
        _repo = repo;
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


    internal Profile GetProfileByEmail(string email)
    {
        return _repo.GetByEmail(email);
    }

    // STUB Edit Profile
    internal Profile Edit(Profile editprofileData, string userEmail)
    {
        Profile original = GetProfileByEmail(userEmail);
        original.Name = editprofileData.Name?.Length > 0 ? editprofileData.Name : original.Name;
        original.Picture = editprofileData.Picture?.Length > 0 ? editprofileData.Picture : original.Picture;
        original.CoverImg = editprofileData.CoverImg?.Length > 0 ? editprofileData.CoverImg : original.CoverImg;
        return _repo.Edit(original);
    }

    // STUB Get User Profile
    public Profile GetProfile(string id)
    {
        return _repo.GetProfile(id);
    }

    // STUB Get User Keeps
    public List<Keep> GetUserKeeps(string id)
    {
        return _repo.GetUserKeeps(id);
    }

    // STUB Get User Vaults
    public List<Vault> GetUserVaults(string id)
    {
        return _repo.GetUserVaults(id);
    }
}