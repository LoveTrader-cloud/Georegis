using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Georegis.Models.ViewModels
{
    public class CurrentUserViewModel : UserViewModel
    {

        /// <summary>
        /// ИД текущего подразделения пользователя
        /// </summary>
        public int CurrentDepartmentId
        {
            get
            {
                return this.Department == null ? 0 : this.Department.Id;
            }
        }

        /// <summary>
        /// Название текущего подразделения пользователя
        /// </summary>
        public string CurrentDepartmentTitle
        {
            get
            {
                return this.Department == null ? string.Empty : this.Department.Title;
            }
        }

    }
}