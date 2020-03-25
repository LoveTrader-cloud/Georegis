using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models
{
    public class ErrorViewModel
    {
        public string Id { get; set; }

        public string Error { get; set; }

        public string Massage { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string StackTrace { get; set; }

        public ErrorViewModel InnerError { get; set; }
    }
}