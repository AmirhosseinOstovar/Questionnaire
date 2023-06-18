namespace Questionnaire.Models
{
    public class QuestionAndMultyVm
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int TypeQuestion{ get; set; }
        public string TitleTypeQuestion{ get; set; }
        public List<string> MultyResponse { get; set; }
        public List<int> MultyResponseId { get; set; }
    }
}
