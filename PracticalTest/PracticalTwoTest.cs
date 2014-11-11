using System;
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
            _practicalTwo = new PracticalTwo();
        }

        [TestMethod]
        public void NamesOfAllAncestorsTest()
        {
            IPerson person = GetFamilyTree();
            var ancestors = _practicalTwo.NamesOfAllAncestors(person);
            
            Assert.AreEqual(36, ancestors.Length);
            Assert.IsFalse(ancestors.Contains("Sue Kiplagat"));
            Assert.IsTrue(ancestors.Contains("Pat Kiplagat"));
            Assert.IsTrue(ancestors.Contains("Kim Kipsang"));
            Assert.IsTrue(ancestors.Contains("Kim Tergat"));
            Assert.IsTrue(ancestors.Contains("Mickey Wilson"));
        }


        [TestMethod]
        public void ModeHairColorOfAllAncestors()
        {
            IPerson person = GetFamilyTree();
            var modeHair = _practicalTwo.ModeHairColorOfAllAncestors(person);
            Assert.AreEqual("white", modeHair);
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
            for (int index=3;;index++)
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
                ).Concat(new []{new Person{Name="Mickey Wilson", HairColor = nextHairColor()}}).ToArray();
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
