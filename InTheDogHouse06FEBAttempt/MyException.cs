using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InTheDogHouse06FEBAttempt //Namespace to be the same as all other classes
{
    class MyException : Exception 
    {
        private string message;  //variable for message

        public MyException(string message) //takes in the message 
        {
            this.message = message; //assigns messsage to this instance 
        }

        public String toString()
        {
            return string.Format("Error:{0}", message);
        }
    }
}
