using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ExecDep
    {
        public ExecDep()
        {
            IsCompleted = false;
            Created = DateTime.Now;
            Modified = DateTime.Now;
            DueDate = DateTime.Now;
            Executors = new List<Executor>();
            Children = new List<ExecDep>();
        }
        /// <summary>/// 
        ///  Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>/// 
        ///  Статус
        /// </summary>
        public virtual Status Status { get; set; }

        /// <summary>/// 
        ///  Завершено или нет
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>/// 
        ///  Необходим контроль
        /// </summary>
        public bool IsControl { get; set; }

        /// <summary>/// 
        ///  Согласование
        /// </summary>
        public bool IsApprove { get; set; }

        /// <summary>
        /// Создано
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Изменено
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Срок исполнения запроса
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>/// 
        ///  Заявка
        /// </summary>
        public virtual ProcessSession ProcessSession { get; set; }

        /// <summary>/// 
        ///  Подразделение
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>/// 
        ///  Рабочие группы назначенные
        /// </summary>
        public virtual List<Executor> Executors { get; set; }

        /// <summary>
        /// ИД родительского элемента
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Дочерние элементы
        /// </summary>
        public virtual List<ExecDep> Children { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        public virtual ExecDep Parent { get; set; }


        /// <summary>
        /// Прямая ссылка на запрос. Нужна для быстрого получения данных по запросу
        /// </summary>
        public virtual DraftTask Request { get; set; }

        /// <summary>
        /// Резолюция/сообщение
        /// </summary>
        public string Resolution { get; set; }

        /// <summary>
        /// ИД элемента маршрута запроса для быстрого нахождения положения
        /// </summary>
        public Guid RequestRouteId { get; set; }


        /// <summary>
        /// Сообщение контролеру
        /// </summary>
        public string ControllerMessage { get; set; }

        /// <summary>
        /// Указывает, что ExecDep является текущим
        /// </summary>
        public bool? IsCurrent { get; set; }
    }
}
