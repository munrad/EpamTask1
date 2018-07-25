using System;
using System.Collections.Generic;
using System.Linq;
using EpamTask1.Core.Attributes;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core.Classes
{
    public class Book : ILetters
    {
        public string Isbn { get; set; }
        [IsNotNullOrEmpty]
        public List<string> Authors { get; set; } 
        [IsNotNullOrEmpty]
        public string PubCity { get; set; }
        [IsNotNullOrEmpty]
        public string PubName { get; set; }
        [Limit(PubYear = 1900)]
        public int PubYear { get; set; }
        [IsNotNullOrEmpty]
        public string Name { get; set; }
        [Limit(Lenght = 500)]
        public string Note { get; set; }
        [Limit(CountPages = 1)]
        public int CountPages { get; set; }
        [IsNotLessZero]
        [IsNotNullOrEmpty]
        public int Price { get; set; }
        [IsNotLessZero]
        public int CountCopies { get; set; }

        public Book()
        {
            Authors = new List<string>();
            Isbn = PubCity = Name = Note = PubName = "";
            CountPages = 1;
            Price = CountCopies = 0;
            PubYear = 1900;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(Book) && Equals((Book) obj);
        }

        protected bool Equals(Book other)
        {
            return string.Equals(Isbn, other.Isbn) && Equals(Authors, other.Authors) && string.Equals(PubCity, other.PubCity) 
                   && string.Equals(PubName, other.PubName) && PubYear.Equals(other.PubYear) 
                   && string.Equals(Name, other.Name) && string.Equals(Note, other.Note) && CountPages == other.CountPages;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Isbn != null ? Isbn.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Authors != null ? Authors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PubCity != null ? PubCity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PubName != null ? PubName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PubYear.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CountPages;
                return hashCode;
            }
        }

        public int CompareTo(object obj)
        {
            var newObj = obj as Book;
            if (ReferenceEquals(this, newObj))
                return 0;
            else if (newObj == null)
                return 1;

            var cmp = string.Compare(Isbn, newObj.Isbn, StringComparison.Ordinal);
            if (cmp != 0)
                return cmp;

            cmp = Authors.OrderBy(t => t).SequenceEqual(newObj.Authors.OrderBy(t => t)) ? 1 : 0;
            if (cmp != 0)
                return cmp;

            cmp = string.Compare(Name, newObj.Name, StringComparison.Ordinal);
            if (cmp != 0)
                return cmp;

            cmp = string.Compare(PubCity, newObj.PubCity, StringComparison.Ordinal);
            if (cmp != 0)
                return cmp;

            cmp = string.Compare(PubName, newObj.PubName, StringComparison.Ordinal);
            if (cmp != 0)
                return cmp;

            cmp = PubYear.CompareTo(newObj.PubYear);
            if (cmp != 0)
                return cmp;

            cmp = string.Compare(Note, newObj.Note, StringComparison.Ordinal);
            if (cmp != 0)
                return cmp;

            cmp = CountPages.CompareTo(newObj.CountPages);
            if (cmp != 0)
                return cmp;

            cmp = Price.CompareTo(newObj.Price);
            if (cmp != 0)
                return cmp;

            cmp = CountCopies.CompareTo(newObj.CountCopies);
            if (cmp != 0)
                return cmp;

            return 0;
        }
    }
}
