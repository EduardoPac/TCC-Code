using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using TCC_v1.Infra;
using TCC_v1.Model.Entities;
using Xamarin.Forms;

namespace TCC_v1.DAL
{
        public class DALA:IDisposable
        {
            private SQLiteConnection database;
            public DALA()
            {
                database = DependencyService.Get<SqliteDBConnection>().DbConnection();
                //cria uma tabela com a classe que é passada
                database.CreateTable<FormBD>();
                database.CreateTable<FieldBD>();
                database.CreateTable<ItemBD>();
        }
        //insere um objeto
        public void InsertForm(FormBD form)
        {
            database.Insert(form);
        }

        public void InsertField(FieldBD field)
        {
            database.Insert(field);
        }

        public void InsertItem(ItemBD item)
        {
            database.Insert(item);
        }

        //Atualiza um objeto
        public void UpdadeForm(FormBD form)
        {
            database.Update(form);
        }

        public void UpdadeField(FieldBD field)
        {
            database.Update(field);
        }

        public void UpdadeItem(ItemBD item)
        {
            database.Update(item);
        }

        //deleta um objeto
        public void DeleteForm(FormBD form)
        {
            database.Delete(form);
        }

        public void DeleteField(FieldBD field)
        {
            database.Delete(field);
        }

        public void DeleteItem(ItemBD item)
        {
            database.Delete(item);
        }

        //busca o objeto no banco
        //busca os formulario
        public FormBD getForm(int codigo)
        {
            return database.Table<FormBD>().FirstOrDefault(c => c.IDForm == codigo);
        }

        public List<FormBD> getFormList()
        {
            return database.Table<FormBD>().OrderBy(c => c.IDForm).ToList();
        }


        //teste
       
        public List<ItemBD> getItemList()
        {
            return database.Table<ItemBD>().OrderBy(c => c.IDItem).ToList();
        }






        //busca todos os fields do formulario
        public List<FieldBD> getFieldList(int codigoForm)
        {
            //teste
             List<FieldBD> aux = database.Table<FieldBD>().Where(c => c.IDFormP == codigoForm).ToList();

            return aux;
        }

        public List<ItemBD> getItemList(int codigoField)
        {
            //teste
            List<ItemBD> aux = database.Table<ItemBD>().Where(c => c.IDField2 == codigoField).ToList();

            return aux;
        }


        public void Dispose()
        {
            ;
        }
    }
    
}
