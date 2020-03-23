using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models.ViewModels
{
    public class ExecDepViewModel
    {
        /// <summary>/// 
        ///  Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>/// 
        ///  Статус
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Значение статуса
        /// </summary>
        public string StatusValue { get; set; }

        /// <summary>/// 
        ///  Завершено или нет
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>/// 
        ///  Необходим контроль
        /// </summary>
        public bool IsControl { get; set; }


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
        public virtual ProcessSessionViewModel ProcessSession { get; set; }

        /// <summary>/// 
        ///  Подразделение
        /// </summary>
        public virtual DepartmentViewModel Department { get; set; }

        /// <summary>/// 
        ///  Рабочие группы назначенные
        /// </summary>
        public virtual List<ExecutorViewModel> Executors { get; set; }

        /// <summary>
        /// ИД родительского элемента
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Дочерние элементы
        /// </summary>
        public virtual List<ExecDepViewModel> Children { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        public virtual ExecDepViewModel Parent { get; set; }


        /// <summary>
        /// Прямая ссылка на запрос. Нужна для быстрого получения данных по запросу
        /// </summary>
        public virtual DraftTaskViewModel Request { get; set; }

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