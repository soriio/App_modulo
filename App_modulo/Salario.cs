using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_modulo
{
    public class Salario
    {
        public Int64 ID {  get; set; }
        public string OCUPACION { get; set; }
        public string VALORDIA { get; set; }


        public Salario() { }

        public Salario (Int64 vID, string vOCUPACION, string vVALORDIA)
        {
            this.ID = vID;
            this.OCUPACION = vOCUPACION;
            this.VALORDIA = vVALORDIA;
        }
    }
}
