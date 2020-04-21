using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;

namespace TCC_v1.Model.Entities
{
    public class FormAnswer : ObservatorBaseObject
    {

        
        public FormAnswer()
        {
            datasetName = "";
            dataSetDescription = "";
            coordinator = "";
            status = "";
            fields = new List<FieldAnswerBD>();
        }

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

        private List<FieldAnswerBD> fields;

        public List<FieldAnswerBD> Fields { get => fields; set => fields = value; }
        
    }
}
