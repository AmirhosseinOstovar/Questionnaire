using Domain_Service.Models;
using Domain_Service.Services.CategoryQuestion;
using Domain_Service.Services.Question;
using Domain_Service.Services.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Questionnaire.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Questionnaire.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ICategoryQuestion _category;
        private readonly IQuestion _question;
        private readonly IResponse _response;



        public QuestionController(IQuestion question, ICategoryQuestion category, IResponse response)
        {
            _question = question;
            _category = category;
            _response = response;
        }
        [HttpPost]
        [Route("AddQuestion")]
        public IActionResult AddQuestion(QuestionVm model, string[] multy)
        {

            try
            {
                Question question = new Question()
                {
                    CategoryQuestionId = model.CategoryId,
                    questionType = model.questionType,
                    Title = model.Title,

                };

                var listmulty = multy.ToList();
                if (listmulty.Count() > 0)
                {
                    _question.AddMultyoptionsAndQuestion(question, listmulty);
                }
                else
                {
                    _question.AddQuestion(question);
                }
                return new JsonResult(true);
                //return Json(new { StatusCode = true});
            }

            catch (Exception e)
            {
                return new JsonResult(false);
            }
        }
        [Route("ResponseQuestions/{url}")]
        public IActionResult GetAllQuestions(string url)
        {
            var model = _question.GetAllQuestionsWithUrl(url);
            ViewBag.Category = _category.GetCategoryWithUrl(url);
            return View(model);
        }
        public IActionResult GetQuestion(int Id)
        {

            var model = _question.GetAllQuestionsWithCategoryId(Id);
            return View("_ShowQuestion", model);
        }
        public IActionResult EditeQuestion(int id)
        {
            var model = _question.GetQuestion(id);
            QuestionAndMultyVm questionAndMultyVm = new QuestionAndMultyVm()
            {
                id = model.Id,
                Title = model.Title,
                TypeQuestion = ((int)model.questionType),
                 
            };
            if (model.questionType==Domain_Service.Models.QuestionType.multipleoptions)
            {
                List<string> titlemulty = new List<string>();
                List<int> idmulty = new List<int>();
                foreach (var item in model.MultipleOptionsResponses)
                {
                    titlemulty.Add(item.Title);
                    idmulty.Add(item.Id);

                }
                questionAndMultyVm.MultyResponse = titlemulty;
                questionAndMultyVm.MultyResponseId= idmulty;
            }
           
            var json = JsonConvert.SerializeObject(questionAndMultyVm);
            return Json(json);
        }
        public IActionResult Edite(QuestionVm model, string[] multy)
        {
            try
            {
                var updatemodel = _question.GetQuestion(model.QuestionId);
                updatemodel.Title = model.Title;
                updatemodel.questionType = model.questionType;
                _question.UpdateQuestion(updatemodel);
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
                _question.DeleteQuestion(id);
                return new JsonResult(true);
            }
            catch (Exception ex)
            {

                return new JsonResult(false);
            }

        }
        public IActionResult Response(int QuestionId)
        {
            ViewBag.TitleCategory = _question.GetQuestion(QuestionId).Title;
            ViewBag.QuestionId = QuestionId;
            var model = _question.GetQuestion(QuestionId);

            return View("_Response", model);
        }
        [HttpPost]
        public IActionResult ResponseAdd(Domain_Service.Models.Response response)
        {
            try
            {
                _response.AddResponse(response);
             
                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }
          
        }
        //public IActionResult GetListQuestion(int id) { }

    }
}
