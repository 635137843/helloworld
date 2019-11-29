using Jtktkj.Station.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.IBLL
{
    /// <summary>
    /// 业务层接口：站台
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public interface IRouteManager
    {
        bool AddRoute(Line route);
        bool DeleteRoute(int id);
        bool UpdateRoute(Line route);
        IList<Line> FindAll();
        LineInfo FindById(int id);
        IList<Line> FindByQueryName(string queryName);
        bool DeleteStationById(int id);
        bool UpdateStation(LineStation station);
        bool AddStation(LineStation station);
    }
}
