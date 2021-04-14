using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIS_Assignment4.Models
{
   


    public class Rootobject
    {
        public Result[] results { get; set; }
        public Pagination pagination { get; set; }
    }
    
    public class Pagination
    {
        public int count { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public int per_page { get; set; }
    }

    public class Result
    {
        public int aggravated_assault { get; set; }
        public int all_other_offenses { get; set; }
        public int arson { get; set; }
        public int burglary { get; set; }
        public int curfew { get; set; }
        public int disorderly { get; set; }
        public int driving { get; set; }
        public int drug_abuse_gt { get; set; }
        public int drug_poss_m { get; set; }
        public int drug_poss_opium { get; set; }
        public int drug_poss_other { get; set; }
        public int drug_poss_subtotal { get; set; }
        public int drug_poss_synthetic { get; set; }
        public int drug_sales_m { get; set; }
        public int drug_sales_opium { get; set; }
        public int drug_sales_other { get; set; }
        public int drug_sales_subtotal { get; set; }
        public int drug_sales_synthetic { get; set; }
        public int drunkness { get; set; }
        public int embezzlement { get; set; }
        public int forgery { get; set; }
        public int fraud { get; set; }
        public int g_all { get; set; }
        public int g_b { get; set; }
        public int g_n { get; set; }
        public int g_t { get; set; }
        public int ht_c_s_a { get; set; }
        public int ht_i_s { get; set; }
        public int larceny { get; set; }
        public int liquor { get; set; }
        public int manslaughter { get; set; }
        public int mvt { get; set; }
        public int murder { get; set; }
        public int offense_family { get; set; }
        public int prostitution { get; set; }
        public int prostitution_a_p_p { get; set; }
        public int prostitution_p { get; set; }
        public int prostitution_p_p { get; set; }
        public int rape { get; set; }
        public int robbery { get; set; }
        public int sex_offense { get; set; }
        public int simple_assault { get; set; }
        public int stolen_property { get; set; }
        public int suspicion { get; set; }
        public int vagrancy { get; set; }
        public int vandalism { get; set; }
        public int weapons { get; set; }
        public object csv_header { get; set; }
        public int data_year { get; set; }
    }

   

}
