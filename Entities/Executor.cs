using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Entities
{
        public class Executor
        {
            public Executor()
            {
                IsCompleted = false;
                Created = DateTime.Now;
                Modified = DateTime.Now;
                DueDate = DateTime.Now;
            }

            /// <summary> 
            ///  Идентификатор
            /// </summary>
            public Guid Id { get; set; }

            /// <summary> 
            ///  Статус
            /// </summary>
            public virtual Status Status { get; set; }

            /// <summary> 
            ///  Завершено
            /// </summary>
            public bool IsCompleted { get; set; }

            /// <summary> 
            ///  Дата создания
            /// </summary>
            public DateTime Created { get; set; }

            /// <summary>
            /// Датат изменения
            /// </summary>
            public DateTime Modified { get; set; }

            /// <summary>
            /// Срок исполнения запроса
            /// </summary>
            public DateTime DueDate { get; set; }

            /// <summary>
            /// Тип элемента
            /// </summary>
            public ExecutorType Type { get; set; }

            /// <summary> 
            ///  Руководитель подразделения
            /// </summary>
            public bool IsDefault { get; set; }

            /// <summary> 
            ///  Резолюция руководителя рабочей группы
            /// </summary>
            public string Resolution { get; set; }

            /// <summary> 
            ///  Пользователь
            /// </summary>
            public virtual User User { get; set; }

            /// <summary>
            /// Сотрудник, кому назначена задача
            /// </summary>
            public virtual User UserAssign { get; set; }

            /// <summary>
            ///  Назначенная рабочая группа
            /// </summary>
            public virtual ExecDep ExecDep { get; set; }

            /// <summary>
            /// Прямая ссылка на запрос
            /// </summary>
            public virtual DraftTask Request { get; set; }


            /// <summary>
            /// ИД уведомления
            /// </summary>
            public Guid? NotId { get; set; }
        }
}
