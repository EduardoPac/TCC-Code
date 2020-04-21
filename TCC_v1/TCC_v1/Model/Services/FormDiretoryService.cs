using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using TCC_v1.Model.Entities;
using TCC_v1.DAL;
using System.Collections.Generic;
using System;

namespace TCC_v1.Model.Services
{
    class FormDiretoryService
    {
         public Boolean LoadFormsDirectorySqlite(string name, FormBD comp)
        {

            // conectar com o sqlite

            DALA dbManager = new DALA();
            ObservableCollection<FormBD> form = new ObservableCollection<FormBD>(dbManager.getFormList());
            
            FormBDDiretory formDiretory = new FormBDDiretory();
            
            for(int i = 0; i < form.Count; i++)
            {
                if (form[i].DatasetName == comp.DatasetName)
                {
                    return false;
                }
            }
            

            //////Apenas teste//////////
            ///// Para adicionar um novo teste ////

            ObservableCollection<Form> formte = new ObservableCollection<Form>();

            FormBDDiretory formDirectory = new FormBDDiretory();

            Form formul;

            string filename = name;

            var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
            Stream str = assembly.GetManifestResourceStream("TCC_v1."+filename);


            string text = "";
            using (var reader = new System.IO.StreamReader(str))
            {
                text = reader.ReadToEnd();
            }

            formul = Newtonsoft.Json.JsonConvert.DeserializeObject<Form>(text);

            FormBD formsave = new FormBD();

            formsave.Coordinator = formul.Coordinator;
            formsave.DataSetDescription = formul.DataSetDescription;
            formsave.DatasetName = formul.DatasetName;
            formsave.Status = formul.Status;

            dbManager.InsertForm(formsave);
            
            List<FieldBD> fieldssave = new List<FieldBD>();

            for (int x = 0; x < formul.Fields.Count; x++)
            {
                FieldBD aux2 = new FieldBD();
                aux2.IDFormP = formsave.IDForm;
                //aux2.IDField = formsave.IDForm+x;
                aux2.Controled = formul.Fields[x].Controled;
                aux2.Description = formul.Fields[x].Description;
                aux2.FieldName = formul.Fields[x].FieldName;
                aux2.Max = formul.Fields[x].Max;
                aux2.Min = formul.Fields[x].Min;
                aux2.Order = formul.Fields[x].Order;
                aux2.PrimaryKey = formul.Fields[x].PrimaryKey;
                aux2.Required = formul.Fields[x].Required;
                aux2.SelectFromList = formul.Fields[x].SelectFromList;
                aux2.Type = formul.Fields[x].Type;

                fieldssave.Add(aux2);
            }

            for (int x = 0; x < fieldssave.Count; x++)
            {
                dbManager.InsertField(fieldssave[x]);
            }

            List<ItemBD> itemsave = new List<ItemBD>();

            
            for (int x = 0; x < formul.Fields.Count; x++)
            {
                if (formul.Fields[x].SelectFromList == true)
                {
                    for (int y = 0; y < formul.Fields[x].ListItens.Count; y++)
                    {
                        ItemBD aux2 = new ItemBD();
                        aux2.IDFormP2 = formsave.IDForm;
                        //aux2.IDItem = fieldssave[x].IDField + y + rdn.Next(100, 10000) / 10;
                        aux2.IDField2 = fieldssave[x].IDField;
                        aux2.CodigoItem = formul.Fields[x].ListItens[y].CodigoItem;
                        aux2.Name = formul.Fields[x].ListItens[y].Name;
                        itemsave.Add(aux2);
                    }
                }

            }


            for (int y = 0; y < itemsave.Count; y++)
            {
                dbManager.InsertItem(itemsave[y]);
            }

            return true;

           // formDirectory.FormBD = formsave;
           
        }
    }
}
