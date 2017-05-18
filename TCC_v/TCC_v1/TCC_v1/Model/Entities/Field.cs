﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_v1.Model.Entities
{
    public class Field
    {
        public Field()
        {
            fieldName = "";
            description = "";
            type = "";
            order = 0;
            min = 0;
            max = 0;
            primaryKey = false;
            required = false;
            controled = false;
            listItens = new List<Item>();

        }


        private string fieldName;

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private int order ;

        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        private int min;

        public int Min
        {
            get { return min; }
            set { min = value; }
        }

        private int max;

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        private Boolean primaryKey;

        public Boolean PrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; }
        }

        private Boolean required;

        public Boolean Required
        {
            get { return required; }
            set { required = value; }
        }

        private Boolean controled;

        public Boolean Controled
        {
            get { return controled; }
            set { controled = value; }
        }

        private Boolean selectFromList;

        public Boolean SelectFromList
        {
            get { return selectFromList; }
            set { selectFromList = value; }
        }

        private List<Item> listItens;

        public List<Item> ListItens
        {
            get { return listItens; }
            set { listItens = value; }
        }



    }
}
