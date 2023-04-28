using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Models
{
    public class Book
    {
        public virtual int Id { get; protected internal set; }
        public virtual string Title { get; protected internal set; }
        public virtual string Description { get; protected internal set; }
        public virtual string Author { get; protected internal set; }
        public virtual int Quanitity { get; protected internal set; }
        public virtual string FileId { get; protected internal set; }
        public virtual int GenreId { get; protected internal set; }
        public virtual int PriceId { get; protected internal set; }
        public virtual Genre Genre { get; protected internal set; }
        public virtual Price Price { get; protected internal set; }

        protected Book()
        {

        }
        protected Book(
            string title,
            string description,
            int? genreId,
            int quanitity,
            Price price)
        {
            if (genreId is null
                || genreId < default(long))
            {
                throw new ArgumentNullException(
                    nameof(genreId),
                    "Book genre can't be null or negative");
            }

            GenreId = (int)genreId;

            ChangePrice(price);

            Update(
                title: title,
                description: description,
                quanitity: quanitity);
        }


        public static Book Create(string Title,
            string description,
            int? genreId,
            int quanitity,
            Price price)
        {
            return new Book(
               title: Title,
               description: description,
               genreId: genreId,
               quanitity: quanitity,
               price: price);
        }

        public void ChangePrice(
            Price price)
        {
            if (price is null)
            {
                throw new System.Exception("You can't set a null price!");
            }

            if (price.Id == PriceId)
            {
                throw new System.ArgumentException("You can't set the same price!");
            }

            PriceId = (int)price.Id;
            Price = price;
        }

        public void Update(
            string title,
            string description,
            int quanitity)
        {
            if (title == null)
            {
                throw new ArgumentNullException(
                    nameof(title),
                    "Book title can't be null");
            }

            if (description == null
                || description.Length > 256)
            {
                throw new ArgumentNullException(
                    nameof(description),
                    "Invalid description. " +
                    "Description can't be null or more then 256 chars");
            }

            if (quanitity < default(int))
            {
                throw new ArgumentNullException(
                    nameof(quanitity),
                    "Invalid quantity. " +
                    "Quantity should be a positive number or zero");
            }

            Title = title;
            Description = description;
            Quanitity = quanitity;
        }
    }
}
