namespace PracticalTest
{
    public interface IPerson
    {
        string Name { get; }
        string HairColor { get; }
        IPerson Mother { get; }
        IPerson Father { get; }
    }

    public interface IPracticalTwo
    {
        string[] NamesOfAllAncestors(IPerson person);
        string ModeHairColorOfAllAncestors(IPerson person);
    }
}
