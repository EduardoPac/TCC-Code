using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;
using TCC_v1.Model.Entities;

namespace TCC_v1.ViewModel
{
    public class ConvertClass
    {

        public Form ConvBDtoForm(FormBD fbd)
        {
            DALA data = new DALA();

            List<FieldBD> fibd = data.getFieldList(fbd.IDForm);

            Form ret = new Form();

            ret.Coordinator = fbd.Coordinator;
            ret.DataSetDescription = fbd.DataSetDescription;
            ret.DatasetName = fbd.DatasetName;
            ret.Status = fbd.Status;

            for(int x = 0; x < fibd.Count; x++)
            {
                Field aux = new Field();

                aux.Controled = fibd[x].Controled;
                aux.Description = fibd[x].Description;
                aux.FieldName = fibd[x].FieldName;
                aux.Max = fibd[x].Max;
                aux.Min = fibd[x].Min;
                aux.Order = fibd[x].Order;
                aux.PrimaryKey = fibd[x].PrimaryKey;
                aux.Required = fibd[x].Required;
                aux.SelectFromList = fibd[x].SelectFromList;
                aux.Type = fibd[x].Type;

                ret.Fields.Add(aux);
            }

            

            for(int y = 0; y < fibd.Count; y++)
            {
                if(ret.Fields[y].SelectFromList == true)
                {
                    List<ItemBD> aux2 = new List<ItemBD>();
                    aux2 = data.getItemList(fibd[y].IDField);

                    for(int k = 0; k < aux2.Count; k++)
                    {
                        ret.Fields[y].ListItens.Add(aux2[k]);
                    }

                }


            }

            return ret;


        }

        public FormAnswerBD ConvFormtoBD(Form frm)//implementar quando salvar
        {
            FormAnswerBD fabd = new FormAnswerBD();
            fabd.Coordinator = frm.Coordinator;
            fabd.DataSetDescription = frm.DataSetDescription;
            fabd.DatasetName = frm.DatasetName;
            fabd.Status = frm.Status;
            
            return fabd;


        }


    }
}
