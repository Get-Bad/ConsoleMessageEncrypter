string lowerRussianAlphabet1 = "абвгдеёжзийклмноп";
string lowerRussianAlphabet2 = "рстуфхцчшщъыьэюя";
string upperRussianAlphabet1 = "АБВГДЕЁЖЗИЙКЛМНОП";
string upperRussianAlphabet2 = "РСТУФХЦЧШЩЪЫЬЭЮЯ";
string lowerEnglishAlphabet1 = "abcdefghijklmno";
string lowerEnglishAlphabet2 = "pqrstuvwxyz";
string upperEnglishAlphabet1 = "ABCDEFGHIJKLMNO";
string upperEnglishAlphabet2 = "PQSTUVWXYZ";
string numbers = "0123456789";                                      
string specialSymbols = "!@#$%^&*(){}[],/.-_=+?№";                   
string spaceSymbol = " ";                                           

string cryptoAlphabet = lowerEnglishAlphabet1 + lowerRussianAlphabet1 + numbers + lowerEnglishAlphabet2 + upperRussianAlphabet2 + upperEnglishAlphabet2 + upperRussianAlphabet1 + specialSymbols + upperEnglishAlphabet1 + spaceSymbol + lowerRussianAlphabet2;

string finalMessage = "";

Dictionary<char, int> EncryptDictionary = [];   
Dictionary<int, char> DecryptDictionary = [];   

List<int> MessageList = [];
List<int> KeyList = [];
List<int> EncryptedMessageList = [];
List<int> DecryptedMessageList = [];


void AddSymbolsToDictionaries()     //  Adding all chars into the dictionaries
{
    for (int i = 0; i < cryptoAlphabet.Length; i++)
    {
        EncryptDictionary.Add(cryptoAlphabet[i], i+1);
        DecryptDictionary.Add(i+1, cryptoAlphabet[i]);
    }
}

void ConvertStringToIntList(string convertWord, Dictionary<char, int> ConvertDictionary, List<int> convertList)     //  Function which convert message or key for encrypt/decrypt into the int values
{
    convertList.Clear();
    foreach (char c in convertWord)
    {
        if (ConvertDictionary.ContainsKey(c))
        {
            convertList.Add(ConvertDictionary[c]);
        }
    }
}

void ConvertIntListToString(string finalMessage, Dictionary<int, char> ConvertDictionary, List<int> convertList)    //  Function which convert encrypted/decrypted message from int value to string value
{
    finalMessage = null;
    foreach (int numOfWord in convertList)
    {
        if (ConvertDictionary.ContainsKey(numOfWord))
        { 
            finalMessage += ConvertDictionary[numOfWord];
        }
    }
    Console.WriteLine("");
    Console.WriteLine(finalMessage);
}

void EncryptList(List<int> MessageList, List<int> KeyList, List<int> EncryptedMessageList)      //  Function which encrypt message with a key 
{
    EncryptedMessageList.Clear();
    foreach(int num1 in MessageList)
    {
        foreach (int num2 in KeyList)
        {
            EncryptedMessageList.Add(num1+num2);
            break;
        }
    }
}

void DecryptList(List<int> MessageList, List<int> KeyList, List<int> DecryptedMessageList, Dictionary<int, char> ConvertDictionary)     //  Function which decrypt message with a key 
{
    int dictCount = ConvertDictionary.Count;
    DecryptedMessageList.Clear();
    foreach (int num1 in MessageList)
    {
        foreach (int num2 in KeyList)
        {
            if (num1 > num2)
            {
                DecryptedMessageList.Add(num1-num2);
                break;
            } else
            {
                DecryptedMessageList.Add((num1+dictCount)-num2);
                break;
            }
        }
    }
}

void CheckIntList (List<int> EncryptedMessage, Dictionary<char, int> CryptoDictionary)      //  Function which check encrypted message for compliance with the max lenght of the dictionary
{
    int cryptoDictionaryCount = CryptoDictionary.Count;
    for (int i = 0; i < EncryptedMessage.Count; i++)
    {
        if (EncryptedMessage[i] > cryptoDictionaryCount)
        {
            EncryptedMessageList[i] = EncryptedMessageList[i] % cryptoDictionaryCount;
        }
    }
}




