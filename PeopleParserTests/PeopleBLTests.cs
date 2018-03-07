using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using PeopleParser.BusinessEntitites;
using PeopleParser.BusinessLogic;
using PeopleParser.Proxy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleParser.Tests
{
    [TestClass()]
    public class PeopleBLTests
    {
        private MockFactory _factory = new MockFactory();

        [TestMethod()]
        public void GetAllPetNameCollection_OnExecute_ShouldReturnOnlyFilteredElements()
        {
            var mock = _factory.CreateMock<IPeopleServiceProxy>();
            List<People> collection = GetMockData();

            mock.Expects.One.MethodWith(_ => _.GetAll()).WillReturn(Task.FromResult(collection.AsEnumerable()));
            var peopleBL = new PeopleBL(mock.MockObject);
            var result = peopleBL.GetAllPetNameCollection(Gender.Male, PetType.Cat).Result.ToList();

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Any(a => a == "Garfield"));
            Assert.IsTrue(result.Any(a => a == "Simba"));
            Assert.IsFalse(result.Any(a => a == "Fido"));
            Assert.IsFalse(result.Any(a => a == "Tom"));
            Assert.IsFalse(result.Any(a => a == "Tabby"));
        }

        [TestMethod()]
        public void GetAllPetNameCollection_OnExecute_ShouldReturnElementsInOrder()
        {
            var mock = _factory.CreateMock<IPeopleServiceProxy>();
            List<People> collection = GetMockData();

            mock.Expects.One.MethodWith(_ => _.GetAll()).WillReturn(Task.FromResult(collection.AsEnumerable()));
            var peopleBL = new PeopleBL(mock.MockObject);
            var result = peopleBL.GetAllPetNameCollection(Gender.Male, PetType.Cat).Result.ToList();
            Assert.IsTrue(result[0] == "Garfield");
            Assert.IsTrue(result[1] == "Simba");
        }

        private static List<People> GetMockData()
        {
            var collection = new List<People>();
            collection.Add(new People()
            {
                Name = "Bob",
                Age = 20,
                Gender = Gender.Male,
                Pets = new List<Pet>()
                {
                        new Pet(){ Name= "Garfield", Type= PetType.Cat },
                        new Pet(){ Name= "Fido", Type= PetType.Dog }
                }
            });
            collection.Add(new People()
            {
                Name = "Steve",
                Age = 20,
                Gender = Gender.Male,
                Pets = new List<Pet>()
                {
                        new Pet(){ Name= "Simba", Type= PetType.Cat }
                }
            });
            collection.Add(new People()
            {
                Name = "Jennifer",
                Age = 18,
                Gender = Gender.Female,
                Pets = new List<Pet>()
                {
                        new Pet(){ Name= "Tom", Type= PetType.Cat },
                        new Pet(){ Name= "Tabby", Type= PetType.Cat }
                }
            });
            return collection;
        }
    }
}