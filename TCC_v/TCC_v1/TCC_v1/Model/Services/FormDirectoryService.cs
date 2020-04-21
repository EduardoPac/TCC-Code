using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TCC_v1.Model.Entities;

namespace TCC_v1.Model.Services
{
    internal static class FormDirectoryService
    {
        public static FormDirectory LoadFormsDirectory()
        {
            var list = new ObservableCollection<Form>();

            var formDirectory = new FormDirectory();

            var assembly = typeof(FormDirectoryService).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("TCC_v1.FormsJson.form1.json");
            string data1;
            using (var reader = new StreamReader(stream))
            {
                data1 = reader.ReadToEnd();
            }

            Stream stream2 = assembly.GetManifestResourceStream("TCC_v1.FormsJson.form2.json");
            string data2;
            using (var reader = new StreamReader(stream2))
            {
                data2 = reader.ReadToEnd();
            }

            var form1 = JsonConvert.DeserializeObject<Form>(data1);
            var form2 = JsonConvert.DeserializeObject<Form>(data2);
            
            list.Add(form1);
            list.Add(form2);

            formDirectory.Form = list;

            return formDirectory;
        }
    }
}
