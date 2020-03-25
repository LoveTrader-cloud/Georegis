using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models.Common.DTO
{
    public class PageTuskDTO
    {
        public List<TableTuskDTO> Tusk { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}