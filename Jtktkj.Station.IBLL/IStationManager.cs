using Jtktkj.Station.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.IBLL
{
    /// <summary>
    /// 业务层接口：线路
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public interface IStationManager
    {
        bool AddStation(Site station);
        bool DeleteStation(int id);
        bool UpdateStation(Site station);
        Site FindById(int id);
        IList<Site> FindAll();
        IList<Site> FindByQueryName(string queryName);
    }
}
