using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EFCore.Models
{
    /// <summary>
    /// 讲师类
    /// </summary>
    public class Instructor : Person
    {
      
       

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

      
        //一个讲师可以教授很多的课程
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        //一个讲师只有一个办公室
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
