using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolekcja
{
    class Program
    {
        private static Colllection collection;
        static void Main(string[] args)
        {
            collection = new Colllection(0);

            int option = 1;

            while (option != 0)
            {
                showMenu();
                option = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                chooseOperation(option);

            }
        }

        public static void showMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Pokaż kolekcje");
            Console.WriteLine("2. Wstaw do kolekcji na podstawie indeksu całkowitego.");
            Console.WriteLine("3. Wstaw do kolekcji na podstawie indeksu znakowego");
            Console.WriteLine("4. Wyświetl element na podstawie ind. całkowitego");
            Console.WriteLine("5. Wyświetl element na podstawie ind. znakowego.");
            Console.WriteLine("6. Dodaj element do kolekcji.");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybierz operacje: ");
        }

        public static void chooseOperation(int option)
        {
            switch (option)
            {
                case 1:
                    showCollection();
                    break;
                case 2:
                    putToCollectionByIntIndex();
                    break;
                case 3:
                    putToCollectionByCharIndex();
                    break;
                case 4:
                    showElementByIntIndex();
                    break;
                case 5:
                    showElementByCharIndex();
                    break;
                case 6:
                    addElementToCollection();
                    break;
                default:
                    Console.WriteLine("Nie ma takiej opcji.");
                    break; 

            }
        }

        

        private static void putToCollectionByIntIndex()
        {
            Console.Write("Podaj indeks całkowity, żeby wstawić do kolekcji: ");
            int index = Int32.Parse(Console.ReadLine());

            Console.Write("Podaj wartość danego indeksu: ");
            int valueOfInd = Int32.Parse(Console.ReadLine());


            if (isCorrectIntIndex(index))
            {
                collection[index] = valueOfInd;
            }
            else
            {
                ShowWarningMessageBeyondTheScope();


                PutToEndOfCollection(valueOfInd);

            }
        }

        private static void putToCollectionByCharIndex()
        {
            Console.Write("Podaj indeks znakowy, żeby wstawić do kolekcji: ");
            char index = Convert.ToChar(Console.ReadLine());

            Console.Write("Podaj wartość danego indeksu: ");
            int valueOfInd = Int32.Parse(Console.ReadLine());


            if (isCorrectCharIndex(index))
            {
                collection[index] = valueOfInd;
            }
            else
            {
                ShowWarningMessageBeyondTheScope();

                PutToEndOfCollection(valueOfInd);
            }
        }

        private static void ShowWarningMessageBeyondTheScope()
        {
            Console.WriteLine("Indeks wykracza poza zakres, element zostanie dodany na koniec.");
            Console.WriteLine("A następnie posorotowany.");
        }

        private static void PutToEndOfCollection(int val)
        {
            int indexInt = collection.getCollectionSize();
            collection.setCollectionSize(indexInt + 1);
            collection[indexInt] = val;
        }

        private static void showElementByIntIndex()
        {
            Console.Write("Podaj indeks całkowity, aby wyświetlić daną wartość: ");
            int index = Int32.Parse(Console.ReadLine());
            if (isCorrectIntIndex(index))
            {
                Console.WriteLine("Wartość indeksu " + index + " wynosi: " + collection[index]);
            }
            else
            {
                Console.WriteLine("Indeks wykracza poza zakres");
            }
        }

        private static void showElementByCharIndex()
        {
            Console.Write("Podaj indeks znakowy, aby wyświetlić daną wartość: ");
            char index = Convert.ToChar(Console.ReadLine());

            if (isCorrectCharIndex(index))
            {
                Console.WriteLine("Wartość indeksu " + index + " wynosi: " + collection[index]);
            }
            else
            {
                Console.WriteLine("Indeks wykracza poza zakres");
            }
        }

        private static void addElementToCollection()
        {
            Console.Write("Podaj wartość nowego elementu: ");
            int value = Int32.Parse(Console.ReadLine());
            int index = collection.getCollectionSize();
            collection.setCollectionSize(index + 1);
            collection[index] = value;
        }

        private static bool isCorrectCharIndex(char index)
        {
            bool isCorrect = true;
            int indexInt = collection.ConvertAlphabetToPosition(index);
            if (indexInt >= collection.getCollectionSize())
            {
                isCorrect = false;       
            }

            return isCorrect;
        } 
        
        private static bool isCorrectIntIndex(int index)
        {
            bool isCorrect = true;
            if (index >= collection.getCollectionSize())
            {
                isCorrect = false;
            }

            return isCorrect;
        } 
        
        private static void showCollection()
        {
            if (collection.getCollectionSize() > 0)
            {
                Console.WriteLine("Kolekcja: ");
                for (int i = 0; i < collection.getCollectionSize(); i++)
                {
                    Console.WriteLine(i + ". " + collection[i]);
                }
            }
            else
            {
                Console.WriteLine("Kolekcja jest pusta.");
            }
            
        }    
     
        
    }
}
