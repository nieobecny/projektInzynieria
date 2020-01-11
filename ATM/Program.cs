using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Threading;

namespace ATM
{
    internal class Program
    {   
        public static void Main(string[] args)
        {         
            

            List<Client> clients = new List<Client>();
            clients = ClientDB.getList();
            Client client = new Client();

            bool exit = false;
            do
            {
                Console.Clear();
                if (!Atm.isLogged)
                {
                    Console.WriteLine("Zaloguj");
                    client = Atm.LogIn(clients);
                }
                else
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Wyloguj");
                    Console.WriteLine("2. Wpłata pieniędzy");
                    Console.WriteLine("3. Wypłata pieniędzy");
                    Console.WriteLine("4. Stan konta");
                    Console.WriteLine("5. Zakończ");
                    int n = Convert.ToInt32(Console.ReadLine());

                    switch (n)
                    {
                        case 1:
                            {
                                if (Atm.isLogged)
                                {
                                    Atm.Logout();
                                    Console.WriteLine("Wylogowano");

                                }
                                else
                                {
                                    Console.WriteLine("Jesteś wylogowany");
                                }
                                break;
                            }
                        case 2:
                            {
                                if (Atm.isLogged)
                                {
                                    Atm.putMoney(client, clients);
                                }
                                else
                                {
                                    Console.WriteLine("Nie jesteś zalogowany. \n" +
                                                      "Zaloguj się aby wykonać transakcję");
                                }
                                break;
                            }
                        case 3:
                            {
                                if (Atm.isLogged)
                                {
                                    Atm.getMoney(client, clients);

                                }
                                else
                                {
                                    Console.WriteLine("Nie jesteś zalogowany. \n" +
                                                      "Zaloguj się aby wykonać transakcję");
                                }
                                break;
                            }
                        case 4:
                            {
                                if (Atm.isLogged)
                                {
                                    Atm.CheckState(client);
                                    Thread.Sleep(5000);
                                }
                                else
                                {
                                    Console.WriteLine("Nie jesteś zalogowany. \n" +
                                                      "Zaloguj się aby wykonać transakcję");
                                }
                                break;
                            }
                        case 5:
                            {
                                exit = true;
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("nie ma takiej opcji");
                                Thread.Sleep(5000);
                                break;
                            }


                    }
                }
            } while (!exit);
            
        }
    }
}
