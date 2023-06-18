using Domain_Service.Context;
using Domain_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Services.CategoryQuestion
{
    public class CategoryQuestionService : ICategoryQuestion
    {
        private readonly DataContext _context;


        public CategoryQuestionService(DataContext context)
        {
            _context = context;

        }

        public void AddCategoryQuestion(Models.CategoryQuestion categoryQuestion)
        {
            categoryQuestion.IsDelete = false;
            _context.Categories.Add(categoryQuestion);
            Save();
        }

        public void DeleteCategoryQuestion(int id)
        {
            var categoryQuestion = _context.Categories.FirstOrDefault(c => c.Id == id);
            categoryQuestion.IsDelete = true;
            UpdateCategoryCategoryQuestion(categoryQuestion);
            Save();
        }

        public IEnumerable<Models.CategoryQuestion> GetAllCategoryQuestions()
        {
            return _context.Categories.Where(c => c.IsDelete == false).OrderByDescending(x=>x.Id).ToList();

        }

        public Models.CategoryQuestion GetCategoryQuestion(int id)
        {
            var result = _context.Categories.FirstOrDefault(x => x.IsDelete == false && x.Id == id);
            return result;
        }
        public void UpdateCategoryCategoryQuestion(Models.CategoryQuestion categoryQuestion)
        {
            _context.Entry(categoryQuestion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }



        public string CreatUrl()
        {

            StringBuilder str_build = new StringBuilder();

            for (int m = 0; m < 1;)
            {
                int length = 7;
                // creating a StringBuilder object()
                Random random = new Random();
                char letter;
                for (int i = 0; i < length; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    str_build.Append(letter);
                }
                var checkedurl = _context.Categories.FirstOrDefault(x => x.Url == str_build.ToString());
                if (checkedurl==null)
                {
                    break;
                }
            }
            return str_build.ToString();

        }
       
        public Models.CategoryQuestion GetCategoryWithUrl(string url)
        {
           return _context.Categories.FirstOrDefault(c => c.Url == url);
        }
    }
}
