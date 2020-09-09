using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _90311_Rahalevich.DAL.Entities;

namespace _90311_Rahalevich.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Общий рейтинг
        /// </summary>
        public int Rating
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Insulin.Rating);
            }
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="insulin">добавляемый объект</param>
        public virtual void AddToCart(Insulin insulin)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(insulin.InsulinId))
                Items[insulin.InsulinId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(insulin.InsulinId, new CartItem
                {
                    Insulin = insulin, Quantity = 1
                });
        }

        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Insulin Insulin { get; set; }
        public int Quantity { get; set; }
    }

}
