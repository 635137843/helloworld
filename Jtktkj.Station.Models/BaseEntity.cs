using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.Models
{
    /// <summary>
    /// 实体类：基类
    /// Creator：何明鑫
    /// Date：2019/7/16
    /// </summary>
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
    }
}
