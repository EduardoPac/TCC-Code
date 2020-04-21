using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;
using SQLite;

namespace TCC_v1.Model.Entities
{
    public class FieldBD : ObservatorBaseObject
    {

        public FieldBD()
        {
            fieldName = "";
            description = "";
            type = "";
            order = 0;
            min = 0;
            max = 0;
            primaryKey = false;
            required = false;
            controled = false;

        }

        public int IDFormP { get; set; }
        [PrimaryKey,AutoIncrement]
        public int IDField { get; set; }


        private string fieldName;

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; OnPropertyChanged(); }
        }

        

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(); }
        }

        private int order;

        public int Order
        {
            get { return order; }
            set { order = value; OnPropertyChanged(); }
        }

        private double min;

        public double Min
        {
            get { return min; }
            set { min = value; OnPropertyChanged(); }
        }

        private double max;

        public double Max
        {
            get { return max; }
            set { max = value; OnPropertyChanged(); }
        }

        private Boolean primaryKey;

        public Boolean PrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; OnPropertyChanged(); }
        }

        private Boolean required;

        public Boolean Required
        {
            get { return required; }
            set { required = value; OnPropertyChanged(); }
        }

        private Boolean controled;

        public Boolean Controled
        {
            get { return controled; }
            set { controled = value; OnPropertyChanged(); }
        }

        private Boolean selectFromList;

        public Boolean SelectFromList
        {
            get { return selectFromList; }
            set { selectFromList = value; OnPropertyChanged(); }
        }

    }
}
