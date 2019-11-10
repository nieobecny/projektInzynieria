using System;
using System.Xml.Serialization;

namespace ATM
{
    [Serializable]
    public class Client
    {
        public int accountNumber{ get; set; }
        public int pin { get; set; }
        public double accountBalance{ get; set; }

        public Client(int accountNumber, int pin)
        {
            this.accountNumber = accountNumber;
            this.pin = pin;
        }

        public Client()
        {

        }

        
    }
    
    
}