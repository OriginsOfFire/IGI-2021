using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;
using WEB_953501_KUZAUKOU.Entities;
using WEB_953501_KUZAUKOU.Extensions;
using WEB_953501_KUZAUKOU.Models;

namespace WEB_953501_KUZAUKOU.Services
{
    public class CartService : Cart
    {
        private string sessionKey = "cart";

        [JsonIgnore]
        ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider sp)
        {
            var session = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            var cart = session?.Get<CartService>("cart")
            ?? new CartService();
            cart.Session = session;
            return cart;
        }

        public override void AddToCart(Guitar guitar)
        {
            base.AddToCart(guitar);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>(sessionKey, this);
        }
    }
}
