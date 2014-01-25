using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SetMeta.Web.Models;
using SetMeta.Web.Domain.Services;

namespace SetMeta.Web.Controllers
{
    public class DayController : BaseController
    {
        private readonly IDayService _dayService;
        
        //views
        //todo:new
        //todo:list
        //todo:detail

 
        //todo: json GET

        public DayController(
            IDayService dayService,
            IUserService userService, 
            IFormsAuthenticationService formsAuthenticationService) 
            : base(userService, formsAuthenticationService)
        {
            _dayService = dayService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<JsonResult> All(int id = 0)
        {
            var pageNumber = id;
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var items = await _dayService.GetDays(pageNumber);
            var list = items.Items.Select(DayModel.MapEntityToModel).ToList();

            var model = new PageModel<DayModel>
            {
                Items = list,
                HasNextPage = items.HasNextPage,
                HasPreviousPage = items.HasPreviousPage,
                Number = items.Number,
                TotalCount = items.TotalCount,
                TotalPageCount = items.TotalPageCount
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}