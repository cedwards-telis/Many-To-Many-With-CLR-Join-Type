using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_To_Many_With_CLR_Join_Type
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Membership> Memberships { get; set; }
    }

    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
        public ICollection<Membership> GroupMemberships { get; set; }
    }

    public class Membership
    {
        public int PersonId { get; set; }
        public int GroupId { get; set; }
        public Person Person { get; set; }
        public Group Group { get; set; }
        public string MembershipDescription { get; set; }
    }
}
