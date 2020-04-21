using System.Collections.Generic;

namespace TCC_v1.Model.Entities
{
    public class Field
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public bool PrimaryKey { get; set; }
        public bool Required { get; set; }
        public bool Controlled { get; set; }
        public bool SelectFromList { get; set; }
        public List<Item> ListItems { get; set; }
        
        public Field()
        {
            FieldName = "";
            Description = "";
            Type = "";
            Order = 0;
            Min = 0;
            Max = 0;
            PrimaryKey = false;
            Required = false;
            Controlled = false;
            ListItems = new List<Item>();

        }
    }
}
