using System;
using DevExpress.Xpo;

namespace Model.DTOs.Response
{

    public class DnaResponse  
    {
        public int count_mutant_dna { get; set; }
        public int count_human_dna { get; set; }
        public double ratio { get; set; }

    }

}