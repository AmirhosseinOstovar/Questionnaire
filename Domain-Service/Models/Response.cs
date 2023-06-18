using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Models
{
    [Table("Response", Schema = "Question")]

    public class Response
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        [DisplayName("نام ")]
        public string Name { get; set; }
        [DisplayName("نام خانوادگی")]
        public string Family { get; set; }
        public DateTime Insertdate { get; set; }

        public string Answer { get; set; } //file name ,text, numerical,enum multy
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }


    }
}
