using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Classes
{
    public enum MaterialType : byte
    {
        /// <summary>
        /// Не выбрано
        /// </summary>
        None = 0,

        /// <summary>
        /// Медь
        /// </summary>
        Copper = 1,

        /// <summary>
        /// Сталь
        /// </summary>
        Steel = 2,

        /// <summary>
        /// Железо
        /// </summary>
        Iron = 3,

        /// <summary>
        /// Хром
        /// </summary>
        Chrome = 4
    }
}