AddSymbolsToDictionaries();     //  Begin of program

Console.WriteLine("Welcome to Gate v1.2 by Get_Bad!");      //  Some useless info
Console.WriteLine("");

while (true)  
{
    Console.WriteLine("");
    Console.WriteLine("English - 1, Русский - 2");      //  Language select
    string languageChoose = Console.ReadLine();

    if (languageChoose == "1")
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Encrypt mode - 1, Decrypt mode - 2, Change language - 3");   // Mode select or return to select menu
            Console.Write("Choose mode: ");
            string cryptoMode = Console.ReadLine();

            if (cryptoMode == "1")      //  Encrypt mode
            {
                Console.WriteLine("");
                Console.Write("Enter message: ");
                string messageForEncrypt = Console.ReadLine();

                Console.Write("Enter key: ");
                string keyForEncrypt = Console.ReadLine();

                ConvertStringToIntList(messageForEncrypt, EncryptDictionary, MessageList);
                ConvertStringToIntList(keyForEncrypt, EncryptDictionary, KeyList);
                EncryptList(MessageList, KeyList, EncryptedMessageList);
                CheckIntList(EncryptedMessageList, EncryptDictionary);
                ConvertIntListToString(finalMessage, DecryptDictionary, EncryptedMessageList);
            }
            else if (cryptoMode == "2")     //  Encrypt mode
            {
                Console.WriteLine("");
                Console.Write("Enter message: ");
                string messageForDecrypt = Console.ReadLine();

                Console.Write("Enter key: ");
                string keyForDecrypt = Console.ReadLine();

                ConvertStringToIntList(messageForDecrypt, EncryptDictionary, MessageList);
                ConvertStringToIntList(keyForDecrypt, EncryptDictionary, KeyList);
                DecryptList(MessageList, KeyList, DecryptedMessageList, DecryptDictionary);
                ConvertIntListToString(finalMessage, DecryptDictionary, DecryptedMessageList);
            } 
            else if (cryptoMode == "3")     
            {
                break;
            } else
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid value!");    //  Exception handler
            }
        }
    } 
    else if (languageChoose == "2")
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Режим шифрования - 1, Режим дешифрования - 2, Сменить язык - 3");    //  Mode select or return to select mode
            Console.Write("Выберите режим: ");
            string cryptoMode = Console.ReadLine();

            if (cryptoMode == "1")  //  Encrypt mode
            {
                Console.WriteLine("");
                Console.Write("Введите сообщение: ");
                string messageForEncrypt = Console.ReadLine();

                Console.Write("Введите ключ: ");
                string keyForEncrypt = Console.ReadLine();

                ConvertStringToIntList(messageForEncrypt, EncryptDictionary, MessageList);
                ConvertStringToIntList(keyForEncrypt, EncryptDictionary, KeyList);
                EncryptList(MessageList, KeyList, EncryptedMessageList);
                CheckIntList(EncryptedMessageList, EncryptDictionary);
                ConvertIntListToString(finalMessage, DecryptDictionary, EncryptedMessageList);
            }
            else if (cryptoMode == "2")     //  Decrypt mode
            {
                Console.WriteLine("");
                Console.Write("Введите сообщение: ");
                string messageForDecrypt = Console.ReadLine();

                Console.Write("Введите ключ: ");
                string keyForDecrypt = Console.ReadLine();

                ConvertStringToIntList(messageForDecrypt, EncryptDictionary, MessageList);
                ConvertStringToIntList(keyForDecrypt, EncryptDictionary, KeyList);
                DecryptList(MessageList, KeyList, DecryptedMessageList, DecryptDictionary);
                ConvertIntListToString(finalMessage, DecryptDictionary, DecryptedMessageList);
            }
            else if (cryptoMode == "3")     
            {
                break;
            } 
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Неподдерживаемое значение!");    //  Exception handler
            }
        }
    } 
    else
    {
        Console.WriteLine("");
        Console.WriteLine("Invalid value!");    //  Exception handler

    }
}