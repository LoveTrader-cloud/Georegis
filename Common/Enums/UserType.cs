using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum UserType
    {
        /// <summary>
        /// Значение не задано = 0
        /// </summary>
        Nothing = 0,

        /// <summary>
        /// Руководитель
        /// </summary>
        Manager = 1,

        /// <summary>
        /// Ркуоводитель рабочей группы = 2
        /// </summary>
        GroupManager = 2,

        

        /// <summary>
        /// Секретарь
        /// </summary>
        IncomingFilter = 7,
    }
}
