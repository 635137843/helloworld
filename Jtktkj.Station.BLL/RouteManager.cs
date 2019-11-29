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
    /// 业务类：站台
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public class RouteManager : IRouteManager
    {
        private IRouteService routeService = new RouteService();
        public bool AddRoute(Line route)
        {
            return routeService.AddRoute(route);
        }

        public bool AddStation(LineStation station)
        {
            return routeService.AddStation(station);
        }

        public bool DeleteRoute(int id)
        {
            return routeService.DeleteRoute(id);
        }

        public bool DeleteStationById(int id)
        {
            return routeService.DeleteStationById(id);
        }

        public IList<Line> FindAll()
        {
            return routeService.FindAll();
        }

        public LineInfo FindById(int id)
        {
            return routeService.FindById(id);
        }

        public IList<Line> FindByQueryName(string queryName)
        {
            return routeService.FindByQueryName(queryName);
        }

        public bool UpdateRoute(Line route)
        {
            return routeService.UpdateRoute(route);
        }

        public bool UpdateStation(LineStation station)
        {
            return routeService.UpdateStation(station);
        }
    }
}
