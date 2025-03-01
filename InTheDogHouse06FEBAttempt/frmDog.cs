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
        //DECLARATION OF CONTROL ELEMENTS FOR THE FORM
        private System.Windows.Forms.ErrorProvider errP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabDog;
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
        private System.Windows.Forms.ComboBox cmbAddCustNo;
        private System.Windows.Forms.TextBox txtAddColour;
        private System.Windows.Forms.Button btnAddCancel;
        private System.Windows.Forms.Button btnAddAdd;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnEditEdit;


        //DECLARING VARIABLES FOR LOCAL SQL CONNECTION
        SqlDataAdapter daDog, daCustomer, daBreed;
        DataSet dsInTheDogHouse = new DataSet();
        SqlCommandBuilder cmdBDog, cmdBCustomer, cmdBBreed; 
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
            string SqlConnectionStringBuilder = @"Data Source =np:\\.\pipe\LOCALDB#16B7BC88\tsql\query;Initial Catalog = InTheDogHouse; Integrated Security = true";

            //SELECT Dog table
            string sqlDog = @"SELECT * FROM Dog";
            daDog = new SqlDataAdapter(sqlDog, SqlConnectionStringBuilder);
            cmdBDog = new SqlCommandBuilder(daDog);
            daDog.FillSchema(dsInTheDogHouse, SchemaType.Source, "Dog");
            daDog.Fill(dsInTheDogHouse, "Dog");

            //SELECT Breed table
            string sqlBreed = @"SELECT * FROM Breed";
            daBreed = new SqlDataAdapter(sqlBreed, SqlConnectionStringBuilder);
            cmdBBreed = new SqlCommandBuilder(daBreed);
            daBreed.FillSchema(dsInTheDogHouse, SchemaType.Source, "Breed");
            daBreed.Fill(dsInTheDogHouse, "Breed");

            //SELECT Customer table
            string sqlCustomer = @"SELECT * FROM Customer";
            daCustomer = new SqlDataAdapter(sqlCustomer, SqlConnectionStringBuilder);
            cmdBCustomer = new SqlCommandBuilder(daCustomer);
            daCustomer.FillSchema(dsInTheDogHouse, SchemaType.Source, "Customer"); //MAY NEED CHANGED!
            daCustomer.Fill(dsInTheDogHouse, "Customer");

          

            

            dgvDog.DataSource = dsInTheDogHouse.Tables["Dog"];

            //Resize the DataGridView columns to fit the newly loaded content.
            dgvDog.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            tabDog.SelectedIndex = 1;
            tabDog.SelectedIndex = 0;

            dgvDog.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //NEW CODE FOR BREED DROP DOWN
            cmbAddBreedNo.DataSource = dsInTheDogHouse.Tables["Breed"];
            cmbAddBreedNo.ValueMember = "BreedNo";
            cmbAddBreedNo.DisplayMember = "BreedName";

            foreach (DataRow dr in dsInTheDogHouse.Tables["Customer"].Rows)
            {
                cmbAddCustNo.Items.Add(dr["CustomerNo"] + "(" + dr["Surname"] + "," + dr["Forename"] + ")");
            }

            cmbEditBreedNo.DataSource = dsInTheDogHouse.Tables["Breed"];
            cmbEditBreedNo.ValueMember = "BreedNo";
            cmbEditBreedNo.DisplayMember = "BreedName";

            foreach (DataRow dr in dsInTheDogHouse.Tables["Customer"].Rows)
            {
                cmbEditCustNo.Items.Add(dr["CustomerNo"] + "(" + dr["Surname"] + "," + dr["Forename"] + ")");
            }

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

            //ADD BREED DROP DOWN 
            try
            {
                myDog.BreedNo = Convert.ToInt32(cmbAddBreedNo.SelectedValue.ToString());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddBreedNo, MyEx.toString());
            }
            
            try
            {
                myDog.Dob = dtpAddDOB.Text.Trim(); // passed to Dog class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(dtpAddDOB, MyEx.toString());
            }

            try
            {
                myDog.Gender = cmbAddGender.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddGender, MyEx.toString());
            }

            try
            {
                myDog.Colour = txtAddColour.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddColour, MyEx.toString());
            }

            //DROPDOWN FOR CUSTOMER NUMBER / NAME 
            try
            {
                myDog.CustomerNo = Convert.ToInt32(cmbAddCustNo.Text.Substring(0, 5)); 
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddCustNo, MyEx.toString());
            }

            //ALL INPUT FIELDS PASS VALIDATION ABOVE. NOW TIME TO ASSIGN THIS DATA TO EACH SQL COLUMN HEADING BE:OW.

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
                    drDog["Colour"] = myDog.Colour;
                    drDog["CustomerNo"] = myDog.CustomerNo;

                    dsInTheDogHouse.Tables["Dog"].Rows.Add(drDog);
                    daDog.Update(dsInTheDogHouse, "Dog");

                    MessageBox.Show("Dog Added");

                    if (MessageBox.Show("Do you wish to add another dog?", "Add Dog", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        clearAddForm();
                        getNumber(dsInTheDogHouse.Tables["Dog"].Rows.Count);
                    }
                    else
                        tabDog.SelectedIndex = 0;

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
            cmbAddCustNo.SelectedIndex = -1; //ADD NEW FIELDS 
            //cmbAddBreedNo.Clear();
            //cmbAddGender.Clear();
            txtAddColour.Clear();
        }

        private void getNumber(int noRows)
        {
            drDog = dsInTheDogHouse.Tables["Dog"].Rows[noRows - 1];
            lblAddDogNumber.Text = (int.Parse(drDog["DogNo"].ToString()) + 1).ToString();
        }      

        private void tabDog_SelectedIndexChanged(object sender, EventArgs e)
        {   
            selectedTab = tabDog.SelectedIndex;

            tabDog.TabPages[tabDog.SelectedIndex].Focus();
            tabDog.TabPages[tabDog.SelectedIndex].CausesValidation = true;

            //if (dgvDog.SelectedRows.Count == 0 && tabDog.SelectedIndex == 2) //21FEB 1157
            // tabDog.TabPages[tabDog.SelectedIndex].CausesValidation = true;
            //else 
            //{
            switch (tabDog.SelectedIndex)
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
                            tabDog.SelectedIndex = 0;
                            break;
                        }
                        else
                        {
                            lblEditDogNumber.Text = dogNoSelected.ToString();

                            drDog = dsInTheDogHouse.Tables["Dog"].Rows.Find(lblEditDogNumber.Text);

                            if (drDog["Gender"].ToString() == "M")
                                cmbEditGender.SelectedIndex = 0;
                            if (drDog["Gender"].ToString() == "F")
                                cmbEditGender.SelectedIndex = 1;

                            txtEditName.Text = drDog["Name"].ToString();
                            txtEditColour.Text = drDog["Colour"].ToString();

                            //drDog = dsInTheDogHouse.Tables["Breed"].NewRow(); //ADDED 20FEB

                            //cmbEditBreedNo.Text = drDog["BreedNo"].ToString();
                            //cmbEditGender.Text = drDog["Gender"].ToString();
                            //cmbEditCustNo.Text = drDog["CustomerNo"].ToString();

                            DataRow temp = dsInTheDogHouse.Tables["Breed"].Rows.Find(Convert.ToInt32(drDog["BreedNo"].ToString()));
                            cmbEditBreedNo.SelectedIndex = cmbEditBreedNo.FindStringExact(temp["BreedName"].ToString());

                            dtpEditDOB.Value = Convert.ToDateTime(drDog["DOB"].ToString());

                            temp = 
                                dsInTheDogHouse.Tables["Customer"].Rows.Find(Convert.ToInt32(drDog["CustomerNo"].ToString()));

                                    cmbEditCustNo.SelectedIndex =
                                cmbEditCustNo.FindStringExact(temp["CustomerNo"] + "(" + temp["Surname"] + "," + temp["Forename"] + ")");

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
            tabDog.TabPages[0].CausesValidation = true;
            tabDog.TabPages[0].Validating += new
                CancelEventHandler(AddTabValidate);

            tabDog.TabPages[0].CausesValidation = true;
            tabDog.TabPages[0].Validating += new
                CancelEventHandler(EditTabValidate);
        }

        private void btnEditEdit_Click(object sender, EventArgs e)
        {
            if (btnEditEdit.Text == "Edit")
            {
                lblEditDogNo.Enabled = true;
                txtEditName.Enabled = true;
                cmbEditBreedNo.Enabled = true;
                cmbEditGender.Enabled = true;
                txtEditColour.Enabled = true;
                cmbEditCustNo.Enabled = true;

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
                    myDog.BreedNo = Convert.ToInt32(cmbEditBreedNo.SelectedValue.ToString());
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditBreedNo, MyEx.toString());
                }

                try
                {
                    myDog.Dob = dtpEditDOB.Text.Trim(); //passed to Dog class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(dtpEditDOB, MyEx.toString());
                }

                try
                {
                    myDog.Gender = cmbEditGender.Text.Trim(); //passed to Dog class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditGender, MyEx.toString());
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
                    myDog.CustomerNo = Convert.ToInt32(cmbEditCustNo.Text.Substring(0, 5));
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditCustNo, MyEx.toString());
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
                        cmbEditBreedNo.Enabled = false;
                        cmbEditGender.Enabled = false;
                        txtEditColour.Enabled = false;
                        cmbEditCustNo.Enabled = false;

                        btnEditEdit.Text = "Edit"; //MAY NEED CHANGED FOR MY BUTTONS
                        tabDog.SelectedIndex = 0;

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
                foreach (DataRow dr in dsInTheDogHouse.Tables["Dog"].Rows)  //for each data row in this table..repeat
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
                    MessageBox.Show("Cannot delete this record - this dog has associated appointment records in the system.", "Denied!", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                tabDog.SelectedIndex = 0;
        }

        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tabDog.SelectedIndex = 1; //CHANGED FEB08 22:45 REVERTPOINT SB
        }
        private void btnDisplayEdit_Click(object sender, EventArgs e)
        {
            tabDog.SelectedIndex = 2;
        }
        private void dgvDog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDisplayExit_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the edit of Dog No: " + lblEditDogNumber.Text + "?", "Edit Dog", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabDog.SelectedIndex = 0;
        }
    }
}