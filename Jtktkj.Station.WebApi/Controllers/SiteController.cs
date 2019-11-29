using Jtktkj.Station.BLL;
using Jtktkj.Station.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Jtktkj.Station.Models;

namespace Jtktkj.Station.WebApi.Controllers
{
    /// <summary>
    /// 控制器：站台
    /// Creator：何明鑫
    /// Date：2019/7/18
    /// </summary>
    public class SiteController : ApiController
    {
        private readonly IStationManager manager = new StationManager();

        [HttpPost]
        public IHttpActionResult AddSite(Site station)
        {
            if (station != null)
            {
                return Ok(manager.AddStation(station));
            }
            return Ok(false);
        }
        [HttpPost]
        public IHttpActionResult EditSite(Site station)
        {
            if (station != null)
            {
                return Ok(manager.UpdateStation(station));
            }
            return Ok(false);
        }
        [HttpGet]
        public IHttpActionResult GetAllSites()
        {
            return Ok(manager.FindAll());
        }
        [HttpGet]
        public IHttpActionResult GetSiteByKey(string key)
        {
            return Ok(manager.FindByQueryName(key));
        }
        [HttpGet]
        public IHttpActionResult GetSiteById(int id)
        {
            return Ok(manager.FindById(id));
        }
        [HttpPost]
        public IHttpActionResult DelSiteById(int id)
        {
            return Ok(manager.DeleteStation(id));
        }
    }
}
