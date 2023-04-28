using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Models
{
    public class ShoppingCartItem
    {
        public virtual int Id { get; protected internal set; }
        public virtual int BookId { get; protected internal set; }
        public virtual int PriceId { get; protected internal set; }
        public virtual int ShoppingCartId { get; protected internal set; }
        public virtual Book Book { get; protected internal set; }
        public virtual Price Price { get; protected internal set; }
        public virtual ShoppingCart ShoppingCart { get; protected internal set; }
    }
}
