using Models;
using System.Collections.Generic;

namespace MobileGuestList.Providers
{
    public interface IBaseInformationProvider
    {
        IEnumerable<Contest> GetContestsList(int stationId);

        Contest GetContestById(int contestId);
        
        IEnumerable<Guest> GetGuestList(int contestId, bool forceUpdate = false);
        
        void MarkDistributed(int contestId);
        
        void UpdateGuestState(int contWinId, bool mark);
        
        IEnumerable<Station> GetMobileStationList(int userId);
        
        MobileLoginDetails ChangeStation(int userId, int stationId);
    }
}