using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InTheDogHouse06FEBAttempt
{
    class MyDog //FIX VALIDATION RULES FOR NEW DOG FIELDS FORM
    {
        private int dogNo;
        private string name, breedNo, DOB, gender, colour, customerNo;

        public MyDog()
        { //BLANK CONSTRUCTOR, takes nothing in
            this.dogNo = 0;
            this.name = ""; this.breedNo = ""; this.DOB = ""; this.gender = ""; this.colour = ""; this.customerNo = "";
        }

        public MyDog(int dogNo, string name, string breedNo, string DOB, string gender, string colour, string customerNo)
        { //SPECIFIED CONSTRUCTOR, takes input values with data type 
            this.dogNo = dogNo;
            this.name = name; this.breedNo = breedNo; this.DOB = DOB; this.gender = gender; this.colour = colour; this.customerNo = customerNo;
        }

        public int DogNo
        {  //GETTERS SETTERS
            get { return dogNo; }
            set { dogNo = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validForename(value))
                {
                    name = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Name must be 2-15 letters");
            }
        }

        public string BreedNo
        {
            get { return breedNo; } //ISSUES - As form still shows numbers, not names.
            set
            {
                if (value.ToUpper() != "Labrador" && value.ToUpper() != "Alaskan Malamute" && value.ToUpper() != "St Bernard" && value.ToUpper() != "Poodle" && value.ToUpper() != "Border Collie" && value.ToUpper() != "Shih Tzu" && value.ToUpper() != "Alsatian" && value.ToUpper() != "Bulldog" && value.ToUpper() != "German Shepherd" && value.ToUpper() != "Jack Russell" && value.ToUpper() != "Boxer" && value.ToUpper() != "Pug")
                    throw new MyException("You must select a valid breed type.");
                else
                    breedNo = MyValidation.firstLetterEachWordToUpper(value);
            }
        }

        public string Dob //MIGHT HAVE ISSUES WITH NESTED DATE CHECKS (valid format, then 56 days)
        {
            get { return DOB; }
            set
            {
                if (MyValidation.validDate(value))
                {
                    if (MyValidation.validDogDOB(value))
                    {
                        DOB = MyValidation.firstLetterEachWordToUpper(value);
                    }
                    else
                        throw new MyException("Dog must be at least 56 days old to be booked in.");
                }
                else
                    throw new MyException("Date must by dd/mm/yyyy format!");

            }

        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (value.ToUpper() != "M" && value.ToUpper() != "F")
                    throw new MyException("Gender must be M or F");
                else
                    gender = MyValidation.firstLetterEachWordToUpper(value);
            }
        }

        public string Colour
        {
            get { return colour; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetterWhitespace(value))
                {
                    colour = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Colour must be 2-20 letters");
            }
        }

        public string CustomerNo
        {
            get { return customerNo; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    customerNo = value;
                }
                else
                {
                    throw new MyException("CustomerNo cannot be null or empty.");
                }
            }

        }

    }
}