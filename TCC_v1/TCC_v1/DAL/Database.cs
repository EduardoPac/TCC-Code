using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using TCC_v1.Infra;
using TCC_v1.Model.Entities;
using Xamarin.Forms;

namespace TCC_v1.DAL
{
    public class Database : IDisposable
    {
        private readonly SQLiteConnection database;

        public Database()
        {
            database = DependencyService.Get<ISqLiteDbConnection>().DbConnection();
            database.CreateTable<FormDb>();
            database.CreateTable<FieldDb>();
            database.CreateTable<Item>();
        }

        public void InsertForm(FormDb form) => database.Insert(form);
        public void InsertField(FieldDb field) => database.Insert(field);
        public void InsertItem(Item item) => database.Insert(item);

        public IEnumerable<FormDb> GetFormList() =>
            database.Table<FormDb>().OrderBy(c => c.Id).ToList();

        public List<FieldDb> GetFieldList(int idForm) =>
            database.Table<FieldDb>().Where(c => c.IdForm == idForm).ToList();

        public List<Item> GetItemList(int idField) =>
            database.Table<Item>().Where(c => c.IdField == idField).ToList();

        public void Dispose()
        {
        }
    }
}