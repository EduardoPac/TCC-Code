﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;

namespace TCC_v1.Model.Entities
{
    public class FormAnswer : ObservatoryBaseObject
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        
        public string CollectData { get; set; }

        private string dataSetName;

        public string DataSetName
        {
            get => dataSetName;
            set { dataSetName = value; OnPropertyChanged(); }
        }

        private string dataSetDescription;

        public string DataSetDescription
        {
            get => dataSetDescription;
            set { dataSetDescription = value; OnPropertyChanged(); }
        }

        private string coordinator;

        public string Coordinator
        {
            get => coordinator;
            set { coordinator = value; OnPropertyChanged(); }
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

        public FormAnswer()
        {
            dataSetName = "";
            dataSetDescription = "";
            coordinator = "";
            status = "";
        }
    }
}
