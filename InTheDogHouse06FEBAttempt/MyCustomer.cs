using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheDogHouse06FEBAttempt //Same namespace as the other classes / files
{
    class MyCustomer 
    {
        private int customerNo; //Defines all of the fields 
        private string title, surname, forename, street, town, county, postcode, telNo;

        public MyCustomer() //BLANK CONSTRUCTOR
        { //BLANK CONSTRUCTOR, takes nothing in
            this.customerNo = 0;
            this.title = ""; this.surname = ""; this.forename = ""; this.street = ""; this.town = ""; this.county = ""; this.postcode = ""; this.telNo = "";
        }

        public MyCustomer(int customerNo, string title, string surname, string forename, string street, string town, string county, string postcode, string telNo)
        { //SPECIFIED CONSTRUCTOR, takes input values with data type 
            this.customerNo = customerNo;
            this.title = title; this.surname = surname; this.forename = forename; this.street = street; this.town = town; this.county = county; this.postcode = postcode; this.telNo = telNo;
        }

        public int CustomerNo
        {  //GETTERS SETTERS
            get {return customerNo;}
            set {customerNo = value;}
        }

        //METHOD FOR TAKING INFORMATION IN TO EACH ATTRIBUTE
        public string Title //TITLE
        {
            get {return title;}
            set
            {           //In order to write to the variable it must pass these tests... or error message
                if (value.ToUpper() != "MR" && value.ToUpper() != "MRS" && value.ToUpper() != "MISS" && value.ToUpper() != "MS")
                    throw new MyException("Title must be Mr, Mrs, Miss or Ms.");
                else
                    title = MyValidation.firstLetterEachWordToUpper(value); //writes value to title 
            }
        }

        public string Surname //SURNAME
        {
            get { return surname; }
            set
            {               //calls MyValidation class, validLength method... passes min2 max15, must get true value back 
                                                        //AND a true back from validSurname
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validSurname(value))
                {           //only then can it assign the value to surname, but puts it through UPPER method 
                    surname = MyValidation.firstLetterEachWordToUpper(value); //Writes to surname 
                }
                else //if it fails then a prompt is shown from MyException class...
                    throw new MyException("Surname must be 2-15 letters");
            }
        }

        public string Forename //FORENAME
        {
            get { return forename; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validForename(value))
                {
                    forename = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Forename must be 2-15 letters");
            }

        }

        public string Street //STREET
        {
            get { return street; }
            set
            {
                if (MyValidation.validLength(value, 5, 40) && MyValidation.validLetterNumberWhitespace(value))
                {
                    street = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Street must be 5-40 letters");
            }
        }

        public string Town //TOWN
        {
            get { return town; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetterWhitespace(value))
                {
                    town = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Town must be 2-20 letters");
            }
        }

        public string County //COUNTY
        {
            get { return county; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetter(value))
                {
                    county = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("County must be 2-20 letters");
            }
        }

        public string Postcode //POSTCODE
        {
            get { return postcode; }
            set
            {
                if (MyValidation.validLength(value, 7, 8) && MyValidation.validLetterNumberWhitespace(value))
                {
                    postcode = MyValidation.EachLetterToUpper(value);
                }
                else
                    throw new MyException("Postcode must be 7-8 letters and alphanumeric onlys");
            }
        }

        public string TelNo //TELEPHONE NUMBER
        {
            get { return telNo; }
            set
            {
                if (MyValidation.validLength(value, 11, 15) && MyValidation.validNumber(value))
                {
                    telNo = value;
                }
                else
                    throw new MyException("Telephone number must be 11-15 digits");
            }
        }

    }

}