using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_v1.DAL;
using TCC_v1.Model.Entities;

namespace TCC_v1.ViewModel
{
    public class Form_Dinamic_view_model
    {
        public void SaveDAL(List<FieldAnswerBD> resp, Form form)
        {
            ConvertClass cv = new ConvertClass();

            FormAnswerBD fabd = cv.ConvFormtoBD(form);

            string datanow = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            string horanow = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();


            fabd.datacoleta = "Coleta: " + datanow + " - " + horanow;

            DALAswer data = new DALAswer();
            data.InsertFormA(fabd);

            for (int g = 0; g < resp.Count; g++)
            {
                resp[g].IDFormAnswer1 = fabd.IDFormAnswer;
            }

            for (int h = 0; h < resp.Count; h++)
            {
                data.InsertFieldA(resp[h]);
            }
        }
    }
}
