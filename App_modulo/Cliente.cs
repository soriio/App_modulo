using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_modulo
{
    public class Cliente
    {
        public Int64 ID{ get; set; }
        public string CONTACTO { get; set; }
        public string CLIENTE { get; set; }
        public string TELEFONO { get; set; }
        public string CELULAR { get; set; }
        public string CORREO { get; set; }
        public string CARGO { get; set; }
        public string DIRECCION { get; set; }
        public string NIT { get; set; }
        public string CUIDAD { get; set; }
        public string VENDEDOR { get; set; }


        public Cliente() { }

        public Cliente (Int64 pID , string pCONTACTO, string pCLIENTE, string pTELEFONO, string pCELULAR, string pCORREO, string pCARGO, string pDIRECCION, string pNIT, string pCUIDAD, string pVENDEDOR)
        {
            this.ID = pID;
            this.CONTACTO = pCONTACTO;
            this.CLIENTE = pCLIENTE;
            this.TELEFONO = pTELEFONO;
            this.CELULAR = pCELULAR;
            this.CORREO = pCORREO;
            this.CARGO = pCARGO;
            this.DIRECCION = pDIRECCION;
            this.NIT = pNIT;
            this.CUIDAD = pCUIDAD;
            this.VENDEDOR = pVENDEDOR;
        }
    }
}
