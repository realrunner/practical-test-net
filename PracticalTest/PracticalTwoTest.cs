using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticalTest
{
    [TestClass]
    public class PracticalTwoTest
    {
        readonly IPracticalTwo _practicalTwo;

        public PracticalTwoTest()
        {
            //TODO: Instantiate your implementation
            _practicalTwo = null; //new PracticalTwo();
        }

        [TestMethod]
        public void NamesOfAllAncestorsTest()
        {
            IPerson person = GetFamilyTree();
            Console.WriteLine(person);
            var ancestors = _practicalTwo.NamesOfAllAncestors(person);
        }


        [TestMethod]
        public void ModeHairColorOfAllAncestors()
        {
           
        }


        class Person : IPerson
        {
            public string Name { get; set; }
            public string HairColor { get; set; }
            public IPerson Mother { get; set; }
            public IPerson Father { get; set; }
            public override string ToString()
            {
                return String.Format("{0} ({3}) Father: {1} Mother: {2}", Name, Father, Mother, HairColor);
            }
        }

        IEnumerable<string> GetNextHairColor()
        {
            var hairColors = new[] {"brown", "blond", "red", "white", "black"};
            for (int index=0;;index++)
            {
                if (index >= hairColors.Length)
                {
                    index = 0;
                }
                yield return hairColors[index];
            }
        }

        IPerson GetFamilyTree()
        {
            var lastNames = new[] {"Kiplagat", "Guerrouj", "Kimetto", "Kipsang", "Gebrselassie", "Tergat"};
            var firstNames = new[] {"Sue", "Courtney", "Jan", "Ashley", "Pat", "Kim"};

            var hairGenerator = GetNextHairColor().GetEnumerator();
            Func<string> nextHairColor = () =>
            {
                hairGenerator.MoveNext();
                return hairGenerator.Current;
            };

            var people = 
                (from lname in lastNames
                from fname in firstNames
                select new Person {Name = string.Format("{0} {1}", fname, lname), HairColor = nextHairColor() }
                ).ToArray();
            var children = new Queue<Person>(people);

            for (int i = 1; (i + 1) < people.Length; i += 2)
            {
                var child = children.Dequeue();
                var mother = people[i];
                var father = people[i + 1];
                child.Mother = mother;
                child.Father = father;
            }

            return people[0];
        }
    }
}
