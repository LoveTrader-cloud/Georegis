using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
        /// <summary>
        /// Состояние статуса
        /// </summary>
        public enum StatusState
        {
            /// <summary>
            /// Значение не задано
            /// </summary>
            [Display(Name = "Ничего")]
            Nothing = 0,

            /// <summary>
            /// Позволяет редактирование, удаление
            /// </summary>
            [Display(Name = "Редактирование")]
            Edit = 1,

            /// <summary>
            /// Показывает, что идет работа. Нельзя редактировать или удалять
            /// </summary>
            [Display(Name = "В работе")]
            Process = 2,

            /// <summary>
            /// Работа завершена
            /// </summary>
            Completed = 3,

            /// <summary>
            /// Выполнение отложено
            /// </summary>
            Delayed = 4,

            ///// <summary>
            ///// Отклонено
            ///// </summary>
            //Rejected = 5,

            //RejectedEdit = 6,

            ///// <summary>
            ///// Черновик
            ///// </summary>
            //Draft = 7
        }
    
}
