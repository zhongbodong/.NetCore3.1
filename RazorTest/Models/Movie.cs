using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Models
{
    /// <summary>
    /// 电影Model类
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
         [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        /// <summary>
        /// 发行时间
        /// </summary>
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)] //时间类型，仅显示日期，而非时间信息。
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 专辑
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public string Rating { get; set; }
    }
}
