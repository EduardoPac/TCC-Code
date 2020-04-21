using SQLite;
using System;
using TCC_v1.DAL;

namespace TCC_v1.Model.Entities
{
    public class FieldAnswerBD : ObservatorBaseObject
    {
        public FieldAnswerBD()
        {
            question = "";
            answer = "";
        }

        [PrimaryKey, AutoIncrement]
        public int IDquestion { get; set; }

        public int IDFormAnswer1 { get; set; }

        private string question;

        public string Question
        {
            get => question;
            set { question = value; OnPropertyChanged(); }
        }

        private string answer;

        public string Answer
        {
            get => answer;
            set {answer = value; OnPropertyChanged(); }
        }
    }
}
