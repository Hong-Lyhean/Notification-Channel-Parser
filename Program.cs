using System;
using System.Text.RegularExpressions;

namespace HelloWorldConsoleApp
{
    class Program
    {
        string[] channel = {"BE", "FE", "QA", "Urgent"};
        readonly string pattern = @"\[(.*?)\]";

        static void Main(string[] args)
        {
            Program department = new Program();
            Console.WriteLine("Enter a Notification Title:");
            string title = Console.ReadLine() ?? "";
            // string title = "[BE][HE][Urgent][BE] there is error";

            Console.WriteLine(ParseTitle(title, department.pattern, department.channel));
        }

        static string ParseTitle(string title, string pattern, string[] channels){
            MatchCollection matches = Regex.Matches(title, pattern);
            List<string> receiveChannel = [];

            foreach (Match match in matches)
            {
                string valueInsideBrackets = match.Groups[1].Value;
                bool is_exist = Array.Exists(channels, channel => channel == valueInsideBrackets);
                bool is_duplicate = receiveChannel.Contains(valueInsideBrackets);
                if(is_exist == true && is_duplicate == false){
                    receiveChannel.Add(valueInsideBrackets);
                }
            }
            return "Receive channels: " + string.Join(", ", receiveChannel);
        }
    }
}
