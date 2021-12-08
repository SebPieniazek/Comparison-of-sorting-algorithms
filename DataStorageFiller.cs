using System;
using System.Text;
using System.IO;

namespace AlgorithmComparisonEngine
{
    class DataStorageFiller
    {

        public DataStorageFiller()
        {
            takeDigitsFromUser();
        }

        public void takeDigitsFromUser()
        {
            Interact.WriteText(ConsoleColor.Magenta, " Which method do you want to choose for delivering numbers?");
            Interact.WriteText(ConsoleColor.Magenta, "  1. Draw");
            Interact.WriteText(ConsoleColor.Magenta, "  2. Write on console");
            Interact.WriteText(ConsoleColor.Magenta, "  3. Upload file");

            switch (Interact.TakeUserOutput(3))
            {
                case 1:
                    {
                        RandomValues();
                        break;
                    }
                case 2:
                    {
                        TakeTypedDigitsFromUser();
                        break;
                    }
                case 3:
                    {
                        ReadFile();
                        break;
                    }
            }
        }

        void RandomValues()
        {
            Interact.WriteText(ConsoleColor.Magenta, " How much digits you want to draw ? (max. 10000)");
            int[] dateStorage = new int[Interact.TakeUserOutput(10000)]; // max 10000 losowanie.

            Random rnd = new Random();
            for (int i = 0; i < dateStorage.Length - 1; i++)
            {
                dateStorage[i] = rnd.Next(-10000, 10000);
            }
            DataStorage.SaveData(dateStorage);
        }

        void TakeTypedDigitsFromUser()
        {
            string userOutput;
            bool goodOutput;
            do
            {
                Interact.WriteText(ConsoleColor.Magenta, " Insert your date here:");
                Interact.WriteText(ConsoleColor.Magenta, " Maximum length of a single value is 10 digits."); // bo max dlugosc inta - 32 bity = -2 147 483 648 do 2 147 483 647.
                Interact.WriteText(ConsoleColor.Magenta, " A single value should be separated by ' ' space.");

                userOutput = Console.ReadLine();
                goodOutput = isDigitsOnly(userOutput);
                if (!goodOutput)
                {
                    Interact.WriteText(ConsoleColor.Red, " Insert digits only !");
                }
            } while (!goodOutput);

            changeStringToInt(userOutput);
        }

        void ReadFile()
        {
            Interact.WriteText(ConsoleColor.Magenta, " How do you want to upload the data?");
            Interact.WriteText(ConsoleColor.Magenta, "  1. Insert file path \n  2. Insert file name(file should be in Project folder)");
            int userChoice = Interact.TakeUserOutput(2);

            string filePath;
            string fileData = "default";
            do
            {
                if (userChoice == 1)
                {
                    filePath = TakeFilePathFromUser();
                }
                else
                {
                    filePath = TakeFileFromUserAsFileName();
                }

                if (filePath != "false")
                {
                    fileData = File.ReadAllText(filePath);

                    if (!isDigitsOnly(fileData) || fileData == "")
                    {
                        Interact.WriteText(ConsoleColor.Red, " File data contains letters or invalid special characters. Check file and try again");
                    }
                }
            } while (!isDigitsOnly(fileData) || filePath == "false");

            changeStringToInt(fileData);
        }

        string TakeFilePathFromUser()
        {
            string filePath;

            Interact.WriteText(ConsoleColor.Red, @" Insert full path to txt file. It should looks like C:\User\Destop\file.txt");
            filePath = Console.ReadLine();
            if (!filePath.EndsWith(@".txt"))
            {
                filePath += @".txt";
            }

            if (!File.Exists(filePath))
            {
                Interact.WriteText(ConsoleColor.Red, " File doesn't exists or you input invalid file path ! Try again.");
                return "false";
            }

            return filePath;
        }

        string TakeFileFromUserAsFileName()
        {
            string fileName;

            // This will get the current WORKING directory (i.e. \bin\Debug)
            string filePath = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            filePath = Directory.GetParent(filePath).Parent.Parent.FullName;

            // This will get the current PROJECT bin directory (ie ../bin/)
            filePath = Directory.GetParent(filePath).Parent.FullName;
            // This will get the current PROJECT directory

            do
            {
                Interact.WriteText(ConsoleColor.Red, "Insert file name. It should be txt file !");
                fileName = Console.ReadLine();
                if (!fileName.EndsWith(@".txt"))
                {
                    fileName += @".txt";
                }

                filePath += filePath + @$"\{fileName}";

                if (!File.Exists(filePath))
                {
                    Interact.WriteText(ConsoleColor.Red, "File doesn't exists or you input invalid file name ! Try again.");
                    return "false";
                }
            } while (!File.Exists(filePath));

            return filePath;
        }


        bool isDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || '9' < c) && c != ' ' && c != '-')
                {
                    return false;
                }
            }
            return true;
        }

        void changeStringToInt(string toChange)
        {
            bool end = false;
            bool addToBuilder = false;
            int dataStorageIndex = 0;
            int singleValue;
            StringBuilder completeDigit = new StringBuilder();
            int[] dataStorage = new int[declareDateStorageSize(toChange)];

            for (int i = 0; i < toChange.Length; i++)
            {
                if (!end)
                {
                    for (int j = i; j < toChange.Length; j++)
                    {
                        if (toChange[j] != ' ')
                        {
                            addToBuilder = true;
                            completeDigit.Append(toChange[j]);
                        }
                        else
                        {
                            i = j;
                            break;
                        }
                    }
                }
                else
                    break;
                if (addToBuilder)
                {
                    int.TryParse(completeDigit.ToString(), out singleValue);
                    dataStorage[dataStorageIndex] = singleValue;
                    dataStorageIndex++;
                    completeDigit.Clear();
                    addToBuilder = false;
                    if (dataStorageIndex > dataStorage.Length - 1)
                    {
                        end = true;
                    }
                }
            }
            DataStorage.SaveData(dataStorage);
        }

        int declareDateStorageSize(string str)
        {
            int dataStorageSize = 1;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == ' ')
                {
                    if(str[i + 1] != ' ')
                        dataStorageSize++;
                }
            }

            if(str[0] == ' ')
            {
                dataStorageSize--;
            }

            return dataStorageSize;
        }
    }
}
//TODO
// ogarnac zeby maksymalnie pojedyncza liczba mogla miec 10 cyfr.
// rozdzielic wybor na nowe klasy
// dodac nowa zmienna bool do sprawdzania zamiast 2 razy is digits only
