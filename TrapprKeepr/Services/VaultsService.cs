namespace TrapprKeepr.Services;

public class VaultsService
{
    private readonly VaultsRepository _vrepo;
    public VaultsService(VaultsRepository vrepo)
    {
        _vrepo = vrepo;
    }
}