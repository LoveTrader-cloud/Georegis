using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProcessSession
    {
        public ProcessSession()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
            ExecDeps = new List<ExecDep>();
        }

        /// <summary>
        /// ИД элемента
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Исполнение/Согласование
        /// </summary>
        public virtual List<ExecDep> ExecDeps { get; set; }

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
        public virtual DraftTask Request { get; set; }


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
        public virtual Status Status { get; set; }
    }
}
