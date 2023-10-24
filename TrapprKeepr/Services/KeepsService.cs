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

    // STUB Get Keep by Id - and show all the Vaults that Keep is in?
    internal Keep GetKeepById(int keepId, string userId, bool increaseViews = false)
    {
        // Safety Check
        Keep keep = _krepo.GetKeepById(keepId, userId);
        if (keep == null) throw new Exception($"Unable to find Keep {keepId}");
        if (increaseViews && keep.CreatorId != userId)
        {
            // INCREMENT VIEWS
            this.IncreaseViews(keep);
        }
        return keep;
    }

    internal void IncreaseViews(Keep keep)
    {
        keep.Views++;
        _krepo.EditKeep(keep);
    }

    // STUB EDIT Keep
    internal Keep EditKeep(Keep updateKeepData, int keepId, string userId)
    {
        Keep originalKeep = this.GetKeepById(keepId, userId);
        if (originalKeep == null) throw new Exception("Keep Not Found");
        if (originalKeep.CreatorId != userId) throw new Exception("Access Denied: Cannot Edit a Keep You did not Create");
        originalKeep.Name = updateKeepData.Name ?? originalKeep.Name;
        originalKeep.Description = updateKeepData.Description ?? originalKeep.Description;
        originalKeep.Img = updateKeepData.Img ?? originalKeep.Img;
        // return originalKeep;
        _krepo.EditKeep(originalKeep);
        return originalKeep;
    }
    // STUB DELETE Keep
    internal (Keep, string) DeleteKeep(int keepId, string userId)
    {
        Keep originalKeep = this.GetKeepById(keepId, userId);
        if (originalKeep == null) throw new Exception("Keep Not Found");
        if (originalKeep.CreatorId != userId) throw new Exception("Access Denied: Cannot Delete a Keep You did not Create");

        _krepo.DeleteKeep(keepId);
        return (originalKeep, "Keep successfully deleted.");
    }
}