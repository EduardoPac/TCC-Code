using System;
using System.Collections.Generic;
using TCC_v1.DAL;

namespace TCC_v1.Model.Entities
{
    public class Form : ObservatoryBaseObject
    {
        private string dataSetName;

        public string DataSetName
        {
            get => dataSetName;
            set
            {
                dataSetName = value;
                OnPropertyChanged();
            }
        }

        private string dataSetDescription;

        public string DataSetDescription
        {
            get => dataSetDescription;
            set
            {
                dataSetDescription = value;
                OnPropertyChanged();
            }
        }

        private string coordinator;

        public string Coordinator
        {
            get => coordinator;
            set
            {
                coordinator = value;
                OnPropertyChanged();
            }
        }

        private string status;

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        public List<Field> Fields { get; set; }

        public Form()
        {
            dataSetName = "";
            dataSetDescription = "";
            coordinator = "";
            status = "";
            Fields = new List<Field>();
        }
    }
}