using Domain_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Services.Response
{
    public interface IResponse
    {
        void AddResponse(Domain_Service.Models.Response response);
        void Addcategoryresponse(categoryresponse categoryresponse);
        IEnumerable<categoryresponse> GetCategoryresponsesWithcategoryId(int CategoryId);
        Domain_Service.Models.Response GetResponse(int Id);
        void Save();
    }
}
