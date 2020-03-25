using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models.Common.DTO
{
    public class PageExecuteDTO
    {
        public List<TableExecuteDTO> Tusk { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}