using PASTORALISPROJECTNEW.Models;
using PASTORALISPROJECTNEW.RequestModels;

namespace PASTORALISPROJECTNEW.Repository
{
    public interface IPastorRepository
    {
        IEnumerable<Pastor> GetAllPastors();
        IEnumerable<Slot> GetAllAvailableSlotsOfAParticularPastorById(int id);
        Pastor GetPastorById(int id);
        List<Pastor> GetAllAavailablePastors();
        String SetDurationForSlotByPastorId(int id, int duration);
        String SetAvailbilityForSlotsByPastorId(int id, DateOnly date ,String startTime, String endtime, bool isAvailble);
        string ChnagePasswordForPastor(int id , ChangePassword passmodel);
    }
    
}
