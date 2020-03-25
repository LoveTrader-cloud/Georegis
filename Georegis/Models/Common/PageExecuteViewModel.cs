using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Models.Common
{
    public class PageExecuteViewModel
    {
        public IPagedList<TableExecuteViewModel> Tusk { get; set; }

        public TableExecuteViewModel search { get; set; }

        /// <summary>
        /// Информация о странице
        /// </summary>
        public PageInfo PageInfo { get; set; }

        public List<SelectListItem> Sorting { get; set; }

        public List<SelectListItem> StatusList { get; set; }
    }
}