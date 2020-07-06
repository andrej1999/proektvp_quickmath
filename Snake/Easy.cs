using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Easy
    {
        public Dictionary<string, string> dictEasy;
        public Easy()
        {
            dictEasy = new Dictionary<string, string>();
        }
        public Dictionary<String, String> Napolni_dict()
        {
            Random random = new Random();// procentualno broj na primeroci sobiranje i odzemenje pocnuvaat so 40% + random
            int i = random.Next(0, 5); // mnozenje i delenje pocnuvaat so 10% + random, na kraj site zaedno imaat 100%
            napolniSoSobiranjeiOdzemanje(4 + i);

            i = random.Next(0, 5 - i);
            napolniSoMnozenje(1 + i);

            i = random.Next(0, 5 - i);
            napolniSoDelenje(1 + i);
            return dictEasy;
        }

        private void napolniSoSobiranjeiOdzemanje(int v) // random suma od 0 do 1000 i random operacii
        {
            Random random = new Random();
            char[] op = { '+', '-'};
            int x, y, index;
            int i = 0;
            double procent = (double)v/10;
            procent = procent * 200;
            while (i < procent)
            {
                int suma = 0;
                x = random.Next(0, 1000);
                y = random.Next(0, 1000);
                index = random.Next(0, 2);
                String text = x.ToString() + " " + op[index].ToString() + " " + y.ToString();
                if (op[index].Equals('+'))
                    suma = x + y;
                if (op[index].Equals('-'))
                    suma = x - y;
                dictEasy[text] = suma.ToString();
                i++;
            }
        }
        private void napolniSoMnozenje(int v)
        {
            Random random = new Random();
            char op = '*';
            int x, y;
            int i = 0;
            int number = 1;
            double procent = (double)v / 10;
            procent = procent * 200;
            while (i < procent)
            {
                int suma = 0;
                x = random.Next(0, 100);
                y = random.Next(number, 10);
                suma = x * y;
                String text = x.ToString() + " " + op.ToString() + " " + y.ToString();
                i++;
                dictEasy[text] = suma.ToString();
            }
        }
        private void napolniSoDelenje(int v)
        {
            Random random = new Random();
            char op = '/';
            int x, y;
            int i = 0;
            int number = 1;
            double procent = (double)v / 10;
            procent = procent * 200;
            while (i < procent)
            {
                int suma = 0;
                x = random.Next(0, 1000);
                y = random.Next(number, 10);
                if (x % y == 0)
                {
                    suma = x / y;
                    String text = x.ToString() + " " + op.ToString() + " " + y.ToString();
                    i++;
                    if (i > 15)
                        number = 3;
                    if (i > 30)
                        number = 6;
                    dictEasy[text] = suma.ToString();
                }
            }
        }

    }
}
