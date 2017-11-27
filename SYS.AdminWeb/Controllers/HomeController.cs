using SYS.AdminWeb.Models.SetModel;
using SYS.AdminWeb.Models.TestModel;
using SYS.IService.Interface;
using SYS.WebCommon.Json;
using SYS.WebCommon.Mvc;
using SYS.WebCommon.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SYS.AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        public IIdNameService idNameService { get; set; }

        public ActionResult Index()
        {
            //idNameService.AddNew("活动状态", "未start", null);
            //idNameService.AddNew("活动状态", "已start", null);
            //idNameService.AddNew("活动状态", "start中", null);
            //idNameService.AddNew("活动状态", "未开奖", null);
            //idNameService.AddNew("活动状态", "start中", null);
            //long id = idNameService.AddNew("活动状态", "已结束", null);
            IdNameSearchResult result = new IdNameSearchResult();
            result = idNameService.GetAllByTypeName("活动状态", 0, 6);
            return View(result.IdNames);
        }

        public ActionResult List()
        {
            TestModel model = new TestModel();
            model = null;
            return View(model);
        }

        public ActionResult Data(TestModel model)
        {
            if(!ModelState.IsValid)
            {
                //return Json(new AjaxResult { Status = "ok", Msg =MVCHelper.GetValidMsg(ModelState)});
                return Content(MVCHelper.GetValidMsg(ModelState));
            }
            //return Json(new AjaxResult { Status = "ok"});
            return Content("成功");
        }

        public ActionResult PageData(int pageIndex=1)
        {
            IdNameSearchResult result = new IdNameSearchResult();
            result = idNameService.GetAllByTypeName("活动状态", (pageIndex - 1) * 5, 5);
                        

            PageModel model = new PageModel();
            model.IdNames = result.IdNames;

            var pager = new Pagination();
            pager.CurrentLinkClassName = "curPager";
            pager.MaxPagerCount = 10;
            pager.PageIndex = pageIndex;//这些数据，cshtml不知道，就必须让Action传递给我们
            //对于所有cshtml要用到，但是又获取不到的数据，都由Action来获取，然后放到ViewBag或者Model中传递给cshtml
            pager.PageSize = 5;
            pager.TotalCount = result.Count;
            pager.UrlPattern = "javascript:getPage({pn});";

            model.PageHTML = pager.GetPagerHtml();

            return Json(new AjaxResult { Status="ok",Data=model});
        }
    }
}