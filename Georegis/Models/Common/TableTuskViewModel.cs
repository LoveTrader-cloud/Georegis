using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models.Common
{
    public class TableTuskViewModel
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

        public int DepartmentExecute { get; set; }

        public string StatusValue {get; set;}

        /// <summary>
        /// Указывается поле по которому идет сортировка
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Направление сортировки
        /// </summary>
        public string SortOrder { get; set; }
    }
}