namespace TrapprKeepr.Services;
public class KeepsService
{
    private readonly KeepsRepository _krepo;
    public KeepsService(KeepsRepository krepo)
    {
        _krepo = krepo;
    }
    // STUB Create Keep
    internal Keep Create(Keep keepData)
    {
        Keep newKeep = _krepo.Create(keepData);
        return newKeep;
    }
    // STUB Get All Keep
    internal List<Keep> GetAllKeeps()
    {
        List<Keep> keeps = _krepo.GetAllKeeps();
        return keeps;
    }
    // STUB Get Keep by Album Id - See in Album Controller
    internal List<Keep> GetKeepsByAlbumId(int albumId)
    {
        List<Keep> keeps = _krepo.GetKeepsByVaultId(albumId);
        return keeps;
    }
    // STUB Get Keep by Id - and show all the Keeps in that Keep
    internal Keep GetKeepById(int keepId, string userId)
    {
        Keep foundKeep = _krepo.GetKeepById(keepId, userId);
        if (foundKeep == null) throw new Exception($"Unable to find Keep {keepId}");
        return foundKeep;
    }

    //    // STUB EDIT Keep
    // internal Keep EditKeep(int keepId, Keep keepData)
    // {
    //     Keep originalKeep = GetKeepById(keepId);
    //     originalKeep.Name = keepData.Name ?? originalKeep.Name;
    //     originalKeep.Description = keepData.Description ?? originalKeep.Description;
    //     originalKeep.Img = keepData.Img ?? originalKeep.Img;
    //     Keep keep = _krepo.EditKeep(originalKeep);
    //     return keep;

    // STUB EDIT Keep
    internal Keep EditKeep(Keep updateKeepData, int keepId, string userId)
    {
        Keep originalKeep = this.GetKeepById(keepId, userId);
        if (originalKeep.CreatorId != userId) throw new Exception("Access Denied: Cannot Edit a Keep You did not Create");
        originalKeep.Name = updateKeepData.Name ?? originalKeep.Name;
        originalKeep.Description = updateKeepData.Description ?? originalKeep.Description;
        originalKeep.Img = updateKeepData.Img ?? originalKeep.Img;
        return originalKeep;
    }
    // STUB DELETE Keep
    internal Keep DeleteKeep(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId, userId);
        _krepo.DeleteKeep(keepId);
        return keep;
    }
}