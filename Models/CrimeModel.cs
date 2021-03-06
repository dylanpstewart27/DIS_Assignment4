using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DIS_Assignment4.Models
{


   
    public class Key
    {
        
        [Key]public string key { get; set; }
        public List<Datum> Data { get; set; }
    }

    public class Year
    {
        [Key]public int data_year { get; set; }
        public List<Datum> Data { get; set; }
    }

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
        public int ID { get; set; }
        public int value { get; set; }
        public int data_year { get; set; }
        public int month_num { get; set; }
        public string key { get; set; }
    }

    public class Chart
    {
        public string data_year { get; set; }
        public string value { get; set; }
    }
    

        
}
