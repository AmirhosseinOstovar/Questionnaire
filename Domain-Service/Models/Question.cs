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
    [Table("Question", Schema = "Question")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("عنوان سوال")]
        public string Title { get; set; }
        [DisplayName("نوع سوال")]
        [Required(ErrorMessage = "{0} را وارد نمایید.")]
        public QuestionType questionType { get; set; }
        [ForeignKey("CategoryQuestionId")]
        public virtual CategoryQuestion CategoryQuestion { get; set; }
        [DisplayName("گروه سوال ")]
        public int CategoryQuestionId { get; set; }
        public bool IsDelete { get; set; }
        
        public virtual ICollection<MultipleOptionsResponse> MultipleOptionsResponses { get; set; }


    }
    public enum QuestionType
    {
        multipleoptions,
        text,
        numerical,
        uploadfile

    }
}
