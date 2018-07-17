using System;
using EpamTask1.Core.Interfaces;

namespace EpamTask1.Core.Classes
{
    public class Paper : IPaper
    {
        public int Number { get; set; }
        public string Issn { get; set; }
        public DateTime Date { get; set; }
        public string PubCity { get; set; }
        public string PubName { get; set; }
        public int PubYear { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int CountPages { get; set; }

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
    }
}
