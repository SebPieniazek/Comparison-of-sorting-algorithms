using System;
using System.Text;
using System.IO;

namespace AlgorithmComparisonEngine
{
    class DataStorageFiller
    {
        protected int[] dataStorage;

        public DataStorageFiller()
        {
            TakeDigitsFromUser();
        }

        void TakeDigitsFromUser()
        {
            Interact.WriteText(ConsoleColor.Magenta, " Which method do you want to choose for delivering numbers? \n  1. Draw \n  2. Write on console \n  3. Upload file");

            switch (Interact.TakeUserOutput(3))
            {
                case 1:
                    {
                        _ = new RandomValue();
                        break;
                    }
                case 2:
                    {
                        _ = new TypedDigits();
                        break;
                    }
                case 3:
                    {
                        _ = new ReadFile();
                        break;
                    }
            }
        }

        bool IsDigitsOnly(string str)
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

        void ChangeStringToInt(string strToChange)
        {
            bool end = false;
            bool addToBuilder = false;
            int dataStorageIndex = 0;
            int singleValue;
            StringBuilder completeDigit = new StringBuilder();
            int[] dataStorage = new int[DeclareDateStorageSize(strToChange)];

            for (int i = 0; i < strToChange.Length; i++)
            {
                if (!end)
                {
                    for (int j = i; j < strToChange.Length; j++)
                    {
                        if (strToChange[j] != ' ')
                        {
                            addToBuilder = true;
                            completeDigit.Append(strToChange[j]);
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

        int DeclareDateStorageSize(string str)
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


        class RandomValue : DataStorageFiller
        {
            public RandomValue()
            {
                Interact.WriteText(ConsoleColor.Magenta, " How much digits you want to draw ? (max. 10000)");
                dataStorage = new int[Interact.TakeUserOutput(10000)];

                Draw();

                DataStorage.SaveData(dataStorage);
            }

            void Draw()
            {
                Random rnd = new Random();
                for (int i = 0; i < dataStorage.Length - 1; i++)
                {
                    dataStorage[i] = rnd.Next(-10000, 10000);
                }
            }
        }

        class TypedDigits : DataStorageFiller
        {
            public TypedDigits()
            {
                ChangeStringToInt(AskUserForDigits());
            }

            string AskUserForDigits()
            {
                string userOutput;
                bool goodOutput;


                do
                {
                    Interact.WriteText(ConsoleColor.Magenta, " Insert your date here:");
                    Interact.WriteText(ConsoleColor.Magenta, " Maximum length of a single value is 10 digits."); // int = 32 bity = -2 147 483 648 to 2 147 483 647.
                    Interact.WriteText(ConsoleColor.Magenta, " A single value should be separated by ' ' space.");

                    goodOutput = IsDigitsOnly(userOutput = Console.ReadLine());
                    if (!goodOutput)
                    {
                        Interact.WriteText(ConsoleColor.Red, " Insert digits only !");
                    }
                } while (!goodOutput);

                return userOutput;
            }
        }

        class ReadFile : DataStorageFiller
        {
            public ReadFile()
            {
                AskUserForFile();
            }

            void AskUserForFile()
            {
                Interact.WriteText(ConsoleColor.Magenta, " How do you want to upload the data?\n   1. Insert file path \n  2. Insert file name(file should be in Project folder)");

                string filePath;
                string fileData = "";
                bool correctData;
                do
                {
                    if (Interact.TakeUserOutput(2) == 1)
                    {
                        filePath = TakeFilePathFromUser();
                    }
                    else
                    {
                        filePath = TakeFileNameFromUser();
                    }

                    correctData = IsDigitsOnly(fileData);

                    if (filePath != "false")
                    {
                        fileData = File.ReadAllText(filePath);

                        if (!correctData || fileData == "")
                        {
                            Interact.WriteText(ConsoleColor.Red, " File data contains letters or invalid special characters. Check file and try again");
                        }
                    }
                } while (!correctData || filePath == "false");

                ChangeStringToInt(fileData);
            }

            string TakeFilePathFromUser()
            {
                string filePath;

                Interact.WriteText(ConsoleColor.Red, @" Insert full path to txt file. It should looks like C:\User\Destop\file.txt");
                filePath = Console.ReadLine();

                filePath = CheckFilePath(filePath);

                return filePath;
            }

            string TakeFileNameFromUser()
            {
                string fileName;
                string filePath = Environment.CurrentDirectory;
                filePath = Directory.GetParent(filePath).Parent.Parent.FullName;

                do
                {
                    Interact.WriteText(ConsoleColor.Red, " Insert file name. It should be txt file !");
                    fileName = Console.ReadLine();

                    filePath += @$"\{fileName}";

                    filePath = CheckFilePath(filePath);

                } while (!File.Exists(filePath));

                return filePath;
            }

            string CheckFilePath(string file)
            {
                if (!file.EndsWith(@".txt"))
                {
                    file += @".txt";
                }

                if (!File.Exists(file))
                {
                    Interact.WriteText(ConsoleColor.Red, " File doesn't exists or you input invalid file path ! Try again.");
                    return "false";
                }

                return file;
            }


        }


    }
}
//TODO
// ogarnac zeby maksymalnie pojedyncza liczba mogla miec 10 cyfr.
// TryParse zamiast isDigitsOnly ? 
