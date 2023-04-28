using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Models
{
    public class Genre
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; protected internal set; }
        public virtual IList<Book> Books { get; protected internal set; }


        protected Genre()
        {
        }

        protected Genre(string name)
        {
            Name = name;
        }

        public static Genre Create(string name)
        {
            return new Genre(name);
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
