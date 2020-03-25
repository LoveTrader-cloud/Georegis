using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Models.Common
{
    public class PageTuskViewModel
    {
        public IPagedList<TableTuskViewModel> Tusk { get; set; }

        public TableTuskViewModel search { get; set; }

        /// <summary>
        /// Информация о странице
        /// </summary>
        public PageInfo PageInfo { get; set; }

        public List<SelectListItem> Sorting { get; set; }
    }
}