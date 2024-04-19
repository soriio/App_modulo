using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_modulo
{
    public class Suministro2
    {
        public Int64 ID { get; set; }
        public string EQUIPO { get; set; }
        public string TRANSPORTE { get; set; }
        public string INSTALACION { get; set; }
        public string CONFIGURACION { get; set; }
        public string MANTENIMIENTO { get; set; }


        public Suministro2() { }

        public Suministro2(Int64 sID, string sEQUIPO, string sTRANSPORTE, string sINSTALACION, string sCONFIGURACION, string sMANTENIMIENTO)
        {
            this.ID = sID;
            this.EQUIPO = sEQUIPO;
            this.TRANSPORTE = sTRANSPORTE;
            this.INSTALACION = sINSTALACION;
            this.CONFIGURACION = sCONFIGURACION;
            this.MANTENIMIENTO = sMANTENIMIENTO;
        }
    }





    
}
