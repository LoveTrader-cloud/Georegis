using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models.Common.DTO
{
    public class ExecutorDetailsDTO
    {
        public Guid Id { get; set; }

        public Guid ExecDepId { get; set; }

        public Guid TuskId { get; set; }

        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public StatusState StatusState { get; set; }

        public string StatusValue { get; set; }


        public ExecutorType Type { get; set; }

        public int DepartmetnId { get; set; }
    }
}