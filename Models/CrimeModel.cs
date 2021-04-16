﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIS_Assignment4.Models
{
   

    //public class Key
    //{
    //    public string keyname { get; set; }
    //}
    

    public class Root
    {
        public string ui_type { get; set; }
        public string noun { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string short_title { get; set; }
        public object ui_restriction { get; set; }
        public string[] keys { get; set; }
        public Datum[] data { get; set; }
        public object[] precise_data { get; set; }
    }

    public class Datum
    {
        public int value { get; set; }
        public int data_year { get; set; }
        public int month_num { get; set; }
        public string key { get; set; }
    }


}
