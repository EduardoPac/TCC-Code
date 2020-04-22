using SQLite;

namespace TCC_v1.Model.Entities
{
    public class FieldDb : ObservatoryBaseObject
    {
        [PrimaryKey, AutoIncrement] public int IdField { get; set; }
        public int IdForm { get; set; }

        private string fieldName;

        public string FieldName
        {
            get => fieldName;
            set
            {
                fieldName = value;
                OnPropertyChanged();
            }
        }


        private string description;

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        private string type;

        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }

        private int order;

        public int Order
        {
            get => order;
            set
            {
                order = value;
                OnPropertyChanged();
            }
        }

        private double min;

        public double Min
        {
            get => min;
            set
            {
                min = value;
                OnPropertyChanged();
            }
        }

        private double max;

        public double Max
        {
            get => max;
            set
            {
                max = value;
                OnPropertyChanged();
            }
        }

        private bool primaryKey;

        public bool PrimaryKey
        {
            get => primaryKey;
            set
            {
                primaryKey = value;
                OnPropertyChanged();
            }
        }

        private bool required;

        public bool Required
        {
            get => required;
            set
            {
                required = value;
                OnPropertyChanged();
            }
        }

        private bool controlled;

        public bool Controlled
        {
            get => controlled;
            set
            {
                controlled = value;
                OnPropertyChanged();
            }
        }

        private bool selectFromList;

        public bool SelectFromList
        {
            get => selectFromList;
            set
            {
                selectFromList = value;
                OnPropertyChanged();
            }
        }

        public FieldDb()
        {
            fieldName = "";
            description = "";
            type = "";
            order = 0;
            min = 0;
            max = 0;
            primaryKey = false;
            required = false;
            controlled = false;
        }
    }
}