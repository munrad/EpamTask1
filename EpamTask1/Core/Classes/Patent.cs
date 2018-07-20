using System;
using System.Collections.Generic;
using System.Linq;
using EpamTask1.Core.Attributes;
using EpamTask1.Core.Interfaces;

namespace EpamTask1.Core.Classes
{
    public class Patent : IPatent
    {
        public int RegNumber { get; set; }
        [IsNotNullOrEmpty]
        public string Country { get; set; }
        [IsNotNullOrEmpty]
        public List<string> Inventors { get; set; }
        [IsNotNullOrEmpty]
        [Limit(PubYear = 1950)]
        public DateTime AppDate { get; set; }
        [IsNotNullOrEmpty]
        [Limit(PubYear = 1950)]
        public DateTime PubDate { get; set; }
        [IsNotNullOrEmpty]
        public string Name { get; set; }
        [Limit(Lenght = 500)]
        public string Note { get; set; }
        public int CountPages { get; set; }
        public int PubYear { get; set; }
        [IsNotNullOrEmpty]
        [IsNotLessZero]
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Patent) obj);
        }

        protected bool Equals(Patent other)
        {
            return RegNumber == other.RegNumber && string.Equals(Country, other.Country) && Equals(Inventors, other.Inventors) 
                   && AppDate.Equals(other.AppDate) && PubDate.Equals(other.PubDate) && string.Equals(Name, other.Name) && string.Equals(Note, other.Note) && CountPages == other.CountPages;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = RegNumber;
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Inventors != null ? Inventors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AppDate.GetHashCode();
                hashCode = (hashCode * 397) ^ PubDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CountPages;
                return hashCode;
            }
        }

        public int CompareTo(object obj)
        {
            var newObj = obj as Patent;
            if (ReferenceEquals(this, newObj))
                return 0;
            else if (newObj == null)
                return 1;


            var cmp = Inventors.OrderBy(t => t).SequenceEqual(newObj.Inventors.OrderBy(t => t)) ? 1 : 0;
            if (cmp != 0)
                return cmp;

            cmp = DateTime.Compare(PubDate, newObj.PubDate);
            if (cmp != 0)
                return cmp;

            cmp = DateTime.Compare(AppDate, newObj.AppDate);
            if (cmp != 0)
                return cmp;

            cmp = string.Compare(Country, newObj.Country, StringComparison.Ordinal);
            if (cmp != 0)
                return cmp;

            cmp = string.Compare(Name, newObj.Name, StringComparison.Ordinal);
            if (cmp != 0)
                return cmp;

            cmp = RegNumber.CompareTo(newObj.RegNumber);
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

            cmp = PubYear.CompareTo(newObj.PubYear);
            if (cmp != 0)
                return cmp;

            return 0;
        }
    }
}
