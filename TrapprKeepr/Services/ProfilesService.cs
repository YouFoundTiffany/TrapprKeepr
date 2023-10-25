namespace TrapprKeepr.Services;

public class ProfilesService
{
    private readonly ProfilesRepository _prepo;

    public VaultsRepository _vrepo { get; }

    public ProfilesService(ProfilesRepository prepo, VaultsRepository vrepo)
    {
        _prepo = prepo;
        _vrepo = vrepo;
    }
    // STUB GetOrCreateProfile
    internal Account GetOrCreateProfile(Account userInfo)
    {
        Account profile = _prepo.GetById(userInfo.Id);
        if (profile == null)
        {
            return _prepo.Create(userInfo);
        }
        return profile;
    }


    internal Profile GetProfileByEmail(string email)
    {
        return _prepo.GetByEmail(email);
    }

    // STUB Edit Profile
    internal Profile Edit(Profile editprofileData, string userEmail)
    {
        Profile original = GetProfileByEmail(userEmail);
        original.Name = editprofileData.Name?.Length > 0 ? editprofileData.Name : original.Name;
        original.Picture = editprofileData.Picture?.Length > 0 ? editprofileData.Picture : original.Picture;
        original.CoverImg = editprofileData.CoverImg?.Length > 0 ? editprofileData.CoverImg : original.CoverImg;
        return _prepo.Edit(original);
    }

    // STUB Get User Profile
    public Profile GetProfile(string id)
    {
        return _prepo.GetProfile(id);
    }

    // STUB Get User Keeps
    public List<Keep> GetUserKeeps(string id)
    {
        return _prepo.GetUserKeeps(id);
    }

    // FIXME
    // STUB Get User Vaults
    // tifftag filter out private vaults
    // public List<Vault> GetUserVaults(string userId)
    // {
    //     // go get the list of all the vaults that have the same creator id as the profile that is logged in right now
    //     List<Vault> vaults = _prepo.GetUserVaults(userId);
    //     vaults = vaults.FindAll(vault => vault.IsPrivate == false);
    //     return vaults;
    // }
}