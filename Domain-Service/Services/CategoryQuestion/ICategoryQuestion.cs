using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Services.CategoryQuestion
{
    public interface ICategoryQuestion
    {
        IEnumerable<Models.CategoryQuestion> GetAllCategoryQuestions();
       
        Models.CategoryQuestion GetCategoryQuestion(int id);
        string CreatUrl();
        Models.CategoryQuestion GetCategoryWithUrl(string url);
        void AddCategoryQuestion(Models.CategoryQuestion categoryQuestion);
        void DeleteCategoryQuestion(int id);
        void UpdateCategoryCategoryQuestion(Models.CategoryQuestion categoryQuestion);

        void Save();

    }
}
