using Jtktkj.Station.IDAL;
using Jtktkj.Station.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.DAL
{
    /// <summary>
    /// 持久类：线路
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public class StationService : IStationService
    {
        /// <summary>
        /// 新增站点
        /// </summary>
        /// <param name="station">站点</param>
        /// <returns>是否成功</returns>
        public bool AddStation(Site station)
        {
            string sql = "insert into site(code,name,lng,lat,describe,remarks) " +
                    "values(@code,@name,@lng,@lat,@describe,@remarks)";
            var result = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@code", station.code),
                new SqlParameter("@name", station.name),
                new SqlParameter("@lng", station.lng),
                new SqlParameter("@lat", station.lat),
                new SqlParameter("@describe", station.describe),
                new SqlParameter("@remarks", station.remarks)
            });
            return result > 0 ? true : false;
        }
        /// <summary>
        /// 删除站点
        /// </summary>
        /// <param name="id">站点id</param>
        /// <returns>是否成功</returns>
        public bool DeleteStation(int id)
        {
            string sql = "delete from site where id = @id";
            var result = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@id", id)
            });
            return result > 0 ? true : false;
        }
        /// <summary>
        /// 修改站点
        /// </summary>
        /// <param name="station">站点</param>
        /// <returns>是否成功</returns>
        public bool UpdateStation(Site station)
        {
            string sql = "update site " +
                    "set code=@code,name=@name,lng=@lng,lat=@lat," +
                        "describe=@describe,remarks=@remarks " +
                    "where id=@id";
            var result = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@code", station.code),
                new SqlParameter("@name", station.name),
                new SqlParameter("@lng", station.lng),
                new SqlParameter("@lat", station.lat),
                new SqlParameter("@describe", station.describe),
                new SqlParameter("@remarks", station.remarks),
                new SqlParameter("@id", station.id)
            });
            return result > 0 ? true : false;
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns>站点集合</returns>
        public IList<Site> FindAll()
        {
            IList<Site> sites = new List<Site>();
            string sql = "select * from site";
            DataTable result = SqlHelper.ExecuteDataTable(sql);
            if (result != null)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    Site entity = new Site
                    {
                        id = (int)result.Rows[i]["id"],
                        code = result.Rows[i]["code"].ToString(),
                        name = result.Rows[i]["name"].ToString(),
                        lng = (double)result.Rows[i]["lng"],
                        lat = (double)result.Rows[i]["lat"],
                        describe = result.Rows[i]["describe"].ToString(),
                        remarks = result.Rows[i]["remarks"].ToString()
                    };
                    sites.Add(entity);
                }
                return sites;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据id查找站点
        /// </summary>
        /// <param name="id">站点id</param>
        /// <returns>站点</returns>
        public Site FindById(int id)
        {
            string sql = "select * from site where id=" + id;
            DataTable result = SqlHelper.ExecuteDataTable(sql);
            if (result != null)
            {
                Site entity = new Site
                {
                    id = (int)result.Rows[0]["id"],
                    code = result.Rows[0]["code"].ToString(),
                    name = result.Rows[0]["name"].ToString(),
                    lng = (double)result.Rows[0]["lng"],
                    lat = (double)result.Rows[0]["lat"],
                    describe = result.Rows[0]["describe"].ToString(),
                    remarks = result.Rows[0]["remarks"].ToString()
                };
                return entity;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 模糊查询站点
        /// </summary>
        /// <param name="queryName">查询条件</param>
        /// <returns>符合条件的集合</returns>
        public IList<Site> FindByQueryName(string queryName)
        {
            IList<Site> sites = new List<Site>();
            string sql = "select * from site" +
                    " where name like '%" + queryName + "%' or code like '%" + queryName + "%' ";
            DataTable result = SqlHelper.ExecuteDataTable(sql);
            if (result != null)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    Site entity = new Site
                    {
                        id = (int)result.Rows[i]["id"],
                        code = result.Rows[i]["code"].ToString(),
                        name = result.Rows[i]["name"].ToString(),
                        lng = (double)result.Rows[i]["lng"],
                        lat = (double)result.Rows[i]["lat"],
                        describe = result.Rows[i]["describe"].ToString(),
                        remarks = result.Rows[i]["remarks"].ToString()
                    };
                    sites.Add(entity);
                }
                return sites;
            }
            else
            {
                return null;
            }
        }
    }
}
