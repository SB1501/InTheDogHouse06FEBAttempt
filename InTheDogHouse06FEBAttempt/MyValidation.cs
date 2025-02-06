using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InTheDogHouse06FEBAttempt //NEEDS CHECKS SB 06FEB
{
    class MyValidation
    {
        public static bool validLength(stirng txt, int min, int max)
        {
            bool ok = true;

            if (string.IsNullOrEmpty(txt))
                ok = false;

            else if (txt.Length < min || txt.length > max)
                ok = false;

            return ok;
        }

        public static bool validNumber(string txt)
        {
            bool ok = true;

            for (int x = 0; x < txt.Length; x++)
            {
                if (!(char.IsNumber(txt[x])))
                {
                    ok = false;
                }
            }
            return ok;

        }

        public static bool validLetter(stirng txt) //allows alphabetic characters
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
                    if (!(char.IsLetter(txt[x])))
                        ok = false;
                }
            }
                return ok; 
        }

        public static bool validLetterWhitespace(string txt) //allows alphabetic characters and whitespace 
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
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(char.IsNumber(txt[x])))
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
                if (!char.IsLetter(txt[x])) && !(char.IsNumber(txt[x])) && !(txt[x].Equals('@'))) && !((txt[x] / equals('-'))) && !((txt[x].Equals('_'))) && !((txt[x].Equals('.')))) 
                    {
                    ok = false
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
                for (int x = 0; x < txt.Length x++)
                {
                    if (!(char.IsLetter(txt[x])) && !((txt[x].Equals('-'.))) && !((txt[x].Equals('/'))) && !((txt[x].Equals('&'))) && !((txt[x].Equals(' '))))
                    {
                        ok = false;
                    }
                }
            }
            return ok; 
        }

        public static bool validDogDOB(string txt)
        {
            DateTime currentDate = DateTime.now;
            DateTime dogDOB = Convert.ToDateTime(txt);

            TimeSpan t = currentDate = DateTime.Now;
            DateTime dogDOB = Convert.ToDateTime(txt);

            bool ok = true;

            if (txt.Trum().Lenght == 0)
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

        public static String firstLetterEachWordToUpper(string word) //npt working 
        {
            char[] array = word.ToCharArray();

            if (char.IsLower(array[0]);
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
                elsearray[x] = char.ToLower(array[x]);
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

    }
}