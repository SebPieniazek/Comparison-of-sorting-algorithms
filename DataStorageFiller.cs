using System;
using System.Text;
using System.IO;

namespace AlgorithmComparisonEngine
{
    class DataStorageFiller
    {
        protected int[] dataStorage;
        protected readonly Func<int, bool> checkMinOutput = userOutput => userOutput > 1;

        public DataStorageFiller(bool parentInstantion = false)
        {
            if (parentInstantion)
            {
                TakeDigitsFromUser();
            }
        }

        void TakeDigitsFromUser()
        {
            Interact.WriteText(ConsoleColor.Magenta, " Which method do you want to choose for delivering numbers? \n  1. Draw \n  2. Write on console \n  3. Upload file");

            switch (Interact.TakeUserOutput(3))
            {
                case 1:
                    {
                        _ = new DrawValues();
                        break;
                    }
                case 2:
                    {
                        _ = new TypedValues();
                        break;
                    }
                case 3:
                    {
                        _ = new ReadValuesFromFile();
                        break;
                    }
            }
        }

        bool IsDigitsOnly(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if ((str[i] < '0' || '9' < str[i]) && str[i] != ' ' && str[i] != '-')
                {
                    return false;
                }

                if (str[i] == '-' && (str[i + 1] < '0' || '9' < str[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }
        // It's adds values to dataStorage array. String builder is used to manipulate string and for faster data convert.
        // This can be done with String.Split(), but I wanted to do it myself and used Stringbuilder - String.Split() is commented bellow StringBuilder code.
        void ChangeStringToInt(string strToChange)
        {
            bool end = false;
            bool addToBuilder = false;

            int dataStorageIndex = 0;
            int singleValue;

            StringBuilder completeValue = new StringBuilder();
            dataStorage = new int[DeclareDateStorageSize(strToChange)];

            if (checkMinOutput(dataStorage.Length))
            {
                for (int i = 0; i < strToChange.Length; i++)
                {
                    if (!end)
                    {
                        for (int j = i; j < strToChange.Length; j++)
                        {
                            if (strToChange[j] != ' ')
                            {
                                addToBuilder = true;
                                completeValue.Append(strToChange[j]);
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
                        singleValue = int.Parse(completeValue.ToString());
                        dataStorage[dataStorageIndex] = singleValue;
                        dataStorageIndex++;

                        completeValue.Clear();
                        addToBuilder = false;

                        if (dataStorageIndex > dataStorage.Length - 1)
                        {
                            end = true;
                        }
                    }
                }

                DataStorage.SaveData(dataStorage);
            }
            else
            {
                Interact.WriteText(ConsoleColor.DarkRed, "Not enought values !");
                DataStorage.dataStorageFilled = false;
            }
            //Same code done with String.Split() - It's a little faster.
            /*
            if (checkMinOutput(dataStorage.Length))
            {
                dataStorage = new int[DeclareDateStorageSize(strToChange)];
                string[] storage = strToChange.Split(' ');
                for (int i = 0; i < storage.Length; i++)
                {
                    if (!String.IsNullOrEmpty(storage[i]))
                    {
                        dataStorage[i] = int.Parse(storage[i]);
                    }
                }

                DataStorage.SaveData(dataStorage);
            }
            else 
            {
                Interact.WriteText(ConsoleColor.DarkRed, "Not enought values !");
                DataStorage.dataStorageFilled = false;
            }
            */
        }

        // Declare the size of the data storage by counting spaces in string.
        // This is done for better optimization, it also protects aganist 0's in the array and from out of range exceptions.
        int DeclareDateStorageSize(string str)
        {
            int dataStorageSize = 1;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if ((str[i] == ' ') && (str[i + 1] != ' '))
                {
                    dataStorageSize++;
                }
            }

            if (str[0] == ' ')
            {
                dataStorageSize--;
            }

            return dataStorageSize;
        }


        class DrawValues : DataStorageFiller
        {
            public DrawValues()
            {
                int userOutput;

                do
                {
                    Interact.WriteText(ConsoleColor.Magenta, " How much digits you want to draw ? (compartment 2-10000)");
                    userOutput = Interact.TakeUserOutput(10000);
                }
                while (!checkMinOutput(userOutput));

                dataStorage = new int[userOutput];

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

        class TypedValues : DataStorageFiller
        {
            public TypedValues()
            {
                ChangeStringToInt(AskUserForDigits());
            }

            string AskUserForDigits()
            {
                string userOutput;
                bool goodOutput;

                do
                {
                    Interact.WriteText(ConsoleColor.DarkRed, " The maximum length of a single value is 10 digits.;"// int = 32 bits = -2 147 483 648 to 2 147 483 647.
                                                            +"\n Compartment 2-10000."
                                                            +"\n A single value should be separated by ' ' space.");
                    Interact.WriteText(ConsoleColor.Magenta, " Insert your date here:");

                    goodOutput = IsDigitsOnly(userOutput = Console.ReadLine());
                    if (!goodOutput)
                    {
                        Interact.WriteText(ConsoleColor.Red, " Insert digits only !");
                    }

                } while (!goodOutput);

                return userOutput;
            }
        }

        class ReadValuesFromFile : DataStorageFiller
        {
            public ReadValuesFromFile()
            {
                AskUserForFile();
            }

            void AskUserForFile()
            {
                string filePath;
                string fileData = "";
                bool correctData = false;

                Interact.WriteText(ConsoleColor.Magenta, " How do you want to upload the data?\n  1. Insert file path \n  2. Insert file name(file should be in Project folder)");
                Interact.WriteText(ConsoleColor.DarkRed, "\n The maximum length of a single value is 10 digits !\n Compartment 2-10000\n A single value should be separated by ' ' space.");

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

                    if (filePath != "false")
                    {
                        fileData = File.ReadAllText(filePath);
                        correctData = IsDigitsOnly(fileData);

                        if (!correctData || fileData == "")
                        {
                            Interact.WriteText(ConsoleColor.Red, " File data contains letters or invalid special characters. Check file and try again.");
                        }
                    }
                } while (!correctData || filePath == "false");

                ChangeStringToInt(fileData);
            }

            string TakeFilePathFromUser()
            {
                string filePath;

                Interact.WriteText(ConsoleColor.Red, @" Insert full path to the txt file. It should looks like C:\User\Destop\file.txt");
                filePath = Console.ReadLine();

                filePath = CheckFilePath(filePath);

                return filePath;
            }

            string TakeFileNameFromUser()
            {
                string fileName;
                string filePath = Environment.CurrentDirectory;

                // Get path to the project folder.
                filePath = Directory.GetParent(filePath).Parent.Parent.FullName;

                do
                {
                    Interact.WriteText(ConsoleColor.Red, " Insert file name. It should be txt file !");
                    fileName = Console.ReadLine();

                    filePath += @$"\{fileName}";

                    filePath = CheckFilePath(filePath);

                } while (filePath == "false");

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
