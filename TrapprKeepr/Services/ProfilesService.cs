namespace TrapprKeepr.Services;

public class ProfilesService
{
    private readonly ProfilesRepository _prepo;

    public VaultsRepository _vrepo { get; }
    public KeepsRepository _krepo { get; }

    public ProfilesService(ProfilesRepository prepo, VaultsRepository vrepo, KeepsRepository krepo)
    {
        _prepo = prepo;
        _vrepo = vrepo;
        _krepo = krepo;
    }


    // // STUB GetOrCreateProfile
    // ALREADY HAVE THIS IN THE ACCOUNT SERVICE PER TEMPLATE CREATION
    // internal Account GetOrCreateProfile(Account userInfo)
    // {
    //     Account profile = _prepo.GetById(userInfo.Id);
    //     if (profile == null)
    //     {
    //         return _prepo.Create(userInfo);
    //     }
    //     return profile;
    // }


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

    // STUB Get User Vaults GetVaultsByProfileId
    // MAYBE REMOVE? THIS DOESN'T FLOW THROUGH THE PROFILES SERVICE ANYMORE, IT IS IN VAULTS SERV AND REPO
    // public List<Vault> GetVaultsByProfileId(string userId, string requesterId = null)
    // {
    //     List<Vault> vaults = _prepo.GetVaultsByProfileId(userId);

    //     if (requesterId != null && requesterId != userId)
    //     {
    //         vaults = vaults.FindAll(vault => vault.IsPrivate == false);
    //     }
    //     return vaults;
    // }


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