﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SiPA.Web.ActionFilter
{
    public class SetTempDataModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);


            if (filterContext.Controller is Controller controller)
            {
                controller.TempData["ModelState"] = controller.ViewData.ModelState;
            }
        }
    }

    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            Controller controller = filterContext.Controller as Controller;
            if (controller != null & controller.TempData.ContainsKey("ModelState"))
            {
                controller.ViewData.ModelState.Merge(
                    (ModelStateDictionary)controller.TempData["ModelState"]);
            }
        }
    }
}
