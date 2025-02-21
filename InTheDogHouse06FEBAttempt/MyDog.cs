using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InTheDogHouse06FEBAttempt
{
    class MyDog 
    {
        private int dogNo, breedNo, customerNo;
        private string name, DOB, gender, colour;

        public MyDog()
        { //BLANK CONSTRUCTOR, takes nothing in
            this.dogNo = 0; this.breedNo = 0; this.customerNo = 0;
            this.name = ""; this.DOB = ""; this.gender = ""; this.colour = "";
        }

        public MyDog(int dogNo, string name, int breedNo, string DOB, string gender, string colour, int customerNo)
        { //SPECIFIED CONSTRUCTOR, takes input values with data type 
            this.dogNo = dogNo; this.breedNo = breedNo; this.customerNo = customerNo;
            this.name = name; this.DOB = DOB; this.gender = gender; this.colour = colour;
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

        public int BreedNo
        { 
            get { return breedNo; }
            set { breedNo = value; }
        }

        public string Dob //MIGHT HAVE ISSUES WITH NESTED DATE CHECKS (valid format, then 56 days)
        {
            get { return DOB; }
            set
            {
                
                    if (MyValidation.validDogDOB(value))
                    {
                        DOB = MyValidation.firstLetterEachWordToUpper(value);
                    }
                    else
                        throw new MyException("Dog must be at least 56 days old to be booked in.");
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

        public int CustomerNo
        {
            get { return customerNo; } //CHANGED 20FEB to customerNo from breedNo
            set { customerNo = value; }
        }

    }
}