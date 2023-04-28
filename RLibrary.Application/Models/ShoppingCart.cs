using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Models
{
    public class ShoppingCart
    {
        public virtual int Id { get; protected internal set; }
        public virtual decimal TotalPrice { get; protected internal set; }
        public virtual string Currency { get; protected internal set; }
        public virtual ShoppingCartStatus Status { get; protected internal set; }
        public virtual IList<ShoppingCartItem> Items { get; protected internal set; }
    }
}
