using System;
using System.Collections.Generic;
using TCC_v1.DAL;

namespace TCC_v1.Model.Entities
{
    public class Form : ObservatorBaseObject
    {


        public Form()
        {
            datasetName = "";
            dataSetDescription = "";
            coordinator = "";
            status = "";
            fields = new List<Field>();
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
            set { status= value; OnPropertyChanged(); }
        }

        public List<Field> Fields { get => fields; set => fields = value; }

        private List<Field> fields;

    }
}
