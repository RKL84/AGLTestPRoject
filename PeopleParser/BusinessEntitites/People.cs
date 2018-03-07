using System.Collections.Generic;

namespace PeopleParser.BusinessEntitites
{
    public class People
    {
        public People()
        {
            Pets = new List<Pet>();
        }

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public IList<Pet> Pets { get; set; }
    }
}
