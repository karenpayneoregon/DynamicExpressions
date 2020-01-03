namespace NorthWindLibrary.Classes
{
    public class CountryItem
    {
        public int CountryIdentifier { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;

    }
}
