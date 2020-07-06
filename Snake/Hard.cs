using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Hard
    {
        public Medium mediumBase;
        public Hard()
        {
            mediumBase = new Medium();
        }
        public Dictionary<String, String> Napolni_dict()
        {
            mediumBase.Napolni_dict();
            napolniSoFactor();
            napolniSoDropki();
            napolnoSobiranjeiOdzemanjeDropki();
            return mediumBase.easyBase.dictEasy;
        }

        private void napolnoSobiranjeiOdzemanjeDropki()
        {
            Random random = new Random();
            int x, y, z;
            int i = 0;
            while (i < 30)
            {
                x = random.Next(0, 10);
                y = random.Next(0, 100);
                z = random.Next(0, 100);
                String text = z.ToString() + " + " + x.ToString() + " / " + y.ToString();
                int suma = 0;
                int suma1 = 0;
                suma = y * z;
                suma = (x * 2) + suma;
                suma1 = y * z;
                String upper = suma.ToString() + "/" + suma1.ToString();
                mediumBase.easyBase.dictEasy[text] = upper;
                i++;
            }
        }

        private void napolniSoDropki()
        {
            Random random = new Random();
            int x, y, z, w;
            int i = 0;
            while (i < 30)
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
                z = random.Next(0, 10);
                w = random.Next(0, 10);
                String text = x.ToString() + "/" + y.ToString() + " | " + z.ToString() + "/" + w.ToString();
                int suma = 0;
                int suma1 = 0;
                suma = x * w;
                suma1 = y * z;
                String upper = suma.ToString() + "/" + suma1.ToString();
                mediumBase.easyBase.dictEasy[text] = upper;
                i++;
            }
        }

        private void napolniSoFactor()
        {
            Random random = new Random();
            int x, y;
            int i = 0;
            while (i < 30)
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
                String text = x.ToString() + " * " + y.ToString() + "!";
                int factor = 1;
                for(int j = 1; j <= y; j++)
                {
                    factor = factor * j;
                }
                int suma = x * factor;
                mediumBase.easyBase.dictEasy[text] = suma.ToString();
                i++;
            }
        }
    }
}
