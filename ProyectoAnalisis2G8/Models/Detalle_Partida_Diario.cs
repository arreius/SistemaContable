//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoAnalisis2G8.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detalle_Partida_Diario
    {
        public int id_cuenta { get; set; }
        public int id_partida { get; set; }
        public Nullable<double> debe { get; set; }
        public Nullable<double> haber { get; set; }
    
        public virtual Nomenclatura Nomenclatura { get; set; }
        public virtual Partida_Diario Partida_Diario { get; set; }
    }
}