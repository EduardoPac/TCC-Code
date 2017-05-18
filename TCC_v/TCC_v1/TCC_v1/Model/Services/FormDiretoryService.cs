using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.Model.Entities;

namespace TCC_v1.Model.Services
{
    class FormDiretoryService
    {
        //public static FormDiretory LoadFormsDirectoryRest();

        public static FormDiretory LoadFormsDirectorySqlite()
        {

            // conectar com o sqlite

            //DatabaseManager dbManager = new DatabaseManager();
            //ObservableCollection<Form> form = new ObservableCollection<Form>(dbManager.GetAllItems<Form>());
            //FormDiretory formDiretory = new FormDiretory();

            //if (form.Any())
            //{
            //    formDiretory.Form = form;
            //    return formDiretory;
            //}

            //////Apenas teste//////////
            
            ObservableCollection<Form> form = new ObservableCollection<Form>();

            FormDiretory formDirectory = new FormDiretory();

            Form teste = new Form();

            teste.DatasetName = "Vacina H1N1";
            teste.DataSetDescription = "Formulario de vacinação da downça H1N1";
            teste.Coordinator = "cordenador";
            teste.Status = "active";

            Field f1 = new Field();
            Field f2 = new Field();
            Field f3 = new Field();
            Field f4 = new Field();
            Field f5 = new Field();

            f1.FieldName = "Nome do Paciente";
            f1.Description = "Insere o nome do paciente com Nome e Sobrenome";
            f1.Type = "String";
            f1.Order = 1;
            f1.Min = 0;
            f1.Max = 50;
            f1.PrimaryKey = true;
            f1.Required = false;
            f1.Controled = true;
            f1.SelectFromList = false;

            f2.FieldName = "Idade do Paciente";
            f2.Description = "Insere a idade do paciente";
            f2.Type = "Number";
            f2.Order = 2;
            f2.Min = 0;
            f2.Max = 20;
            f2.PrimaryKey = false;
            f2.Required = false;
            f2.Controled = false;
            f2.SelectFromList = false;

            f3.FieldName = "Data de Nascimento";
            f3.Description = "Insere a data de nascimento do paciente";
            f3.Type = "Date";
            f3.Order = 3;
            f3.Min = 12112015;
            f3.Max = 30112030;
            f3.PrimaryKey = false;
            f3.Required = true;
            f3.Controled = true;
            f3.SelectFromList = false;

            f4.FieldName = "Hora de atendimento";
            f4.Description = "Insere o horario que o paciente foi diagnosticado";
            f4.Type = "Time";
            f4.Order = 4;
            f4.Min = 0800;
            f4.Max = 1800;
            f4.PrimaryKey = false;
            f4.Required = true;
            f4.Controled = true;
            f4.SelectFromList = false;

            f5.FieldName = "Sintoma Aparente";
            f5.Description = "Seleciona o sintoma aparente do paciente";
            f5.Type = "String";
            f5.Order = 5;
            f5.Min = 0;
            f5.Max = 0;
            f5.PrimaryKey = false;
            f5.Required = false;
            f5.Controled = true;
            f5.SelectFromList = true;

            Item it1 = new Item();
            it1.CodigoItem = "1";
            it1.Name = "alergia";
            Item it2 = new Item();
            it2.CodigoItem = "2";
            it2.Name = "febre";
            Item it3 = new Item();
            it3.CodigoItem = "3";
            it3.Name = "tosse";

            f5.ListItens.Add(it1);
            f5.ListItens.Add(it2);
            f5.ListItens.Add(it2);

            teste.Fields.Add(f1);
            teste.Fields.Add(f2);
            teste.Fields.Add(f3);
            teste.Fields.Add(f4);
            teste.Fields.Add(f5);

            Form teste2 = new Form();

            teste2.DatasetName = "Viagem para Orlando";
            teste2.DataSetDescription = "Formulario de Passageiro";
            teste2.Coordinator = "cordenador";
            teste2.Status = "active";

            Field g1 = new Field();
            Field g2 = new Field();
            Field g3 = new Field();
            Field g4 = new Field();
            Field g5 = new Field();
            Field g6 = new Field();
            Field g7 = new Field();


            g1.FieldName = "Nome do Passageiro";
            g1.Description = "Insere o nome do passageiro com Nome e Sobrenome";
            g1.Type = "String";
            g1.Order = 1;
            g1.Min = 0;
            g1.Max = 50;
            g1.PrimaryKey = true;
            g1.Required = false;
            g1.Controled = true;
            g1.SelectFromList = false;

            g2.FieldName = "Idade";
            g2.Description = "Insere a idade do passageiro";
            g2.Type = "Number";
            g2.Order = 2;
            g2.Min = 0;
            g2.Max = 20;
            g2.PrimaryKey = false;
            g2.Required = false;
            g2.Controled = false;
            g2.SelectFromList = false;

            g3.FieldName = "Nome do Responsavel";
            g3.Description = "Insere o nome do Responsavel com Nome e Sobrenome";
            g3.Type = "String";
            g3.Order = 1;
            g3.Min = 0;
            g3.Max = 50;
            g3.PrimaryKey = true;
            g3.Required = false;
            g3.Controled = true;
            g3.SelectFromList = false;

            g4.FieldName = "Telefone";
            g4.Description = "Insere o telefone para contato";
            g4.Type = "Number";
            g4.Order = 2;
            g4.Min = 0;
            g4.Max = 20;
            g4.PrimaryKey = false;
            g4.Required = false;
            g4.Controled = false;
            g4.SelectFromList = false;

            g5.FieldName = "Data da Viagem";
            g5.Description = "Insere a data de nascimento do paciente";
            g5.Type = "Date";
            g5.Order = 3;
            g5.Min = 12112015;
            g5.Max = 30112030;
            g5.PrimaryKey = false;
            g5.Required = true;
            g5.Controled = true;
            g5.SelectFromList = false;

            g6.FieldName = "Vacina que Tomou";
            g6.Description = " vacina do paciente";
            g6.Type = "String";
            g6.Order = 5;
            g6.Min = 0;
            g6.Max = 0;
            g6.PrimaryKey = false;
            g6.Required = false;
            g6.Controled = true;
            g6.SelectFromList = true;

            Item jt1 = new Item();
            jt1.CodigoItem = "1";
            jt1.Name = "Triplice";
            Item jt2 = new Item();
            jt2.CodigoItem = "2";
            jt2.Name = "Variola";
            Item jt3 = new Item();
            jt3.CodigoItem = "3";
            jt3.Name = "Sarampo";
            Item jt4 = new Item();
            jt4.CodigoItem = "1";
            jt4.Name = "Anti-Tetanica";
            Item jt5 = new Item();
            jt5.CodigoItem = "2";
            jt5.Name = "Caxumba";

            g6.ListItens.Add(jt1);
            g6.ListItens.Add(jt2);
            g6.ListItens.Add(jt3);
            g6.ListItens.Add(jt4);
            g6.ListItens.Add(jt5);

            g7.FieldName = "Doenças Contraidas";
            g7.Description = " vacina do paciente";
            g7.Type = "String";
            g7.Order = 5;
            g7.Min = 0;
            g7.Max = 0;
            g7.PrimaryKey = false;
            g7.Required = false;
            g7.Controled = true;
            g7.SelectFromList = true;

            Item kt1 = new Item();
            kt1.CodigoItem = "1";
            kt1.Name = "Catapora";
            Item kt2 = new Item();
            kt2.CodigoItem = "2";
            kt2.Name = "Sarampo";
            Item kt3 = new Item();
            kt3.CodigoItem = "3";
            kt3.Name = "Rubeola";
            Item kt4 = new Item();
            kt4.CodigoItem = "1";
            kt4.Name = "Caxumba";
            Item kt5 = new Item();
            kt5.CodigoItem = "2";
            kt5.Name = "Coqueluche";

            g7.ListItens.Add(kt1);
            g7.ListItens.Add(kt2);
            g7.ListItens.Add(kt3);
            g7.ListItens.Add(kt4);
            g7.ListItens.Add(kt5);
            
            teste2.Fields.Add(g1);
            teste2.Fields.Add(g2);
            teste2.Fields.Add(g3);
            teste2.Fields.Add(g4);
            teste2.Fields.Add(g5);
            teste2.Fields.Add(g6);
            teste2.Fields.Add(g7);

            form.Add(teste);
            form.Add(teste2);

            formDirectory.Form = form;

            return formDirectory;
        }

        
    }
}
