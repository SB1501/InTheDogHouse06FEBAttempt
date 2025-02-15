using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace InTheDogHouse06FEBAttempt
{
    public partial class frmDog : Form
    {

        private System.Windows.Forms.ErrorProvider errP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.DataGridView dgvDog;
        private System.Windows.Forms.Button btnDisplayAdd;
        private System.Windows.Forms.Button btnDisplayEdit;
        private System.Windows.Forms.Button btnDisplayDelete;
        private System.Windows.Forms.Button btnDisplayExit;
        private System.Windows.Forms.Label lblAddDogNo;
        private System.Windows.Forms.Label lblAddName;
        private System.Windows.Forms.Label lblAddBreed;
        private System.Windows.Forms.Label lblAddDOB;
        private System.Windows.Forms.Label lblAddGender;
        private System.Windows.Forms.Label lblAddColour;
        private System.Windows.Forms.Label lblAddCustNo;
        private System.Windows.Forms.Label lblAddDogNumber;
        private System.Windows.Forms.ComboBox cboCustNo;
        private System.Windows.Forms.TextBox txtAddDOB;
        private System.Windows.Forms.TextBox txtAddGender;
        private System.Windows.Forms.TextBox txtAddColour;
        private System.Windows.Forms.Button btnAddCancel;
        private System.Windows.Forms.Button btnAddAdd;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnEditEdit;


        //DECLARING VARIABLES
        SqlDataAdapter daDog, daCustomer, daBooking, daBreed; //daDog daBooking for Delete check child record code
        DataSet dsInTheDogHouse = new DataSet();
        SqlCommandBuilder cmdBDog, cmdBCustomer, cmdBBooking; //dog booking ones added for Delete function
        DataRow drDog;
        String connStr, sqlDog;
        int selectedTab = 0;
        bool dogSelected = false;
        int dogNoSelected = 0;

        public frmDog()
        {
            InitializeComponent();
        }


        private void frmDog_Load(object sender, EventArgs e)
        {                                           //UPDATE PIPE IF CONNECTION ISSUE OCCURS
            string SqlConnectionStringBuilder = @"Data Source =np:\\.\pipe\LOCALDB#275E39B0\tsql\query;Initial Catalog = InTheDogHouse; Integrated Security = true";

            //SELECT Dog table
            string sqlDog = @"SELECT * FROM Dog";
            daDog = new SqlDataAdapter(sqlDog, SqlConnectionStringBuilder);
            cmdBDog = new SqlCommandBuilder(daDog);
            daDog.FillSchema(dsInTheDogHouse, SchemaType.Source, "Dog");
            daDog.Fill(dsInTheDogHouse, "Dog");

            //SELECT Customer (for checking Delete / existing child records) //MAY NEED CHANGED!
            string sqlCustomer = @"SELECT * FROM Customer";
            daCustomer = new SqlDataAdapter(sqlCustomer, SqlConnectionStringBuilder);
            cmdBCustomer = new SqlCommandBuilder(daCustomer);
            daCustomer.FillSchema(dsInTheDogHouse, SchemaType.Source, "Customer"); //MAY NEED CHANGED!
            daCustomer.Fill(dsInTheDogHouse, "Customer");

            //SELECT Booking (for checking Delete / existing child records)
            string sqlBooking = @"SELECT * FROM Booking";
            daBooking = new SqlDataAdapter(sqlBooking, SqlConnectionStringBuilder);
            cmdBBooking = new SqlCommandBuilder(daBooking);
            daBooking.FillSchema(dsInTheDogHouse, SchemaType.Source, "Booking");
            daBooking.Fill(dsInTheDogHouse, "Booking");

            //SELECT Breed (for Breed name dropdown)
            string sqlBreed = @"SELECT * FROM Breed";
            daBreed = new SqlDataAdapter(sqlBreed, SqlConnectionStringBuilder);
            cmdBBooking = new SqlCommandBuilder(daBreed);
            daBreed.FillSchema(dsInTheDogHouse, SchemaType.Source, "Breed");
            daBreed.Fill(dsInTheDogHouse, "Breed");

            dgvDog.DataSource = dsInTheDogHouse.Tables["Dog"];

            //Resize the DataGridView columns to fit the newly loaded content.

            dgvDog.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            tabControl.SelectedIndex = 1;
            tabControl.SelectedIndex = 0;

            dgvDog.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void lblAddCustNo_Click(object sender, EventArgs e)
        {

        }

        private void cboAddTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddAdd_Click(object sender, EventArgs e)
        {
            MyDog myDog = new MyDog();
            bool ok = true;
            errP.Clear();
            
            //ADD A TRY CATCH FOR NEW DOG FIELDS 

            try
            {

                myDog.DogNo = Convert.ToInt32(lblAddDogNumber.Text.Trim());
                //passed to Dog class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblAddDogNumber, MyEx.toString());
            }

            try
            {
                myDog.Name = txtAddName.Text.Trim(); //passed to Dog class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddName, MyEx.toString());
            }

            try
            {
                myDog.Dob = txtAddDOB.Text.Trim(); // passed to Dog class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddDOB, MyEx.toString());
            }

            try
            {
                myDog.Gender = txtAddGender.Text.Trim(); // passed to Dog class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddGender, MyEx.toString());
            }

            try
            {
                myDog.Colour = txtAddColour.Text.Trim(); // passed to Dog class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddColour, MyEx.toString());
            }


            try
            {
                if (ok)
                {
                    drDog = dsInTheDogHouse.Tables["Dog"].NewRow(); 
                    drDog["DogNo"] = myDog.DogNo;
                    drDog["Name"] = myDog.Name;
                    drDog["BreedNo"] = myDog.BreedNo;
                    drDog["DOB"] = myDog.Dob;
                    drDog["Gender"] = myDog.Gender;
                    drDog["CustNo"] = myDog.CustomerNo;

                    dsInTheDogHouse.Tables["Dog"].Rows.Add(drDog);
                    daDog.Update(dsInTheDogHouse, "Dog");

                    MessageBox.Show("Dog Added");

                    if (MessageBox.Show("Do you wish to add another dog?", "Add Dog", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        clearAddForm();
                        getNumber(dsInTheDogHouse.Tables["Dog"].Rows.Count);
                    }
                    else
                        tabControl.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
        void clearAddForm()
        {
            cboCustNo.SelectedIndex = -1; //ADD NEW FIELDS 
            txtAddDOB.Clear();
            txtAddGender.Clear();
            txtAddColour.Clear();
        }

        private void getNumber(int noRows)
        {
            drDog = dsInTheDogHouse.Tables["Dog"].Rows[noRows - 1];
            lblAddDogNumber.Text = (int.Parse(drDog["DogNo"].ToString()) + 1).ToString();
        }      

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {   //CHANGED 08FEB 22:13 REVERTPOINTSB
            selectedTab = tabControl.SelectedIndex;

            tabControl.TabPages[tabControl.SelectedIndex].Focus();
            tabControl.TabPages[tabControl.SelectedIndex].CausesValidation = true;

            //if (dgvDog.SelectedRows.Count == 0 && tabDogDisplay.SelectedIndex == 2)
            // tabDogDisplay.TabPages[tabDogs.SelectedIndex].CausesValidation = true;
            //else 
            //{
            switch (tabControl.SelectedIndex)
            {
                case 0: //Display tab selected
                    {
                        dsInTheDogHouse.Tables["Dog"].Clear();
                        daDog.Fill(dsInTheDogHouse, "Dog");
                        break;
                    }

                case 1: //Add tab selected
                    {
                        int noRows = dsInTheDogHouse.Tables["Dog"].Rows.Count;

                        if (noRows == 0)
                            lblAddDogNumber.Text = "10000";
                        else
                        {
                            getNumber(noRows);
                        }

                        errP.Clear();
                        clearAddForm();
                        break;
                    }

                case 2:  //Edit tab selected
                    {
                        if (dogNoSelected == 0)
                        {
                            tabControl.SelectedIndex = 0;
                            break;
                        }
                        else
                        {
                            lblEditDogNumber.Text = dogNoSelected.ToString();

                            drDog = dsInTheDogHouse.Tables["Dog"].Rows.Find(lblEditDogNumber.Text);

                            //if (drDog["Title"].ToString() == "Mr") //CHANGE FIELDS 
                            //  cboEditTitle.SelectedIndex = 0;
                            //if (drDog["Title"].ToString() == "Mrs")
                            //    cboEditTitle.SelectedIndex = 1;
                            //if (drDog["Title"].ToString() == "Miss")
                            //    cboEditTitle.SelectedIndex = 2;
                            //if (drDog["Title"].ToString() == "Ms")
                            //    cboEditTitle.SelectedIndex = 3;

                            txtEditName.Text = drDog["Name"].ToString();
                            cboEditBreedNo.Text = drDog["BreedNo"].ToString();
                            txtEditDOB.Text = drDog["DOB"].ToString();
                            txtEditGender.Text = drDog["Gender"].ToString();
                            txtEditColour.Text = drDog["Colour"].ToString();
                            cboEditCustNo.Text = drDog["CustomerNo"].ToString();

                            break;
                        }
                    }
            }
        }


        void AddTabValidate(object sender, CancelEventArgs e)
        {
            if (dgvDog.SelectedRows.Count == 0)
            {
                dogSelected = false;
                dogNoSelected = 0;
            }
            else if (dgvDog.SelectedRows.Count == 1)
            {
                dogSelected = true;
                dogNoSelected =
                    Convert.ToInt32(dgvDog.SelectedRows[0].Cells[0].Value);
            }
        }

        void EditTabValidate(object sender, CancelEventArgs e)
        {
            if (dogSelected == false && dogNoSelected == 0)
            //have to do this bit here//////
            //reset tab to display and put out message to select a customer
            {
                dogSelected = false;
                dogNoSelected = 0;
            }
            else if (dgvDog.SelectedRows.Count == 1)
            {
                dogSelected = true;
                dogNoSelected = Convert.ToInt32(dgvDog.SelectedRows[0].Cells[0].Value);
            }
        }

        private void frmDog_Shown(object sender, EventArgs e)
        {
            tabControl.TabPages[0].CausesValidation = true;
            tabControl.TabPages[0].Validating += new
                CancelEventHandler(AddTabValidate);

            tabControl.TabPages[0].CausesValidation = true;
            tabControl.TabPages[0].Validating += new
                CancelEventHandler(EditTabValidate);
        }

        private void btnEditEdit_Click(object sender, EventArgs e)
        {
            if (btnEditEdit.Text == "Edit")
            {
                lblEditDogNo.Enabled = true;
                txtEditName.Enabled = true;
                cboEditBreedNo.Enabled = true;
                txtEditDOB.Enabled = true;
                txtEditGender.Enabled = true;
                txtEditColour.Enabled = true;
                cboEditCustNo.Enabled = true;

                btnEditEdit.Text = "Save"; //different bc i have a button not a button and separate label as in example code
            }
            else
            {
                MyDog myDog = new MyDog();
                bool ok = true;
                errP.Clear();

                try //CHECK EDIT DOG NO 
                {
                    myDog.DogNo = Convert.ToInt32(lblEditDogNumber.Text.Trim());
                    //passed to Dog class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblEditDogNo, MyEx.toString());
                }
                //DOG NAME 
                try
                {
                    myDog.Name = txtEditName.Text.Trim(); //passed to Dog class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditName, MyEx.toString());
                }

                try
                {
                    myDog.BreedNo = cboEditBreedNo.Text.Trim(); //passed to Dog class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cboEditBreedNo, MyEx.toString());
                }

                try
                {
                    myDog.Dob = txtEditDOB.Text.Trim(); //passed to Dog class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditDOB, MyEx.toString());
                }

                try
                {
                    myDog.Gender = txtEditGender.Text.Trim(); //passed to Dog class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditGender, MyEx.toString());
                }

                try
                {
                    myDog.Colour = txtEditColour.Text.Trim(); //passed to Dog class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditColour, MyEx.toString());
                }

                try
                {
                    myDog.CustomerNo = cboEditCustNo.Text.Trim(); //passed to Dog class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cboEditCustNo, MyEx.toString());
                }

                try
                {
                    if (ok)
                    {
                        drDog.BeginEdit();

                        drDog["DogNo"] = myDog.DogNo;
                        drDog["Name"] = myDog.Name;
                        drDog["BreedNo"] = myDog.BreedNo;
                        drDog["DOB"] = myDog.Dob;
                        drDog["Gender"] = myDog.Gender;
                        drDog["Colour"] = myDog.Colour;
                        drDog["CustomerNo"] = myDog.CustomerNo;

                        drDog.EndEdit();

                        daDog.Update(dsInTheDogHouse, "Dog");

                        MessageBox.Show("Dog Details Updated", "Dog");

                        lblEditDogNo.Enabled = false;
                        txtEditName.Enabled = false;
                        cboEditBreedNo.Enabled = false;
                        txtEditDOB.Enabled = false;
                        txtEditGender.Enabled = false;
                        txtEditColour.Enabled = false;
                        cboEditCustNo.Enabled = false;

                        btnEditEdit.Text = "Edit"; //MAY NEED CHANGED FOR MY BUTTONS
                        tabControl.SelectedIndex = 0;

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                        MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDisplayDelete_Click(object sender, EventArgs e) //FUNCTION: DELETING RECORD
        {
            //if (lstDog.SelectedIndices.Count == 0)
            if (dgvDog.SelectedRows.Count == 0)  //first of all, if nothing is selected... prompt to select
            {
                MessageBox.Show("Please select a customer from the list.", "Select Dog");
            }
            else //...otherwise, proceed...
            {
                drDog =
             dsInTheDogHouse.Tables["Dog"].Rows.Find(dgvDog.SelectedRows[0].Cells[0].Value); //look up data from Dog table for selected row (customer number is column 0)

                //two loops, searches each record inside table looking for DogNo...

                bool found = false; //short term variable for this section only 

                //CHECK if customer number is in Booking, therefore it has associated records... 
                foreach (DataRow dr in dsInTheDogHouse.Tables["Booking"].Rows)  //for each data row in this table..repeat
                {
                    if (dr["DogNo"] == dgvDog.SelectedRows[0].Cells[0].Value) //if DogNo matches any record in Booking
                    {
                        found = true; //then it has found something 
                        break; //exit the loop
                    }
                }
                foreach (DataRow dr in dsInTheDogHouse.Tables["Dog"].Rows) //for each data row in this table..repeat
                {
                    if (dr["DogNo"] == dgvDog.SelectedRows[0].Cells[0].Value) //checks for Dog Number in Dog...
                    {
                        found = true; //found something...
                        break; //exit loop
                    }
                }
                if (found = true) //now, if it did find something... Stop and show a message box 
                {
                    MessageBox.Show("Cannot delete this record - this customer has Bookings and/or Pets against their name.", "Denied!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else //otherwise proceed to delete...
                {
                    string tempName = drDog["Forename"].ToString() + " " + drDog["Surname"].ToString() + "\'s";

                    if (MessageBox.Show("Are you sure you want to delete" + tempName + " details?", "Add Dog", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        drDog.Delete();
                        daDog.Update(dsInTheDogHouse, "Dog");
                    }
                }
            }
        }


        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition of Dog No: " + lblAddDogNumber.Text + "?", "Add Dog", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabControl.SelectedIndex = 0;
        }

        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1; //CHANGED FEB08 22:45 REVERTPOINT SB
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabEdit_Click(object sender, EventArgs e)
        {

        }

        private void cboEditBreedNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDisplayEdit_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }
        private void dgvDog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDisplayExit_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form
        }

        private void lblAddDogNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the edit of Dog No: " + lblEditDogNumber.Text + "?", "Edit Dog", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabControl.SelectedIndex = 0;
        }
    }
}