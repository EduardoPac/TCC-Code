using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;

namespace TCC_v1.Model.Entities
{
    public class FormAnswerBD : ObservatorBaseObject
    {

        public FormAnswerBD()
        {
            datasetName = "";
            dataSetDescription = "";
            coordinator = "";
            status = "";
        }

        [PrimaryKey, AutoIncrement]
        public int IDFormAnswer { get; set; }
        
        public string datacoleta { get; set; }

        private string datasetName;

        public string DatasetName
        {
            get { return datasetName; }
            set { datasetName = value; OnPropertyChanged(); }
        }

        private string dataSetDescription;

        public string DataSetDescription
        {
            get { return dataSetDescription; }
            set { dataSetDescription = value; OnPropertyChanged(); }
        }

        private string coordinator;

        public string Coordinator
        {
            get { return coordinator; }
            set { coordinator = value; OnPropertyChanged(); }
        }

        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }
    }
}
