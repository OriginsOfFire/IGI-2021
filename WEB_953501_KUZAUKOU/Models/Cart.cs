using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953501_KUZAUKOU.Entities;

namespace WEB_953501_KUZAUKOU.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество калорий
        /// </summary>
        public int Strings
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.Guitar.Strings);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="dish">добавляемый объект</param>
        virtual public void AddToCart(Guitar guitar)
        {

            // если объект есть в корзине
            // то увеличить количество

            if (Items.ContainsKey(guitar.GuitarId))
                Items[guitar.GuitarId].Quantity++;
            // иначе - добавить объект в корзину

            else
                Items.Add(guitar.GuitarId, new CartItem
                {
                    Guitar = guitar,
                    Quantity = 1
                });

        }

        virtual public void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        virtual public void ClearAll()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public Guitar Guitar { get; set; }
        public int Quantity { get; set; }
    }
}
