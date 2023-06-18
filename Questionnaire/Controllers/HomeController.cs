using Domain_Service.Models;
using Domain_Service.Services.CategoryQuestion;
using Domain_Service.Services.Question;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using Domain_Service.ViewModel;
using Domain_Service.Services.Response;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Questionnaire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryQuestion _category;
        private readonly IQuestion _question;
        private readonly IResponse _response;


        public HomeController(ICategoryQuestion category, IQuestion question, IResponse response)
        {
            _category = category;
            _question = question;
            _response = response;
        }
        public IActionResult Index()
        {
            var model = _category.GetAllCategoryQuestions();
          
            return View(model);
        }
        public IActionResult MyQuestions()
        {
            var model = _category.GetAllCategoryQuestions();
            return View("_Index", model);
        }

        public IActionResult AddCategoryQuestion(string Title)
        {
            try
            {
                CategoryQuestion question = new CategoryQuestion()
                {
                    Title = Title,
                    Url = _category.CreatUrl()

                };
                _category.AddCategoryQuestion(question);

                return new JsonResult(true);
            }
            catch (Exception)
            {

                return new JsonResult(false);
            }

        }

        public IActionResult GetAllCategoryQuestion()
        {
            var model = _category.GetAllCategoryQuestions();
            return View("_GetAllquestion", model);
        }
        public IActionResult EditeCategory(int id)
        {
            var model = _category.GetCategoryQuestion(id);
            var json = JsonConvert.SerializeObject(model);
            return Json(json);
        }
        public IActionResult Edite(string title, int id)
        {
            try
            {
                var model = _category.GetCategoryQuestion(id);
                model.Title = title;
                _category.UpdateCategoryCategoryQuestion(model);
                return new JsonResult(true);
            }
            catch (Exception e)
            {

                return new JsonResult(false);
            }
        }
        public IActionResult Delit(int id)
        {
            try
            {
                _category.DeleteCategoryQuestion(id);
                return new JsonResult(true);
            }
            catch (Exception e)
            {
                return new JsonResult(false);
            }
        }

      
        public IActionResult CategoryQuestionList()
        {
            var model = _category.GetAllCategoryQuestions().Select(x => new CategoryQuestionVm()
            {
                Id = x.Id,
                Title = x.Title,
                CountResponse = _response.GetCategoryresponsesWithcategoryId(x.Id).Count(),
            }).ToList();
            return View("_CategoryQuestionList", model);
        }
        public IActionResult GetResponse(int CategoryId) 
        {
            var model = _response.GetCategoryresponsesWithcategoryId(CategoryId);
            ViewBag.category=_category.GetCategoryQuestion(CategoryId).Title;
            return View("_GetResponse",model);
        
        }
        public IActionResult GetDetailResponse(int ResponseId)
        {
            var model=_response.GetResponse(ResponseId);
            var json = JsonConvert.SerializeObject(model);
            return Json(json);

        }
    }
}