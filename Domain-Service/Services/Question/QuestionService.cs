using Domain_Service.Context;
using Domain_Service.Models;
using Domain_Service.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Services.Question
{
    public class QuestionService : IQuestion
    {
        private readonly DataContext _context;

        public QuestionService(DataContext context)
        {
            _context = context;
        }

        public void AddMultyoptionsAndQuestion(Models.Question question, List<string> multipleOptionsResponse)
        {
            question.IsDelete = false;
            _context.Question.Add(question);
            _context.SaveChanges();
            var id = question.Id;
            foreach (var item in multipleOptionsResponse)
            {
                MultipleOptionsResponse multymodel = new MultipleOptionsResponse()
                {
                    IsDelete = false,
                    QuestionId = id,
                    Title = item,
                };
                _context.MultipleOptions.Add(multymodel);
            }
            Save();
        }
        public void AddQuestion(Models.Question Question)
        {
            Question.IsDelete = false;  
            _context.Question.Add(Question);
            Save();
        }

      

        public void DeleteQuestion(int id)
        {
            var Question = _context.Question.FirstOrDefault(c => c.Id == id && c.IsDelete == false);
            Question.IsDelete = true;
            UpdateQuestion(Question);
          
        }

        public IEnumerable<Models.Question> GetAllQuestionsWithCategoryId(int CategoryId)
        {
            return _context.Question.Where(x => x.CategoryQuestionId == CategoryId && x.IsDelete == false).OrderByDescending(x => x.Id).ToList();

        }

        public IEnumerable<Models.Question> GetAllQuestionsWithUrl(string CategoryUrl)
        {
            return _context.Question.Where(x => x.CategoryQuestion.Url == CategoryUrl && x.IsDelete == false).OrderByDescending(x => x.Id).ToList();
        }

        public IEnumerable<CategoryQuestionVm> GetCategoryQuestionWithResponseCount()
        {
            throw new NotImplementedException();
        }

        public Models.Question GetQuestion(int id)
        {
            var result = _context.Question.Include(x => x.MultipleOptionsResponses).Include(x => x.CategoryQuestion).FirstOrDefault(x => x.Id == id && x.IsDelete == false);

            return result;
        }

        public IEnumerable<Models.Response> GetResponsesWithCategoryQuestion(int CategoryQuestionId)
        {
            var questions = GetAllQuestionsWithCategoryId(CategoryQuestionId);
            var response=_context.Responses.Where(e => questions.Any(l1 => l1.Id == e.QuestionId)).ToList();
            return response;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateQuestion(Models.Question Question)
        {
            _context.Entry(Question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
