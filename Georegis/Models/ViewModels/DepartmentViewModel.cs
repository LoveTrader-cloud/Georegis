using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Models.ViewModels
{
    public class DepartmentViewModel
    {
        /// <summary>/// 
        ///  Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary> 
        ///  Уникальный номер записи
        /// </summary>
        public int CodeId { get; set; }

        /// <summary> 
        ///  Название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Код подразделения.
        /// </summary>
        public string DepartmentCode { get; set; }


        /// <summary>
        /// Префикс подразделения
        /// </summary>
        public string DepartmentPrefix { get; set; }

        /// <summary>/// 
        ///  Описание
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Метка удаления подразделения
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Самостоятельное подразделение
        /// </summary>
        public bool IsIndependent { get; set; }

        /// <summary>
        /// Несамостоятельное подразделение, но с функциями отдела. Номер СЗ берется от родителя
        /// </summary>
        public bool? NotIndependent { get; set; }

        /// <summary>
        /// Бюро или рабочая группа
        /// </summary>
        public bool? IsGroup { get; set; }

        /// <summary>
        /// Руководство
        /// </summary>
        public bool IsLeaders { get; set; }

        /// <summary>
        /// Бюро контроля исполнения
        /// </summary>
        public bool IsControllerBuro { get; set; }

        ///// <summary>
        ///// Бюро секретарского обеспечения и документоведения
        ///// </summary>
        //public bool isSecretarBuro { get; set; }

        /// <summary>
        /// Бюро секретарского обеспечения и документоведения
        /// </summary>
        public bool IsSecretarBuro { get; set; }

        /// <summary>
        /// Табельный руководителя подразделения
        /// </summary>
        public int ManagedBy { get; set; }

        /// <summary>
        /// Пользователь, который является руководителем подразделения
        /// </summary>
        //public virtual User UserManagedBy { get; set; }

        /// <summary>
        /// Пользователь, который является руководителем подразделения
        /// </summary>
        public virtual UserViewModel UserGroupManager { get; set; }

        /// <summary>/// 
        ///  Сотрудники подразделения
        /// </summary>
        public virtual List<UserViewModel> Users { get; set; }

        /// <summary>/// 
        ///  Назначение на исполнение/согласование заявки
        /// </summary>
        public virtual List<ExecDep> ExecDeps { get; set; }

        public List<SelectListItem> UsersList { get; set; }
    }
}