using System;
using EpamTask1.Core.Attributes;
using EpamTask1.Core.Interfaces;

namespace EpamTask1.Core.Classes
{
    public class Paper : IPaper
    {
        [IsNotLessZero]
        public int Number { get; set; }
        public string Issn { get; set; }
        [IsNotNullOrEmpty]
        public DateTime Date { get; set; }
        public string PubCity { get; set; }
        [IsNotNullOrEmpty]
        public string PubName { get; set; }
        public int PubYear { get; set; }
        [IsNotNullOrEmpty]
        public string Name { get; set; }
        [Limit(Lenght = 500)]
        public string Note { get; set; }
        [Limit(CountPages = 1)]
        public int CountPages { get; set; }
        [IsNotLessZero]
        [IsNotNullOrEmpty]
        public int Price { get; set ; }
        [IsNotLessZero]
        public int CountCopies { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Paper) obj);
        }

        protected bool Equals(Paper other)
        {
            return Number == other.Number && string.Equals(Issn, other.Issn) && Date.Equals(other.Date) 
                   && string.Equals(PubCity, other.PubCity) && string.Equals(PubName, other.PubName) && PubYear.Equals(other.PubYear) 
                   && string.Equals(Name, other.Name) && string.Equals(Note, other.Note) && CountPages == other.CountPages;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Number;
                hashCode = (hashCode * 397) ^ (Issn != null ? Issn.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Date.GetHashCode();
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
            var newObj = obj as Paper;
            if (ReferenceEquals(this, newObj))
                return 0;
            else if (newObj == null)
                return 1;

            var cmp = string.Compare(Issn, newObj.Issn, StringComparison.Ordinal);
            if (cmp != 0)
                return cmp;

            cmp = DateTime.Compare(Date, newObj.Date);
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

            cmp = Number.CompareTo(newObj.Number);
            if (cmp != 0)
                return cmp;

            cmp = CountCopies.CompareTo(newObj.CountCopies);
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
