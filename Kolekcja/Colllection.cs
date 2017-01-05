using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolekcja
{
    class Colllection
    {
        private int[] temps;

        public Colllection(int size)
        {
            temps = new int[size];
        }

        public int this[int index]
        {
            get
            {
                return temps[index];
            }
            set
            {
                temps[index] = value;
                Array.Sort(temps);   
            }
        }

        public int this[char index]
        {
            get
            {
                return temps[ConvertAlphabetToPosition(index)];
            }
            set
            {
                temps[ConvertAlphabetToPosition(index)] = value;
                Array.Sort(temps);
            }
        }

        public int ConvertAlphabetToPosition(char letter)
        {
            letter = Char.ToUpper(letter);

            int index = ((int)(letter)) - 65;
            return index;
        }

        public int getCollectionSize()
        {
            return temps.Length;
        } 

        public void setCollectionSize(int size)
        {
            Array.Resize(ref temps, size);
        }
        
    }
}
