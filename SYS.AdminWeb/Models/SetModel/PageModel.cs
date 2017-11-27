using SYS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SYS.AdminWeb.Models.SetModel
{
    public class PageModel
    {
        public IdNameDTO[] IdNames { get; set; }
        public string PageHTML { get; set; }
    }
}