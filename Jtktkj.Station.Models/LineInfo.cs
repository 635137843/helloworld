using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.Models
{
    /// <summary>
    /// 数据转换类：线路信息
    /// Creator：何明鑫
    /// Date：2019/7/18
    /// </summary>
    public class LineInfo
    {
        /// <summary>
        /// 起点站
        /// </summary>
        public LineStation start { set; get; }

        /// <summary>
        /// 终点站
        /// </summary>
        public LineStation terminus { set; get; }

        /// <summary>
        /// 站台集合
        /// </summary>
        public List<LineStation> lineStations { set; get; }
    }
}
