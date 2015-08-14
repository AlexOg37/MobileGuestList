using Models;
using System.Collections.Generic;

namespace MobileGuestList.Providers
{
    public interface IBaseInformationProvider
    {
        IEnumerable<Contest> GetContestsList(int stationId);

        Contest GetContestById(int contestId);

        IEnumerable<Guest> GetGuestList(int contestId, bool bForceUpdate = false);

        void MarkDistributed(int contestId);

        void UpdateGuestState(int contWinId, bool bMark);

        IEnumerable<Station> GetMobileStationList(int useerId);

        MobileLoginDetails ChangeStation(int userId, int stationId);
    }
}