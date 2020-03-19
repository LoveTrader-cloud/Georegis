using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    /// <summary>
    /// Тип
    /// </summary>
    public enum ExecutorType
    {
        /// <summary>
        /// Значение не задано = 0
        /// </summary>
        Nothing = 0,

        /// <summary>
        /// Руководитель самостоятельного подразделения или несамостоятельного отдела = 1
        /// </summary>
        DepartmentManager = 1,

        /// <summary>
        /// Ркуоводитель бюро или рабочей группы = 2
        /// </summary>
        GroupManager = 2,

        /// <summary>
        /// Исполнитель = 3
        /// </summary>
        Executor = 3,

        /// <summary>
        /// Контролер
        /// </summary>
        Controller = 4,

        /// <summary>
        /// Подтверждение согласовани
        /// </summary>
        AcceptApprove = 5,

        /// <summary>
        /// Заместитель руководителя
        /// </summary>
        Assistant = 6,

        /// <summary>
        /// Для секретарей, который выполняют фильтрацию входящих СЗ
        /// </summary>
        IncomingFilter = 7,

        /// <summary>
        /// Утверждение исходящего документа
        /// </summary>
        AcceptOutDoc = 8,

        /// <summary>
        /// Согласование исходящего документа
        /// </summary>
        ApproveOutDoc = 9,

        /// <summary>
        /// Ознакомление с документом
        /// </summary>
        Reader = 10
    }
}
