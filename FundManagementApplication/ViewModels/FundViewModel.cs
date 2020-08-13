using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FundManagementApplication.ViewModels {
    public class FundViewModel
    {
        public List<SelectListItem> Funds { get; set; }
    }
}
