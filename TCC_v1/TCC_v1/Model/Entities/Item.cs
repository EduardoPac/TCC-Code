using SQLite;

namespace TCC_v1.Model.Entities
{
    public class Item : ObservatoryBaseObject
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public int IdField { get; set; }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string idItem;

        public string IdItem
        {
            get => idItem;
            set
            {
                idItem = value;
                OnPropertyChanged();
            }
        }
    }
}