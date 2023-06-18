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
    [Table("MultipleOptionsResponse", Schema = "Question")]

    public class MultipleOptionsResponse
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        [DisplayName("عنوان ")]
        [Required(ErrorMessage = "{0} را وارد نمایید.")]
        public string Title { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question  Question{ get; set; }
        public int QuestionId { get; set; }
    }
}
