using System.Collections.ObjectModel;
using System.Reflection;
using TCC_v1.Model.Entities;
using TCC_v1.DAL;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Internals;

namespace TCC_v1.Model.Services
{
    internal static class FormDirectoryService
    {
        public static bool LoadFormsDirectorySqLite(string name, FormDb comp)
        {
            var dbManager = new Database();
            var dataForm = new ObservableCollection<FormDb>(dbManager.GetFormList());

            if (dataForm.Any(f => f.DataSetName == comp.DataSetName))
                return false;

            var filename = name;

            var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
            var str = assembly.GetManifestResourceStream("TCC_v1.JsonForms." + filename);

            var text = "";
            using (var reader = new System.IO.StreamReader(str))
            {
                text = reader.ReadToEnd();
            }

            var form = Newtonsoft.Json.JsonConvert.DeserializeObject<Form>(text);

            var newForm = new FormDb
            {
                Coordinator = form.Coordinator,
                DataSetDescription = form.DataSetDescription,
                DataSetName = form.DataSetName,
                Status = form.Status
            };

            dbManager.InsertForm(newForm);

            var newFields = form.Fields.Select(field => new FieldDb
                {
                    IdForm = newForm.Id,
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
                })
                .ToList();

            newFields.ForEach(field => dbManager.InsertField(field));

            var newItems = new List<Item>();

            for (var x = 0; x < form.Fields.Count; x++)
            {
                if (form.Fields[x].SelectFromList != true)
                    continue;

                foreach (var item in form.Fields[x].ListItems)
                {
                    var newItem = new Item();
                    newItem.IdField = newFields[x].IdField;
                    newItem.IdItem = item.IdItem;
                    newItem.Name = item.Name;
                    newItems.Add(newItem);
                }
            }

            newItems.ForEach(item => dbManager.InsertItem(item));

            return true;
        }
    }
}