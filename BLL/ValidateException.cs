using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ValidateException : Exception
    {
        /// <summary>
        /// Свойство, котороое содержит расширенную информацию об ошибке
        /// </summary>
        public string Property { get; protected set; }

        /// <summary>
        /// Конструктор исключения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="prop">Свойство</param>
        public ValidateException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
