using Jtktkj.Station.DAL;
using Jtktkj.Station.IBLL;
using Jtktkj.Station.IDAL;
using Jtktkj.Station.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.BLL
{
    /// <summary>
    /// 业务类：线路
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public class StationManager : IStationManager
    {
        private readonly IStationService stationService = new StationService();
        public bool AddStation(Site station)
        {
            return stationService.AddStation(station);
        }

        public bool DeleteStation(int id)
        {
            return stationService.DeleteStation(id);
        }

        public IList<Site> FindAll()
        {
            return stationService.FindAll();
        }

        public Site FindById(int id)
        {
            return stationService.FindById(id);
        }

        public IList<Site> FindByQueryName(string queryName)
        {
            return stationService.FindByQueryName(queryName);
        }

        public bool UpdateStation(Site station)
        {
            return stationService.UpdateStation(station);
        }
    }
}
