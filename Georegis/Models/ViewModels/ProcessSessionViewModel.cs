using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models.ViewModels
{
    public class ProcessSessionViewModel
    {
        /// <summary>
        /// ИД элемента
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Исполнение/Согласование
        /// </summary>
        public virtual List<ExecDepViewModel> ExecDeps { get; set; }

        /// <summary>
        /// Завершен
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Указывает на то, что сессия является текущей
        /// </summary>
        public bool? IsCurrent { get; set; }

        /// <summary>
        /// Запрос, по которму сессия идет
        /// </summary>
        public virtual DraftTaskViewModel Request { get; set; }


        /// <summary>
        /// Создано
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Изменено
        /// </summary>
        public DateTime Modified { get; set; }


        /// <summary>
        /// Статус
        /// </summary>
        public string StatusValue { get; set; }

        /// <summary>
        /// Состояние статуса
        /// </summary>
        public int StatusState { get; set; }
    }
}