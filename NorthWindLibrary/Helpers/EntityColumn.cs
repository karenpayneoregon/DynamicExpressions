using System;

namespace NorthWindLibrary.Helpers
{
    public class EntityColumn
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public string TypeName { get; set; }
        public bool Key { get; set; }
        public override string ToString() => Name;

    }
}
