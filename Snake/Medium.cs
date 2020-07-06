using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Medium
    {
        public Easy easyBase;
        public Medium()
        {
            easyBase = new Easy();
        }
        public Dictionary<String, String> Napolni_dict()
        {
            easyBase.Napolni_dict();
            napolnoSoStepeni();
            return easyBase.dictEasy;
        }
        private void napolnoSoStepeni()
        {
            Random random = new Random();
            int x, y;
            int i = 0;
            while (i < 60)
            {
                x = random.Next(0, 101);
                y = random.Next(0, 5);
                String text = x.ToString() + "^" + y.ToString();
                double suma = Math.Pow(x, y);
                int suma1 = (int)suma;
                easyBase.dictEasy[text] = suma1.ToString();
                i++;
            }
        }
    }
}
