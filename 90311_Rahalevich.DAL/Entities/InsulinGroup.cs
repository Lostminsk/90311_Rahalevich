using System;
using System.Collections.Generic;
using System.Text;

namespace _90311_Rahalevich.DAL.Entities
{
    public class InsulinGroup
    {
        public int InsulinGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Insulin> Insulins { get; set; }
    }
}
