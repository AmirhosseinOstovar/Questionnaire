using Domain_Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Services.Question
{
    public interface IQuestion
    {
        IEnumerable<Models.Question> GetAllQuestionsWithUrl(string CategoryUrl);
        IEnumerable<Models.Question> GetAllQuestionsWithCategoryId(int CategoryId);
        void AddMultyoptionsAndQuestion(Models.Question question, List<string> multipleOptionsResponse);
        Models.Question GetQuestion(int id);
        IEnumerable<CategoryQuestionVm> GetCategoryQuestionWithResponseCount();
        IEnumerable<Models.Response> GetResponsesWithCategoryQuestion(int CategoryQuestionId);
        void AddQuestion(Models.Question Question);
        void DeleteQuestion(int id);
        void UpdateQuestion(Models.Question Question);
        void Save();
    }
}
