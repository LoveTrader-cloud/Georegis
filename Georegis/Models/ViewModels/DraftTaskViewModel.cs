using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Models.ViewModels
{
    public class DraftTaskViewModel
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тема задачи
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Текст задачи
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// срок исполнения
        /// </summary>
        public DateTime DueDate { get; set; }


        /// <summary>
        /// Сессия процесса по запросу
        /// </summary>
        public virtual List<ProcessSessionViewModel> ProcessSessions { get; set; }

        /// <summary>
        /// Названяенные подразделения на исполнение. Тут неструктурированная куча подразделений.
        /// Ценность только одна - обеспечить связь между ExecDep и Request.
        /// Со стороны запроса необходимо пользоваться ProcessSessions
        /// </summary>
        public virtual List<ExecDepViewModel> ExecDeps { get; set; }

        /// <summary>
        /// на кого назначено
        /// </summary>
        public virtual List<ExecutorViewModel> Executors { get; set; }

        /// <summary>
        /// список подразделений для назначения
        /// </summary>
        public List<ListItem> DepList { get; set; }
    }
}