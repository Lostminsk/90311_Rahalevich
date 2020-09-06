using System;
using System.Collections.Generic;
using System.Text;

namespace _90311_Rahalevich.DAL.Entities
{
    public class Insulin
    {
         
        public int InsulinId { get; set; } // id 
        public string InsulinName { get; set; } // название
        public string Publisher { get; set; } // изготовитель
        public int Rating { get; set; } // рейтинг 
        public string Image { get; set; } // имя файла изображения

        // Навигационные свойства
        /// <summary>
        
        /// </summary>
        public int InsulinGroupId { get; set; }
        public InsulinGroup Group { get; set; }
    }
}

