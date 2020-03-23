using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models.ViewModels
{
    public class ExecutorViewModel
    {
        /// <summary> 
        ///  Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary> 
        ///  Статус
        /// </summary>
        public int StatusId { get; set; }

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
        public virtual UserViewModel User { get; set; }

        /// <summary>
        /// Сотрудник, кому назначена задача
        /// </summary>
        public virtual UserViewModel UserAssign { get; set; }

        /// <summary>
        ///  Назначенная рабочая группа
        /// </summary>
        public virtual ExecDepViewModel ExecDep { get; set; }

        /// <summary>
        /// Прямая ссылка на запрос
        /// </summary>
        public virtual DraftTaskViewModel Task { get; set; }


        /// <summary>
        /// ИД уведомления
        /// </summary>
        public Guid? NotId { get; set; }
    }
}