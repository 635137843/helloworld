using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.Models
{
    /// <summary>
    /// 实体类：线路
    /// Creator：何明鑫
    /// Date：2019/7/16
    /// </summary>
    public class Line:BaseEntity
    {
        /// <summary>
        /// 线路名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remarks { get; set; }

    }
}
