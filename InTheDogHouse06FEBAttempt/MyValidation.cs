using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Everything Windows needs to coordinate the class below...


namespace InTheDogHouse06FEBAttempt //Namespace ensures it's part of the same project as other classes

{
    class MyValidation //Class Defined - Methods inside it are for each validation check
                                //Each validation method is called where needed and given specifics
                                   //which are sent here and used in some kind of calculation
    {
        public static bool validLength(string txt, int min, int max) //CHECKS LENGTHS ARE AS SPECIFIED
        {
            bool ok = true; //Sets an 'OK' flag

            if (string.IsNullOrEmpty(txt)) //if value is empty... 
                ok = false;                 //ok flag is NOT OK

            else if (txt.Length < min || txt.Length > max) //otherwise, check if it's less than min, or more than max...
                ok = false;                                 // if it is, then it's NOT OK 
              
            return ok;  //returns OK which is a true or false value to where it was called.
        }

        public static bool validNumber(string txt)
        {
            bool ok = true;

            for (int x = 0; x < txt.Length; x++) //for each number passed...
            {
                if (!(char.IsNumber(txt[x]))) //check character by character, is it a number?
                {
                    ok = false;
                }
            }
            return ok; //only returns true if all passed are numbers..

        }

        public static bool validLetter(string txt) //allows alphabetic characters and ampersands
        {
            bool ok = true;

            if (txt.Trim().Length == 0) //checks not null
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++) //for each letter passed...
                {
                    if (!(char.IsLetter(txt[x])) && txt[x] != '&') //check character by character if it's a letter or ampersand
                        ok = false;
                }
            }
            return ok; //only returns true if each character is a letter or ampersand
        }

        public static bool validLetterWhitespace(string txt) //allows alphabetic characters, whitespace, and ampersands
        {
            bool ok = true;

            if (txt.Trim().Length == 0) //checks if null value passed
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++) //checks character by character
                {       //if it's NOT ! a letter...           ...or NOT ! whitespace...     ...or NOT ! ampersand...
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && txt[x] != '&')
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validLetterNumberWhitespace(string txt) //allows alphanumeric, whitespace, and ampersands
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(char.IsNumber(txt[x])) && txt[x] != '&')
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validForename(string txt) //allows alphabetic, dash and whitespace 
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validSurname(string txt) //allows alphabetic, dash and whitespace 
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validEmail(string txt) //allows alphanumeric and whitespace 
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsNumber(txt[x])) && !(txt[x].Equals('@')) && !((txt[x].Equals('-'))) && !((txt[x].Equals('_'))) && !((txt[x].Equals('.'))))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }
        
          

public static bool validDogColour(string txt) //allows alphanumeric and whitespace
    {
        bool ok = true;

        if (txt.Trim().Length == 0)
        {
            ok = false;
        }
        else
        {
            for (int x = 0; x < txt.Length; x++)
            {
                if (!(char.IsLetter(txt[x])) && !((txt[x].Equals('-'))) && !((txt[x].Equals('/'))) && !((txt[x].Equals('&'))) && !((txt[x].Equals(' '))))
                {
                    ok = false;
                }
            }
        }
        return ok; 
    }

    public static bool validDogDOB(string txt)
    {
        DateTime currentDate = DateTime.Now;
        DateTime dogDOB = Convert.ToDateTime(txt);

        TimeSpan t = currentDate - dogDOB;
        double NoOfDays = t.TotalDays;

        bool ok = true;

        if (txt.Trim().Length == 0)
        {
            ok = false;
        }
        else 
        {
            if (NoOfDays <= 56)
                ok = false;
        }
        return ok; 
    }

    public static String firstLetterEachWordToUpper(string word) //not working 
    {
        char[] array = word.ToCharArray();

        if (char.IsLower(array[0]))
        {
            array[0] = char.ToUpper(array[0]);
        }
        //go through array and check for spaces. Make any lowercase letters after a space uppercase

        for (int x = 1; x < array.Length; x++)
        {
            if (array[x - 1] == ' ')
            {
                if (char.IsLower(array[x]))
                {
                    array[x] = char.ToUpper(array[x]);
                }
            }
            else array[x] = char.ToLower(array[x]);
            }
        return new String(array);
        }

    public static String EachLetterToUpper(string word)
    {
        char[] array = word.ToCharArray();

        for (int x = 0; x < array.Length; x++)
        {
            if (char.IsLower(array[x]))
            {
                array[x] = char.ToUpper(array[x]);
            }
        }
        return new String(array);
    }

}

}