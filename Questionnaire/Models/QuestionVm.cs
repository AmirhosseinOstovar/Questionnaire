using Domain_Service.Models;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Models
{
    public class QuestionVm
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public QuestionType  questionType { get; set; }

    }
}
