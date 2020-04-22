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
    public class DatabaseAnswer : IDisposable
    {
        private readonly SQLiteConnection database;

        public DatabaseAnswer()
        {
            database = DependencyService.Get<ISqLiteDbConnection>().DbConnection();
            database.CreateTable<FormAnswer>();
            database.CreateTable<FieldAnswer>();
        }

        public void InsertFormAnswer(FormAnswer form) => database.Insert(form);
        public void InsertFieldAnswer(FieldAnswer field) => database.Insert(field);

        public IEnumerable<FormAnswer> GetFormList() =>
            database.Table<FormAnswer>().OrderBy(c => c.Id).ToList();

        public List<FieldAnswer> GetFieldList() =>
            database.Table<FieldAnswer>().OrderBy(c => c.IdFormAnswer).ToList();

        public List<FieldAnswer> GetFieldList(int idForm) =>
            database.Table<FieldAnswer>().Where(c => c.IdFormAnswer == idForm)
                .ToList();

        public void Dispose()
        {
        }
    }
}