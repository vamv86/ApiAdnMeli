using System;
using DevExpress.Xpo;

namespace Model.DTOs
{

    public class TblTipoAdnDto
    {
        public int TblTipoAdnId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; } 
    }

}