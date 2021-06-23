using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TblAdn
    {
        public int TblAdnId { get; set; }
        public string Adn { get; set; }
        public bool IsMutant { get; set; } 
        public string AdnType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool State { get; set; }

    }
}
