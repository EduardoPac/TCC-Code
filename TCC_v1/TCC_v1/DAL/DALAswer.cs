using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.Infra;
using TCC_v1.Model.Entities;
using Xamarin.Forms;

namespace TCC_v1.DAL
{
    public class DALAswer : IDisposable
    {

        private SQLiteConnection database;
        public DALAswer()
        {
            database = DependencyService.Get<SqliteDBConnection>().DbConnection();
            //cria uma tabela com a classe que é passada
            database.CreateTable<FormAnswerBD>();
            database.CreateTable<FieldAnswerBD>();
        }


        public void InsertFormA(FormAnswerBD form)
        {
            database.Insert(form);
        }

        public void InsertFieldA(FieldAnswerBD field)
        {
            database.Insert(field);
        }
        

        //Atualiza um objeto
        public void UpdadeFormA(FormAnswerBD form)
        {
            database.Update(form);
        }

        public void UpdadeFieldA(FieldAnswerBD field)
        {
            database.Update(field);
        }
        

        //deleta um objeto
        public void DeleteFormA(FormAnswerBD form)
        {
            database.Delete(form);
        }

        public void DeleteFieldA(FieldAnswerBD field)
        {
            database.Delete(field);
        }
        

        //busca o objeto no banco
        //busca os formulario
        public FormAnswerBD getFormA(int codigo)
        {
            return database.Table<FormAnswerBD>().FirstOrDefault(c => c.IDFormAnswer == codigo);
        }

        public List<FormAnswerBD> getFormListA()
        {
            return database.Table<FormAnswerBD>().OrderBy(c => c.IDFormAnswer).ToList();
        }

        //teste
        public List<FieldAnswerBD> getFieldListA()
        {
            return database.Table<FieldAnswerBD>().OrderBy(c => c.IDFormAnswer1).ToList();
        }

        //busca todos os fields do formulario
        public List<FieldAnswerBD> getFieldList(int codigoForm)
        {
            //teste
            List<FieldAnswerBD> aux = database.Table<FieldAnswerBD>().Where(c => c.IDFormAnswer1 == codigoForm).ToList();

            return aux;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
