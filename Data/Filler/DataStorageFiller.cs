using System;
using System.Text;

namespace AlgorithmComparisonEngine.Data.Filler
{
    internal class DataStorageFiller
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

        private void TakeDigitsFromUser()
        {
            int maxchoice = 3;
            Interact.WriteText(ConsoleColor.Magenta, 
                " Which method do you want to choose for delivering numbers? \n" +
                "  1. Draw \n" +
                "  2. Write on console \n" +
                "  3. Upload file");

            switch (Interact.TakeUserOutput(maxchoice))
            {
                case 1:
                    {
                        _ = new DrawValues();
                        break;
                    }
                case 2:
                    {
                        _ = new TypeValues();
                        break;
                    }
                case 3:
                    {
                        _ = new ReadFromFile();
                        break;
                    }
            }
        }

        protected bool IsDigitsOnly(string str)
        {
            for (int i = 0; i < str.Length; i++)
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
        // This can be done with String.Split(), but I wanted to do it myself and use Stringbuilder - String.Split() is commented bellow StringBuilder code.
        protected void ChangeStringToInt(string strToChange)
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
        private int DeclareDateStorageSize(string str)
        {
            int dataStorageSize = 1;

            for (int i = 0; i < str.Length; i++)
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
    }
}
