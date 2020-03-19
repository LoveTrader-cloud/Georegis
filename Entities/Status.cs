using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Entities
{
    public class Status
    {
        public Status()
        {
            DraftRequests = new List<DraftTask>();
            ExecDeps = new List<ExecDep>();
            Executors = new List<Executor>();
            ProcessSessions = new List<ProcessSession>();
        }

        /// <summary>
        /// ИД элемента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Значение статуса
        /// </summary>
        //[Column(TypeName = "VARCHAR2")]
        //[MaxLength(50)]
        public string Value { get; set; }

        /// <summary>
        /// Значение статуса
        /// </summary>
        //[Column(TypeName = "VARCHAR2")]
        //[MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Состояние статуса
        /// </summary>
        public StatusState State { get; set; }

        /// <summary>
        /// Черновики запросов
        /// </summary>
        public virtual List<DraftTask> DraftRequests { get; set; }


        /// <summary>
        /// Согласующие/исполняющие подразделения
        /// </summary>
        public virtual List<ExecDep> ExecDeps { get; set; }

        /// <summary>
        /// Исполнители
        /// </summary>
        public virtual List<Executor> Executors { get; set; }

        /// <summary>
        /// Сессия процесса
        /// </summary>
        public virtual List<ProcessSession> ProcessSessions { get; set; }

    }
}
