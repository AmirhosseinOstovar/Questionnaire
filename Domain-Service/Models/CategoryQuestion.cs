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
    [Table("CategoryQuestion", Schema = "Question")]
    public class CategoryQuestion
    {
        [Key]
        public int Id{ get; set; }
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} را وارد نمایید.")]
        public string Title { get; set; }
        [DisplayName("Url")]
        public string Url { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
