using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundManagementApplication.Utilities {

    public static class HtmlExtensions {
        public static string IsSelected(this IHtmlHelper htmlHelper, string controllers, string actions, string cssClass) {
            string currentAction = htmlHelper.ViewContext.RouteData.Values["action"] as string;
            string currentController = htmlHelper.ViewContext.RouteData.Values["controller"] as string;

            IEnumerable<string> acceptedActions = (actions ?? currentAction).Split(',');
            IEnumerable<string> acceptedControllers = (controllers ?? currentController).Split(',');

            return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ?
                $"{cssClass} active" : cssClass;
        }

        public static HtmlString DisabledIf(this IHtmlHelper htmlHelper, bool condition) {
            return new HtmlString(condition ? "disabled=\"disabled\"" : "");
        }
    }
}
