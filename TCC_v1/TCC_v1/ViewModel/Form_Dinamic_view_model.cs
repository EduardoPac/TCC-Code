using System.Collections.Generic;
using TCC_v1.DAL;
using TCC_v1.Model.Entities;
using Xamarin.Forms.Internals;

namespace TCC_v1.ViewModel
{
    public class FormDynamicViewModel
    {
        public static void SaveData(List<FieldAnswer> fieldAnswers, Form form)
        {
            var fieldAnswer = ConvertClass.CreateFormAnswer(form);

            var data = new DatabaseAnswer();
            data.InsertFormAnswer(fieldAnswer);

            foreach (var answers in fieldAnswers)
            {
                answers.IdFormAnswer = fieldAnswer.Id;
            }

            fieldAnswers.ForEach((answer => data.InsertFieldAnswer(answer)));
        }
    }
}