using SQLite;

namespace TCC_v1.Model.Entities
{
    public class FormDb : ObservatoryBaseObject
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }

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

        public FormDb()
        {
            dataSetName = "";
            dataSetDescription = "";
            coordinator = "";
            status = "";
        }
    }
}