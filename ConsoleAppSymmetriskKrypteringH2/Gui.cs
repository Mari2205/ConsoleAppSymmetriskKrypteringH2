using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSymmetriskKrypteringH2
{
    class Gui
    {
        public void SetMenuHeading()
        {
            string acsiiMenu = @"                
$$$$$$\$$$$\   $$$$$$\  $$$$$$$\  $$\   $$\ 
$$  _$$  _$$\ $$  __$$\ $$  __$$\ $$ |  $$ |
$$ / $$ / $$ |$$$$$$$$ |$$ |  $$ |$$ |  $$ |
$$ | $$ | $$ |$$   ____|$$ |  $$ |$$ |  $$ |
$$ | $$ | $$ |\$$$$$$$\ $$ |  $$ |\$$$$$$  |
\__| \__| \__| \_______|\__|  \__| \______/                                            
";

            Console.WriteLine(acsiiMenu);
        }
        public void SetMenuBody(string[] listOfChoices)
        {
            int numbering = 1;
            foreach (string choices in listOfChoices)
            {
                Console.WriteLine(numbering + ") " + choices.ToString());
                numbering++;
            }
        }

        public string GetUsrTextInput()
        {
            try
            {
                Console.WriteLine("Pleace enter an message:");
                string usrText = Console.ReadLine();

                return usrText;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not enter an String value");
                Console.ResetColor();
            }
            return null;
        }

        public int UsrChoiceOfcryteringType()
        {
            try
            {
            Console.WriteLine("Pleace choose a number:");
            int usrNo = Convert.ToInt32(Console.ReadLine());

            return usrNo;
            }
            catch (Exception)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not enter an int value");
                Console.ResetColor(); 
            }
            return 0;
        }

        public void PrintCrypteringAndDecrytering(string message, string encryptedText, string decryptedText, TimeSpan TimeToExecrute)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Original Text = " + message);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Encrypted Text = " + encryptedText);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Decrypted Text = " + decryptedText);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Time to execrute = " + TimeToExecrute);
            Console.WriteLine("---------------------------------------------------");
        }
    }
}
