using PeopleParser.BusinessLogic;
using PeopleParser.Proxy;
using System;

namespace PeopleParser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var peopleBL = new PeopleBL(new PeopleServiceProxy()); //can be initalized using dependency injection

                //print cat names under a female owner 
                var maleOwnerCatCollection = peopleBL.GetAllPetNameCollection(Gender.Male, PetType.Cat).Result;
                Console.WriteLine("MALE");
                Console.WriteLine("=====================");
                foreach (var item in maleOwnerCatCollection)
                    Console.WriteLine(item);


                Console.WriteLine();

                //print cat names under a female owner 
                var femaleOwnerCatCollection = peopleBL.GetAllPetNameCollection(Gender.Female, PetType.Cat).Result;
                Console.WriteLine("FEMALE");
                Console.WriteLine("=====================");
                foreach (var item in femaleOwnerCatCollection)
                    Console.WriteLine(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.Read();
        }
    }
}