using System;
using System.Text;


Console.WriteLine(" Задание 1. ConcatenateStrings");
string result1 = ConcatenateStrings("Hello ", "World!"); 
Console.WriteLine(result1);                                                                                                                           // Задание 1.
 
string ConcatenateStrings(string a, string b) => a + b;



Console.WriteLine("\nЗадание 2. GreetUser");
string result2 = GreetUser("Rinat", 30);  
Console.WriteLine(result2);                                                                                                                           // Задание 2.

string GreetUser(string name, int age) => $"Hello {name}! You are {age} years old.\n ";



Console.WriteLine(" Задание 3. GetStringInfo");
string result3 = GetStringInfo("Hello World");                                                                                                        // Задание 3.
Console.WriteLine(result3);

string GetStringInfo(string input) => $"Length: {input.Length}\nUper: {input.ToUpper()}\nLower: {input.ToLower()}";



Console.WriteLine(" \nЗадание 4. GetFirstFiveCharacters");
Console.WriteLine(GetFirstFiveCharacters("Programming"));  //Progr                                                                                    // Задание 4.
Console.WriteLine(GetFirstFiveCharacters("Hi")); //Hi

string GetFirstFiveCharacters(string input) => input.Length >= 5 ? input.Substring(0,5) : input;



Console.WriteLine(" \nЗадание 5. BuildSentenceFromArray");
string[] words =  { "This", "is", "a", "sentence" };
StringBuilder sentenceBuilder = BuildSentenceFromArray(words);
Console.WriteLine(sentenceBuilder.ToString());                                                                                                        // Задание 5.

StringBuilder BuildSentenceFromArray(string[] words)
{
    var sb = new StringBuilder();
    for (int i = 0; i < words.Length; i++)
    {
        if (i > 0)
        {
            sb.Append(' ');
        }
        sb.Append(words[i]);
    }
    return sb;
}




Console.WriteLine("\nЗадание 6. ReplaseWords");
string result6 = ReplaceWorlds("Hello World, world is beautiful ", "world", "universe");
Console.WriteLine(result6);                                                                                                                            // Задание 6.

string ReplaceWorlds(string inputStrings, string wordToReplace, string replacementWord) =>
    inputStrings.Replace(wordToReplace, replacementWord);