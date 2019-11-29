using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jtktkj.Station.Models;

namespace Jtktkj.Station.IDAL
{
    /// <summary>
    /// 业务层接口：线路
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public interface IStationService
    {
        bool AddStation(Models.Site station);
        bool DeleteStation(int id);
        bool UpdateStation(Models.Site station);
        Models.Site FindById(int id);
        IList<Site> FindAll();
        IList<Site> FindByQueryName(string queryName);
    }
}
