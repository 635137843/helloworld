using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.Models
{
    /// <summary>
    /// 实体类：线路站台关系表
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public class LineStation:BaseEntity
    {
        /// <summary>
        /// 线路Id
        /// </summary>
        public int lineId { get; set; }            

        /// <summary>
        /// 类型
        /// </summary>
        public int type { get; set; }               

        /// <summary>
        /// 编码
        /// </summary>
        public int no { set; get; }                 

        /// <summary>
        /// 名称
        /// </summary>
        public string name { set; get; }            

        /// <summary>
        /// 站台名
        /// </summary>
        public string stationName { set; get; }     

        /// <summary>
        /// 经度
        /// </summary>
        public double lng { set; get; }             

        /// <summary>
        /// 纬度
        /// </summary>
        public double lat { set; get; }             
    }
}
