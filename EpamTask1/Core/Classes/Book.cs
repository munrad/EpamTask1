using System;
using System.Collections.Generic;
using EpamTask1.Core.Attributes;
using EpamTask1.Core.Interfaces;

namespace EpamTask1.Core.Classes
{
    public class Book : IBook
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
    }
}
