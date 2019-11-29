using Jtktkj.Station.BLL;
using Jtktkj.Station.IBLL;
using Jtktkj.Station.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jtktkj.Station.WebApi.Controllers
{
    /// <summary>
    /// 控制器：线路
    /// Creator：何明鑫
    /// Date：2019/7/18
    /// </summary>
    public class LineController : ApiController
    {
        private readonly IRouteManager manager = new RouteManager();

        [HttpPost]
        public IHttpActionResult AddLine(Line line)
        {
            return Ok(manager.AddRoute(line));
        }
        [HttpPost]
        public IHttpActionResult EditeLine(Line line)
        {
            return Ok(manager.UpdateRoute(line));
        }
        [HttpGet]
        public IHttpActionResult GetAllLines()
        {
            return Ok(manager.FindAll());
        }
        [HttpGet]
        public IHttpActionResult GetLineByKey(string key)
        {
            return Ok(manager.FindByQueryName(key));
        }
        [HttpGet]
        public IHttpActionResult GetLineById(int id)
        {
            return Ok(manager.FindById(id));
        }
        [HttpPost]
        public IHttpActionResult DelLineById(int id)
        {
            return Ok(manager.DeleteRoute(id));
        }
        [HttpPost]
        public IHttpActionResult AddStation(LineStation station)
        {
            return Ok(manager.AddStation(station));
        }
        [HttpPost] 
        public IHttpActionResult DelStationById(int id)
        {
            return Ok(manager.DeleteStationById(id));
        }
        [HttpPost]
        public IHttpActionResult EditStation(LineStation station)
        {
            return Ok(manager.UpdateStation(station));
        }
    }
}
