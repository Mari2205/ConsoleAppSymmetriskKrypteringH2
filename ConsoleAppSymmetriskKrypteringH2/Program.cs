﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleAppSymmetriskKrypteringH2
{
    class Program
    {
        static void Main(string[] args)
        {
            Gui gui = new Gui();

            string[] choicesForTheUser = { "DES", "Triple DES", "Aes" };

            string usrText = gui.GetUsrTextInput();

            while (true)
            {
                Console.Clear();
                gui.SetMenuHeading();
                gui.SetMenuBody(choicesForTheUser);

                EncryptingAndDecrytingSwitch(gui.UsrChoiceOfcryteringType(), usrText);

                Console.ReadKey();
            }
        }

        private static void EncryptingAndDecrytingSwitch(int cryteringType, string text)
        {
            Kryptering kryptering = new Kryptering();
            Decrypt decrypting = new Decrypt();
            GenrateKey genrateKey = new GenrateKey();
            Gui gui = new Gui();
            Stopwatch stopwatch = new Stopwatch();

            byte[] key;
            byte[] iv;
            string originalMessage = text;

            switch (cryteringType)
            {
                case 1:
                    key = genrateKey.GenrateRandomNumber(8);
                    iv = genrateKey.GenrateRandomNumber(8);

                    stopwatch.Start();
                    byte[] encryptedDES = kryptering.DESEncrypt(Encoding.UTF8.GetBytes(originalMessage), key, iv);
                    byte[] decryptedDES = decrypting.DNSDecrypt(encryptedDES, key, iv);
                    stopwatch.Stop();

                    string decryptedMessageWhitDES = Encoding.UTF8.GetString(decryptedDES);

                    gui.PrintCrypteringAndDecrytering(originalMessage, Convert.ToBase64String(encryptedDES), decryptedMessageWhitDES, stopwatch.Elapsed);

                    break;
                case 2:
                    key = genrateKey.GenrateRandomNumber(16);
                    iv = genrateKey.GenrateRandomNumber(8);

                    stopwatch.Start();
                    byte[] encryptedTripleDES = kryptering.TripleDESEncrypt(Encoding.UTF8.GetBytes(originalMessage), key, iv);
                    byte[] decryptedTripleDES = decrypting.TripleDESDecrypt(encryptedTripleDES, key, iv);
                    stopwatch.Stop();

                    var decryptedMessageWhitTripleDES = Encoding.UTF8.GetString(decryptedTripleDES);

                    gui.PrintCrypteringAndDecrytering(originalMessage, Convert.ToBase64String(encryptedTripleDES), decryptedMessageWhitTripleDES, stopwatch.Elapsed);

                    break;
                case 3:
                    key = genrateKey.GenrateRandomNumber(32);
                    iv = genrateKey.GenrateRandomNumber(16);

                    stopwatch.Start();
                    byte[] encryptedAes = kryptering.AesEncrypt(Encoding.UTF8.GetBytes(originalMessage), key, iv);
                    byte[] decryptedAes = decrypting.AesDecrypt(encryptedAes, key, iv);
                    stopwatch.Stop();

                    var decryptedMessageWhitAes = Encoding.UTF8.GetString(decryptedAes);

                    gui.PrintCrypteringAndDecrytering(originalMessage, Convert.ToBase64String(encryptedAes), decryptedMessageWhitAes, stopwatch.Elapsed);

                    break;
                default:
                    Console.WriteLine("Pleace, press enter and enter a valid number");
                    break;
            }
        }
    }
}
