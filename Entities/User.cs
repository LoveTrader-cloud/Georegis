using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        /// <summary>
        ///  Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary> 
        ///  Табельный номер
        /// </summary>
        public int TabNumber { get; set; }

        /// <summary>
        ///  Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///  Полное имя. ФИО
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Фамилия И.О.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary> 
        ///  Номер телефона
        /// </summary>
        public string TelNo { get; set; }

        /// <summary> 
        ///  Почта пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Краткое наименование организации. Служит для того чтобы отделять принадлежность пользователей к разным огранизациям.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// тип роли пользователя
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>/// 
        ///  Подразделение
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// Подразделение в котором является руководителем
        /// </summary>
        public virtual List<Department> ManagedDepartments { get; set; }

        /// <summary>
        /// Задачи сотрудника
        /// </summary>
        public virtual List<Executor> Executors { get; set; }
    }
}
