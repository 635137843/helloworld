using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.Models
{
    /// <summary>
    /// 实体类：站台
    /// Creator：何明鑫
    /// Date：2019/7/17
    /// </summary>
    public class Site:BaseEntity
    {
        /// <summary>
        /// 站台名称
        /// </summary>
        [Required]
        public string name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double lng { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double lat { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string describe { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remarks { get; set; }
    }
}
