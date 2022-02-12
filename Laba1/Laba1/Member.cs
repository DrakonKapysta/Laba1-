using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    class Member : IComparable<Member>, ICloneable
    {
        public Member(string name, string surname, TimeSpan start, TimeSpan finish)
        {
            Name = name;
            Surname = surname;
            TimeStart = start;
            TimeFinish = finish;
        }
        public Member()
        {

        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public TimeSpan TimeStart { get; set; }

        public TimeSpan TimeFinish { get; set; }
        public readonly static string PathForResults = @"D:\Laba1\INFO.txt";
        public readonly static string PathForMembers = @"D:\Laba1\members.txt";

        int IComparable<Member>.CompareTo(Member other)
        {

            if (other != null)
                return this.TimeFinish.CompareTo(other.TimeFinish);
            else
                throw new ArgumentException("Parameter is not a Member!");

        }
        public object Clone() => new Member(this.Name, this.Surname, this.TimeStart,this.TimeFinish);
    }
}
