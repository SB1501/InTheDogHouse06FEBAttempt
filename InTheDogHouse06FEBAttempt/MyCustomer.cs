using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheDogHouse06FEBAttempt; //NEEDS CHECKED SB06FEB

class MyCustomer
{
    private int customerNo;
    private string title, surname, forename, street, town, county, postcode, telNo;

    public MyCustomer()
    { //BLANK CONSTRUCTOR, takes nothing in
        this.customerNo = 0;
        this.title = "", this.surname = "", this.forename = ""; this.street = ""; this.town = ""; this.county = ""; this.postcode = ""; this.telNo = "";
    }

    public MyCustomer(int customerNo, string title, string surname, string forename, string street, string, town, stirng county, string postcode, string telNo)
    { //SPECIFIED CONSTRUCTOR, takes input values with data type 
        this.customerNo = customerNo;
        this.title = title; this.surname = surname; this.forename = forename; this.street = street; this.town = town; this.county = county; this.postcode = postcode; this.telNo = telNo;
    }

    public int customerNo
    {  //GETTERS SETTERS
        get { return customerNo; }
        set { customerNo = value; }
    }

    public string Title
    {
        get {return title;}
        set
        {
            if (value.ToUppe() != "MR" && value.ToUpper() != "MRS" && value.ToUpper() != "MISS" && value.ToUpper() != "MS")
                throw new MyException("Title must be Mr, Mrs, Miss or Ms.");
            else
                title = MyValidation.firstLetterEachWordToUpper(value);
        }
    }

    public string Surname
    {
        get { return surname; }
        set 
        {
            if (MyValidation.validLength(value, 2, 15) && MyValidation.validSurname(value))
            {
                surname = MyValidation.firstLetterEachWordtoUpper(value);
            }
            else
                throw new MyException("Surname must be 2-15 letters");
        }
    }

    public string Forename
    {
        get { return foename; }
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

    public string Street
    { 
    get { return street; }
        set {
            if (MyValidation.validLength(value, 5, 40) && MyValidation.validLetterNumberWhitespace(value))
            {
                street = MyValidation.firstLetterEachWordToUpper(value);
            }
            else
                throw new MyException("Street must be 5-40 letters");
        }
    }

    public string Town
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

    public string County
    { 
    get { return county; }
        set 
        {
            if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetter(value))
            {
                county = MyValidation.firstLetterEachWordToUpper(value);
            }
            else
                throw new MyExceptiopn("County must be 2-20 letters");
        }
    }
    
    public string Postcode
    {
        get { return postcode; }
        set
        {
            if (MyValidation.validLength(value, 7, 8) && MyValidation.validLetterNumberWhitespace(value))
            {
                postcode = MyValidation.EachLetterToUpper(value);
            }
            else
                throw new MyExceptiopn("Postcode must be 7-8 letters and alphanumeric onlys");
        }
    }

    public string TelNo
    {
        get { return telNo; }
        set
        {
            if (MyValidation.validLength(value, 11, 15) && MyValidation.validNumber(value))
            {
                telNo = value;
            }
            else
                throw new MyExceptiopn("Telephone number must be 11-15 digits");
        }
     }

    }

}
