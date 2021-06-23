using System;
using DevExpress.Xpo;

namespace Model.DTOs
{

    public class TblAdnDto
    {
        public int TblAdnId { get; set; }
        public string Adn { get; set; }
        public bool IsMutant { get; set; }
        public string AdnType { get; set; }
    }

}