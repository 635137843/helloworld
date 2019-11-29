using Jtktkj.Station.IBLL;
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
    /// 持久类：站台
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public class RouteService : IRouteService
    {
        /// <summary>
        /// 添加线路
        /// </summary>
        /// <param name="route">路线</param>
        /// <returns>是否成功</returns>
        public bool AddRoute(Line route)
        {
            string sql = "insert into line(code,name,remarks) values(@code,@name,@remarks)";
            var result = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@code", route.code),
                new SqlParameter("@name", route.name),
                new SqlParameter("@remarks", route.remarks) });
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 添加线路站点
        /// </summary>
        /// <param name="station">线路站点</param>
        /// <returns>是否成功</returns>
        public bool AddStation(LineStation station)
        {
            string sql = "insert into linestation(no,name,stationName,lng,lat,type,lineId) " +
                    "values(@no,@name,@stationName,@lng,@lat,@type,@lineId)";
            var result = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@no", station.no),
                new SqlParameter("@name", station.name),
                new SqlParameter("@stationName", station.stationName),
                new SqlParameter("@lng", station.lng),
                new SqlParameter("@lat", station.lat),
                new SqlParameter("@type", station.type),
                new SqlParameter("@lineId", station.lineId)});
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 删除线路
        /// </summary>
        /// <param name="id">线路id</param>
        /// <returns>是否成功</returns>
        public bool DeleteRoute(int id)
        {
            string sql = "delete from line where id = @id";
            var resultLine = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@id", id) });
            sql = "delete from linestation where lineid = @id";
            var resultSite = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@id", id) });
            return (resultLine > 0 ? true : false)&& (resultSite > 0 ? true : false);
        }

        /// <summary>
        /// 删除线路站点
        /// </summary>
        /// <param name="id">线路站点id</param>
        /// <returns>是否成功</returns>
        public bool DeleteStationById(int id)
        {
            string sql = "delete from linestation where id = @id";
            var result = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@id", id) });
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 查找全部线路
        /// </summary>
        /// <returns>线路集合</returns>
        public IList<Line> FindAll()
        {
            IList<Line> lines = new List<Line>();
            string sql = "select * from line";
            DataTable result = SqlHelper.ExecuteDataTable(sql);
            if (result != null)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    Line entity = new Line
                    {
                        id = (int)result.Rows[i]["id"],
                        code = result.Rows[i]["code"].ToString(),
                        name = result.Rows[i]["name"].ToString(),
                        remarks = result.Rows[i]["remarks"].ToString()
                    };
                    lines.Add(entity);
                }
                return lines;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据id查找线路信息
        /// </summary>
        /// <param name="id">线路id</param>
        /// <returns>线路信息</returns>
        public LineInfo FindById(int id)
        {
            LineInfo info = new LineInfo();
            info.lineStations = new List<LineStation>();


            string sql = "select * from linestation where lineId=" + id + " order by no";
            DataTable result = SqlHelper.ExecuteDataTable(sql);
            if (result != null)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    LineStation entity = new LineStation
                    {
                        id = (int)result.Rows[i]["id"],
                        no = (int)result.Rows[i]["no"],
                        lineId = (int)result.Rows[i]["lineid"],
                        type = (int)result.Rows[i]["type"],
                        lng = (double)result.Rows[i]["lng"],
                        lat = (double)result.Rows[i]["lat"],
                        name = result.Rows[i]["name"].ToString(),
                        stationName = result.Rows[i]["stationname"].ToString()

                    };
                    if (entity.type == 2)
                    {
                        info.lineStations.Add(entity);
                    }
                    else if (entity.type == 0)
                    {
                        info.start = entity;
                    }
                    else if (entity.type == 1)
                    {
                        info.terminus = entity;
                    }
                }
                return info;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询符合条件的线路
        /// </summary>
        /// <param name="queryName">关键字</param>
        /// <returns>线路集合</returns>
        public IList<Line> FindByQueryName(string queryName)
        {
            List<Line> lines = new List<Line>();
            string sql = "select * from line where code like '%" + queryName + "%' or name like '%" + queryName + "%'";
            DataTable result = SqlHelper.ExecuteDataTable(sql);
            if (result != null)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    Line entity = new Line
                    {
                        id = (int)result.Rows[i]["id"],
                        code = result.Rows[i]["code"].ToString(),
                        name = result.Rows[i]["name"].ToString(),
                        remarks = result.Rows[i]["remarks"].ToString()
                    };
                    lines.Add(entity);
                }
                return lines;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改线路
        /// </summary>
        /// <param name="route">线路</param>
        /// <returns>是否成功</returns>
        public bool UpdateRoute(Line route)
        {
            string sql = "update line " +
                    "set code=@code,name=@name,remarks=@remarks " +
                    "where id=@id";
            var result = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@code", route.code),
                new SqlParameter("@name", route.name),
                new SqlParameter("@remarks", route.remarks),
                new SqlParameter("@id", route.id)
            });
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 修改线路
        /// </summary>
        /// <param name="station">线路</param>
        /// <returns>是否成功</returns>
        public bool UpdateStation(LineStation station)
        {
            string sql = "update linestation " +
                    "set no=@no,name=@name,stationName=@stationName,lng=@lng,lat=@lat,type=@type " +
                    "where id=@id";
            var result = SqlHelper.ExecSql(sql, new SqlParameter[] {
                new SqlParameter("@no", station.no),
                new SqlParameter("@name", station.name),
                new SqlParameter("@stationName", station.stationName),
                new SqlParameter("@lng", station.lng),
                new SqlParameter("@lat", station.lat),
                new SqlParameter("@type", station.type),
                new SqlParameter("@id", station.id),
            });
            return result > 0 ? true : false;
        }
    }
}
