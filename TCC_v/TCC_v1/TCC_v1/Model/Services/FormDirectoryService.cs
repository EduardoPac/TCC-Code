using System.Collections.ObjectModel;
using TCC_v1.Model.Entities;

namespace TCC_v1.Model.Services
{
    internal static class FormDirectoryService
    {
        public static FormDirectory LoadFormsDirectorySqlite()
        {
            var form = new ObservableCollection<Form>();

            var formDirectory = new FormDirectory();

            var test = new Form
            {
                DataSetName = "Vacina H1N1",
                DataSetDescription = "Formulario de vacinação da downça H1N1",
                Coordinator = "cordenador",
                Status = "active"
            };


            var f1 = new Field();
            var f2 = new Field();
            var f3 = new Field();
            var f4 = new Field();
            var f5 = new Field();

            f1.FieldName = "Nome do Paciente";
            f1.Type = "String";
            f1.Min = 0;
            f1.Max = 50;
            f1.PrimaryKey = true;
            f1.Required = false;
            f1.Controlled = true;
            f1.SelectFromList = false;

            f2.FieldName = "Idade do Paciente";
            f2.Type = "Number";
            f2.Min = 0;
            f2.Max = 20;
            f2.PrimaryKey = false;
            f2.Required = false;
            f2.Controlled = false;
            f2.SelectFromList = false;

            f3.FieldName = "Data de Nascimento";
            f3.Type = "Date";
            f3.Min = 12112015;
            f3.Max = 30112030;
            f3.PrimaryKey = false;
            f3.Required = true;
            f3.Controlled = true;
            f3.SelectFromList = false;

            f4.FieldName = "Hora de atendimento";
            f4.Type = "Time";
            f4.Min = 0800;
            f4.Max = 1800;
            f4.PrimaryKey = false;
            f4.Required = true;
            f4.Controlled = true;
            f4.SelectFromList = false;

            f5.FieldName = "Sintoma Aparente";
            f5.Type = "String";
            f5.Min = 0;
            f5.Max = 0;
            f5.PrimaryKey = false;
            f5.Required = false;
            f5.Controlled = true;
            f5.SelectFromList = true;

            var it1 = new Item();
            it1.ItemCode = "1";
            it1.Name = "alergia";
            var it2 = new Item();
            it2.ItemCode = "2";
            it2.Name = "febre";
            var it3 = new Item();
            it3.ItemCode = "3";
            it3.Name = "tosse";

            f5.ListItems.Add(it1);
            f5.ListItems.Add(it2);
            f5.ListItems.Add(it3);

            test.Fields.Add(f1);
            test.Fields.Add(f2);
            test.Fields.Add(f3);
            test.Fields.Add(f4);
            test.Fields.Add(f5);

            var test2 = new Form
            {
                DataSetName = "Viagem para Orlando",
                DataSetDescription = "Formulario de Passageiro",
                Coordinator = "cordenador",
                Status = "active"
            };
            
            var g1 = new Field();
            var g2 = new Field();
            var g3 = new Field();
            var g4 = new Field();
            var g5 = new Field();
            var g6 = new Field();
            var g7 = new Field();


            g1.FieldName = "Nome do Passageiro";
            g1.Type = "String";
            g1.Min = 0;
            g1.Max = 50;
            g1.PrimaryKey = true;
            g1.Required = false;
            g1.Controlled = true;
            g1.SelectFromList = false;

            g2.FieldName = "Idade";
            g2.Type = "Number";
            g2.Min = 0;
            g2.Max = 20;
            g2.PrimaryKey = false;
            g2.Required = false;
            g2.Controlled = false;
            g2.SelectFromList = false;

            g3.FieldName = "Nome do Responsavel";
            g3.Type = "String";
            g3.Min = 0;
            g3.Max = 50;
            g3.PrimaryKey = true;
            g3.Required = false;
            g3.Controlled = true;
            g3.SelectFromList = false;

            g4.FieldName = "Telefone";
            g4.Type = "Number";
            g4.Min = 0;
            g4.Max = 20;
            g4.PrimaryKey = false;
            g4.Required = false;
            g4.Controlled = false;
            g4.SelectFromList = false;

            g5.FieldName = "Data da Viagem";
            g5.Type = "Date";
            g5.Min = 12112015;
            g5.Max = 30112030;
            g5.PrimaryKey = false;
            g5.Required = true;
            g5.Controlled = true;
            g5.SelectFromList = false;

            g6.FieldName = "Vacina que Tomou";
            g6.Type = "String";
            g6.Min = 0;
            g6.Max = 0;
            g6.PrimaryKey = false;
            g6.Required = false;
            g6.Controlled = true;
            g6.SelectFromList = true;

            var jt1 = new Item();
            jt1.ItemCode = "1";
            jt1.Name = "Triplice";
            var jt2 = new Item();
            jt2.ItemCode = "2";
            jt2.Name = "Variola";
            var jt3 = new Item();
            jt3.ItemCode = "3";
            jt3.Name = "Sarampo";
            var jt4 = new Item();
            jt4.ItemCode = "1";
            jt4.Name = "Anti-Tetanica";
            var jt5 = new Item();
            jt5.ItemCode = "2";
            jt5.Name = "Caxumba";

            g6.ListItems.Add(jt1);
            g6.ListItems.Add(jt2);
            g6.ListItems.Add(jt3);
            g6.ListItems.Add(jt4);
            g6.ListItems.Add(jt5);

            g7.FieldName = "Doenças Contraidas";
            g7.Type = "String";
            g7.Min = 0;
            g7.Max = 0;
            g7.PrimaryKey = false;
            g7.Required = false;
            g7.Controlled = true;
            g7.SelectFromList = true;

            var kt1 = new Item();
            kt1.ItemCode = "1";
            kt1.Name = "Catapora";
            var kt2 = new Item();
            kt2.ItemCode = "2";
            kt2.Name = "Sarampo";
            var kt3 = new Item();
            kt3.ItemCode = "3";
            kt3.Name = "Rubeola";
            var kt4 = new Item();
            kt4.ItemCode = "1";
            kt4.Name = "Caxumba";
            var kt5 = new Item();
            kt5.ItemCode = "2";
            kt5.Name = "Coqueluche";

            g7.ListItems.Add(kt1);
            g7.ListItems.Add(kt2);
            g7.ListItems.Add(kt3);
            g7.ListItems.Add(kt4);
            g7.ListItems.Add(kt5);
            
            test2.Fields.Add(g1);
            test2.Fields.Add(g2);
            test2.Fields.Add(g3);
            test2.Fields.Add(g4);
            test2.Fields.Add(g5);
            test2.Fields.Add(g6);
            test2.Fields.Add(g7);

            form.Add(test);
            form.Add(test2);

            formDirectory.Form = form;

            return formDirectory;
        }
    }
}
