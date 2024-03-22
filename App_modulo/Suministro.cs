using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_modulo
{
    public class Suministro
    {
        public Int64 ID{  get; set; }
        public string EQUIPO { get; set; }
        public string TRANSPORTE { get; set; }
        public string INSTALACION { get; set; }
        public string CONFIGURACION { get; set; }


        public Suministro() { }

        public Suministro (Int64 sID, string sEQUIPO, string sTRANSPORTE, string sINSTALACION, string sCONFIGURACION)
        {
            this.ID = sID;
            this.EQUIPO = sEQUIPO;
            this.TRANSPORTE = sTRANSPORTE;
            this.INSTALACION = sINSTALACION;
            this.CONFIGURACION = sCONFIGURACION;
        }
    }
    
}
