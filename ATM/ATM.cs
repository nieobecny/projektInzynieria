using System;
using System.Collections.Generic;

namespace ATM
{
    public class Atm
    {
        public static List<Client> banndedList = new List<Client>();
        public static bool isLogged = false;
        public static int clientIndex;
        public static Client LogIn(List<Client> cl)
        {   Client clBack = new Client();
            bool goodLogin = false;
            int tries=3;
            do
            {
                Console.WriteLine("podaj Numer konta");
                clBack.accountNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("podaj PIN");
                clBack.pin = Int32.Parse(Console.ReadLine());
                if(banndedList.Exists(x => x.accountNumber == clBack.accountNumber))
                {
                    Console.WriteLine("dane konto jest zablokowane");
                    break;
                }
                if (cl.Exists(x => x.accountNumber == clBack.accountNumber))
                {
                    
                    
                    clientIndex = cl.FindIndex(x => x.accountNumber == clBack.accountNumber);
                    if (cl[clientIndex].pin != clBack.pin)
                    {
                        Console.WriteLine("Nieprawidlowy pin lub numer konta");  
                        tries--;

                    }
                    else
                    {
                        clBack = cl[clientIndex];
                        isLogged = true;
                        goodLogin = true;
                        Console.WriteLine("Zalogowano");    
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidlowy pin lub numer konta");
                    tries--;
                    
                }
                if (tries == 0)
                {
                    banndedList.Add(clBack);
                    Console.WriteLine("Blokowanie konta");

                    break;
                }
            } while (!goodLogin);
            return clBack;
        }

        public static void CheckState(Client client)
        {
            Console.WriteLine("Stan konta nr {0}:", client.accountNumber);
            Console.WriteLine("{0} zł", client.accountBalance);
        }

        public static void putMoney(Client client, List<Client> lstClients)
        {
            Console.WriteLine("Podaj kwotę do wpłaty");
            client.accountBalance += Double.Parse(Console.ReadLine());
            client.accountBalance = Math.Round(client.accountBalance, 2);
            CheckState(client);
            lstClients[clientIndex] = client;
            ClientDB.SaveList(lstClients);
        }

        public static void getMoney(Client client, List<Client> lstClients)
        {
            double getBackMoney;
            Console.WriteLine("Podaj kwotę do wypłaty");
            getBackMoney= Double.Parse(Console.ReadLine());
            if (getBackMoney < client.accountBalance)
            {
                client.accountBalance -= getBackMoney;
                client.accountBalance = Math.Round(client.accountBalance, 2);
                CheckState(client);
                lstClients[clientIndex] = client;
                ClientDB.SaveList(lstClients);
            }
            else
            {
                Console.WriteLine("Brak odpowiednich środków do wykonania transakcji");
            }
            
        }

        public static void Logout()
        {
            isLogged = false;
            clientIndex = -1;
        }

        

      

    }
}