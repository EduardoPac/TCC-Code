using SQLite;

namespace TCC_v1.Model.Entities
{
    public class FieldAnswer : ObservatoryBaseObject
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public int IdFormAnswer { get; set; }

        private string question;

        public string Question
        {
            get => question;
            set
            {
                question = value;
                OnPropertyChanged();
            }
        }

        private string answer;

        public string Answer
        {
            get => answer;
            set
            {
                answer = value;
                OnPropertyChanged();
            }
        }

        public FieldAnswer()
        {
            question = "";
            answer = "";
        }
    }
}