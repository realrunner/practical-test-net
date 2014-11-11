using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest
{
    class PracticalTwo : IPracticalTwo
    {
        IEnumerable<IPerson> GetAncestors(IPerson person)
        {
            if (person == null) return new IPerson[0];
;            return
                (new[] {person.Mother, person.Father})
                    .Concat(GetAncestors(person.Mother))
                    .Concat(GetAncestors(person.Father))
                    .Where(x => x != null);
        }

        public string[] NamesOfAllAncestors(IPerson person)
        {
            return GetAncestors(person).Select(p => p.Name).ToArray();
        }

        public string ModeHairColorOfAllAncestors(IPerson person)
        {
            return
                GetAncestors(person)
                    .GroupBy(p => p.HairColor)
                    .OrderBy(g => g.Count())
                    .Last()
                    .Key;
        }
    }
}
