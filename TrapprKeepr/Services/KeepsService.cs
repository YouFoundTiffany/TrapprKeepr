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
    // STUB Get Keep by Id - and show all the Keeps in that Keep
    internal Keep GetKeepById(int keepId)
    {
        Keep foundKeep = _krepo.GetKeepById(keepId);
        if (foundKeep == null) throw new Exception($"Unable to find Keep {keepId}");
        return foundKeep;
    }
    // STUB EDIT Keep
    internal Keep EditKeep(int keepId, Keep keepData)
    {
        Keep originalKeep = GetKeepById(keepId);
        originalKeep.Name = keepData.Name ?? originalKeep.Name;
        originalKeep.Description = keepData.Description ?? originalKeep.Description;
        originalKeep.Img = keepData.Img ?? originalKeep.Img;
        originalKeep.Views = keepData.Views originalKeep.Views;
        originalKeep.Kept = keepData.Kept originalKeep.Kept;
        Keep keep = _krepo.EditKeep(originalKeep);
        return keep;
    }
    // STUB DELETE Keep
    internal Keep DeleteKeep(int keepId)
    {
        Keep keep = GetKeepById(keepId);
        _krepo.DeleteKeep(keepId);
        return keep;
    }
}