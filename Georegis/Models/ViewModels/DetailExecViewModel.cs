using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Models.ViewModels
{
    public class DetailExecViewModel
    {
        /// <summary>
        /// ИД элемента
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public Guid TuskId { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        [DisplayName("Сообщение")]
        [Required(ErrorMessage = "Укажите сообщение")]
        public string Message { get; set; }

        /// <summary>
        /// ИД задачи
        /// </summary>
        public Guid ExecutorId { get; set; }

        /// <summary>
        /// ИД назначения задачи в подразделение
        /// </summary>
        public Guid ExecDepId { get; set; }

        /// <summary>
        /// Состояние назначения
        /// </summary>
        public StatusState ExecutorStatusState { get; set; }

        /// <summary>
        /// Название статуса
        /// </summary>
        public string ExecutorStatusValue { get; set; }

        /// <summary>
        /// Адрес с которого пришли на страницу. Необходимо, что знать куда делать редирект.
        /// </summary>
        public Uri PreviousUri { get; set; }

        public Uri CurrentUrl { get; set; }

        public string Url { get; set; }

        public string BackUrl { get; set; }

        public DraftTaskViewModel DraftTusk {get; set;}
    }
}