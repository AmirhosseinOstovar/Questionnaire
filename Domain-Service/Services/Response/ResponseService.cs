using Domain_Service.Context;
using Domain_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain_Service.Services.Response
{
    public class ResponseService : IResponse
    {
        private readonly DataContext _context;

        public ResponseService(DataContext context)
        {
            _context = context;
        }

        public void Addcategoryresponse(categoryresponse categoryresponse)
        {
            _context.Categoryresponses.Add(categoryresponse);
            Save();
        }

        public void AddResponse(Models.Response response)
        {
            response.IsDelete = false;
            response.Insertdate = DateTime.Now;
            var result = _context.Responses.Add(response);
            Save();
            categoryresponse categoryresponse = new categoryresponse();
            categoryresponse.Responseid = result.Entity.Id;
            categoryresponse.CategoryId =_context.Question.FirstOrDefault(x=>x.Id==response.QuestionId).CategoryQuestionId;

            Addcategoryresponse(categoryresponse);
           
        }

        

        public IEnumerable<categoryresponse> GetCategoryresponsesWithcategoryId(int CategoryId)
        {
            return _context.Categoryresponses.Include(x=>x.response).Include(x=>x.CategoryQuestion).Where(x=>x.CategoryId==CategoryId).OrderByDescending(x => x.Id).ToList();
        }

        public Models.Response GetResponse(int Id)
        {
            return _context.Responses.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
