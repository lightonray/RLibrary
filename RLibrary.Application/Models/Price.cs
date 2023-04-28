using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Models
{
    public class Price 
    {
        public virtual int? Id { get; protected internal set; }
        public  decimal Amount { get; protected internal set; }
        public  string Currency { get; protected internal set; }
        public virtual Book Book { get; protected internal set; }

        public Price(
            decimal amount,
            string currency)
        {
            Amount = amount;
            Currency = currency;
        }

    }
}
