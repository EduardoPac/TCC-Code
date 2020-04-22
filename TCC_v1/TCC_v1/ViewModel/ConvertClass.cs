using System;
using TCC_v1.DAL;
using TCC_v1.Model.Entities;
using Xamarin.Forms.Internals;

namespace TCC_v1.ViewModel
{
    public class ConvertClass
    {
        public static Form ConvertDataFormToForm(FormDb dataForm)
        {
            var data = new Database();

            var fields = data.GetFieldList(dataForm.Id);

            var form = new Form
            {
                Coordinator = dataForm.Coordinator,
                DataSetDescription = dataForm.DataSetDescription,
                DataSetName = dataForm.DataSetName,
                Status = dataForm.Status
            };

            fields.ForEach((field =>
            {
                var newField = new Field
                {
                    Controlled = field.Controlled,
                    Description = field.Description,
                    FieldName = field.FieldName,
                    Max = field.Max,
                    Min = field.Min,
                    Order = field.Order,
                    PrimaryKey = field.PrimaryKey,
                    Required = field.Required,
                    SelectFromList = field.SelectFromList,
                    Type = field.Type
                };
                form.Fields.Add(newField);
            }));

            for (var y = 0; y < fields.Count; y++)
            {
                if (form.Fields[y].SelectFromList != true) 
                    continue;

                var items = data.GetItemList(fields[y].IdField);

                foreach (var item in items) 
                    form.Fields[y].ListItems.Add(item);
            }

            return form;
        }

        public static FormAnswer CreateFormAnswer(Form form)
        {
            var newFormAnswer = new FormAnswer
            {
                CollectData = DateTimeOffset.Now.ToString(),
                Coordinator = form.Coordinator,
                DataSetDescription = form.DataSetDescription,
                DataSetName = form.DataSetName,
                Status = form.Status
            };

            return newFormAnswer;
        }
    }
}