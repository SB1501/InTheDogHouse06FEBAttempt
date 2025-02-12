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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace InTheDogHouse06FEBAttempt
{
    public partial class frmCustomer : Form
    {

        private System.Windows.Forms.ErrorProvider errP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Button btnDisplayAdd;
        private System.Windows.Forms.Button btnDisplayEdit;
        private System.Windows.Forms.Button btnDisplayDelete;
        private System.Windows.Forms.Button btnDisplayExit;
        private System.Windows.Forms.Label lblAddCustNo;
        private System.Windows.Forms.Label lblAddTitle;
        private System.Windows.Forms.Label lblAddSurname;
        private System.Windows.Forms.Label lblAddForename;
        private System.Windows.Forms.Label lblAddStreet;
        private System.Windows.Forms.Label lblAddTown;
        private System.Windows.Forms.Label lblAddCounty;
        private System.Windows.Forms.Label lblAddPostcode;
        private System.Windows.Forms.Label lblAddTelNo;
        private System.Windows.Forms.Label lblAddCustomerNumber;
        private System.Windows.Forms.ComboBox cboAddTitle;
        private System.Windows.Forms.TextBox txtAddSurname;
        private System.Windows.Forms.TextBox txtAddForename;
        private System.Windows.Forms.TextBox txtAddStreet;
        private System.Windows.Forms.TextBox txtAddTown;
        private System.Windows.Forms.TextBox txtAddCounty;
        private System.Windows.Forms.TextBox txtAddPostcode;
        private System.Windows.Forms.TextBox txtAddTelNo;
        private System.Windows.Forms.Button btnAddCancel;
        private System.Windows.Forms.Button btnAddAdd;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnEditEdit;
        private System.Windows.Forms.TextBox txtEditTelNo;
        private System.Windows.Forms.TextBox txtEditPostcode;
        private System.Windows.Forms.TextBox txtEditCounty;
        private System.Windows.Forms.TextBox txtEditTown;
        private System.Windows.Forms.TextBox txtEditStreet;
        private System.Windows.Forms.TextBox txtEditForename;
        private System.Windows.Forms.TextBox txtEditSurname;
        private System.Windows.Forms.ComboBox cboEditTitle;
        private System.Windows.Forms.Label lblEditCustNo;
        private System.Windows.Forms.Label lblEditTelNo;
        private System.Windows.Forms.Label lblEditPostcode;
        private System.Windows.Forms.Label lblEditCounty;
        private System.Windows.Forms.Label lblEditTown;
        private System.Windows.Forms.Label lblEditStreet;
        private System.Windows.Forms.Label lblEditForename;
        private System.Windows.Forms.Label lblEditSurname;
        private System.Windows.Forms.Label lblEditTitle;
                    
            
        //DECLARING VARIABLES
            SqlDataAdapter daCustomer;
            DataSet dsInTheDogHouse = new DataSet();
            SqlCommandBuilder cmdBCustomer;
            DataRow drCustomer;
            String connStr, sqlCustomer;
            int selectedTab = 0;
            bool custSelected = false;
            int custNoSelected = 0;

        public frmCustomer()
        {
            InitializeComponent();
        }
        

        private void frmCustomer_Load(object sender, EventArgs e)
        {                                           //UPDATE PIPE IF CONNECTION ISSUE OCCURS
            string SqlConnectionStringBuilder = @"Data Source =np:\\.\pipe\LOCALDB#5E9E478C\tsql\query;Initial Catalog = InTheDogHouse; Integrated Security = true";

            string sqlCustomer = @"SELECT * FROM Customer";
            daCustomer = new SqlDataAdapter(sqlCustomer, SqlConnectionStringBuilder);
            cmdBCustomer = new SqlCommandBuilder(daCustomer);
            daCustomer.FillSchema(dsInTheDogHouse, SchemaType.Source, "Customer");
            daCustomer.Fill(dsInTheDogHouse, "Customer");

            dgvCustomer.DataSource = dsInTheDogHouse.Tables["Customer"];
            //Resize the DataGridView columns to fit the newly loaded content.

            dgvCustomer.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            tabControl.SelectedIndex = 1;
            tabControl.SelectedIndex = 0;

            ///////// Search Example /////////

            //sqlCustomerDetails = @"Select customerNo, title, surname, forename, street, town, county, postcode, telno, from customer where surname LIKE @Letter order by surname, forename";
            //conn = newSqlConnection(connStr);
            ////cmdCustonerDetails = new SqlCommand(sqlCustomerDetails, conn);
            /////cmdCustomerDetails.Parameters.Add("@Letter@, SqlDbType.Source, "Customers");
            ///
            //dgvCustomer.DataSource = dsInTheDogHouse.Tables["Customers"];

            dgvCustomer.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void lblAddCustNo_Click(object sender, EventArgs e)
        {

        }

        private void cboAddTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddAdd_Click(object sender, EventArgs e)
        {
            MyCustomer myCustomer = new MyCustomer();
            bool ok = true;
            errP.Clear();

            try
            {

                myCustomer.CustomerNo = Convert.ToInt32(lblAddCustomerNumber.Text.Trim());
                //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblAddCustomerNumber, MyEx.toString());
            }

            try
            {
                myCustomer.Title = cboAddTitle.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cboAddTitle, MyEx.toString());
            }

            try
            {
                myCustomer.Surname = txtAddSurname.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddSurname, MyEx.toString());
            }

            try
            {
                myCustomer.Forename = txtAddForename.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddForename, MyEx.toString());
            }

            try
            {
                myCustomer.Surname = txtAddSurname.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddSurname, MyEx.toString());
            }

            try
            {
                myCustomer.Street = txtAddStreet.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddStreet, MyEx.toString());
            }

            try
            {
                myCustomer.Town = txtAddTown.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddTown, MyEx.toString());
            }

            try
            {
                myCustomer.County = txtAddCounty.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddCounty, MyEx.toString());
            }

            try
            {
                myCustomer.Postcode = txtAddPostcode.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddPostcode, MyEx.toString());
            }

            try
            {
                myCustomer.TelNo = txtAddTelNo.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddTelNo, MyEx.toString());
            }

            try
            {
                if (ok)
                {
                    drCustomer = dsInTheDogHouse.Tables["Customer"].NewRow();
                    drCustomer["CustomerNo"] = myCustomer.CustomerNo;
                    drCustomer["Title"] = myCustomer.Title;
                    drCustomer["Forename"] = myCustomer.Forename;
                    drCustomer["Surname"] = myCustomer.Surname;
                    drCustomer["Street"] = myCustomer.Street;
                    drCustomer["Town"] = myCustomer.Town;
                    drCustomer["County"] = myCustomer.County;
                    drCustomer["Postcode"] = myCustomer.Postcode;
                    drCustomer["TelNo"] = myCustomer.TelNo;

                    dsInTheDogHouse.Tables["Customer"].Rows.Add(drCustomer);
                    daCustomer.Update(dsInTheDogHouse, "Customer");

                    MessageBox.Show("Customer Added");

                    if (MessageBox.Show("Do you wish to add another customer?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        clearAddForm();
                        getNumber(dsInTheDogHouse.Tables["Customer"].Rows.Count);
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
            cboAddTitle.SelectedIndex = -1;
            txtAddForename.Clear();
            txtAddSurname.Clear();
            txtAddStreet.Clear();
            txtAddTown.Clear();
            txtAddCounty.Clear();
            txtAddPostcode.Clear();
            txtAddTelNo.Clear();
        }

        private void getNumber(int noRows)
        {
            drCustomer = dsInTheDogHouse.Tables["Customer"].Rows[noRows - 1];
            lblAddCustomerNumber.Text = (int.Parse(drCustomer["CustomerNo"].ToString()) + 1).ToString();
        }       //CHANGED 08FEB 22:12 REVERTPOINTSB

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {   //CHANGED 08FEB 22:13 REVERTPOINTSB
            selectedTab = tabControl.SelectedIndex;

            tabControl.TabPages[tabControl.SelectedIndex].Focus();
            tabControl.TabPages[tabControl.SelectedIndex].CausesValidation = true;

            //if (dgvCustomer.SelectedRows.Count == 0 && tabCustomerDisplay.SelectedIndex == 2)
            // tabCustomerDisplay.TabPages[tabCustomers.SelectedIndex].CausesValidation = true;
            //else 
            //{
            switch (tabControl.SelectedIndex)
            {
                case 0: //Display tab selected
                    {
                        dsInTheDogHouse.Tables["Customer"].Clear();
                        daCustomer.Fill(dsInTheDogHouse, "Customer");
                        break;
                    }

                case 1: //Add tab selected
                    {
                        int noRows = dsInTheDogHouse.Tables["Customer"].Rows.Count;

                        if (noRows == 0)
                            lblAddCustomerNumber.Text = "10000";
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
                        if (custNoSelected == 0)
                        {
                            tabControl.SelectedIndex = 0;
                            break;
                        }
                        else
                        {
                            lblEditCustomerNumber.Text = custNoSelected.ToString();

                            drCustomer = dsInTheDogHouse.Tables["Customer"].Rows.Find(lblEditCustomerNumber.Text);

                            if (drCustomer["Title"].ToString() == "Mr")
                                cboEditTitle.SelectedIndex = 0;
                            if (drCustomer["Title"].ToString() == "Mrs")
                                cboEditTitle.SelectedIndex = 1;
                            if (drCustomer["Title"].ToString() == "Miss")
                                cboEditTitle.SelectedIndex = 2;
                            if (drCustomer["Title"].ToString() == "Ms")
                                cboEditTitle.SelectedIndex = 3;

                            txtEditForename.Text = drCustomer["Forename"].ToString();
                            txtEditSurname.Text = drCustomer["Surname"].ToString();
                            txtEditStreet.Text = drCustomer["Street"].ToString();
                            txtEditTown.Text = drCustomer["Town"].ToString();
                            txtEditCounty.Text = drCustomer["County"].ToString();
                            txtEditPostcode.Text = drCustomer["Postcode"].ToString();
                            txtEditTelNo.Text = drCustomer["TelNo"].ToString();

                            break;
                        }
                    }
            }
        }
    

    void AddTabValidate(object sender, CancelEventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 0)
            {
                custSelected = false;
                custNoSelected = 0;
            }
            else if (dgvCustomer.SelectedRows.Count == 1)
            {
                custSelected = true;
                custNoSelected =
                    Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells[0].Value);
            }
        }

        void EditTabValidate(object sender, CancelEventArgs e)
        {
            if (custSelected == false && custNoSelected == 0)
            //have to do this bit here//////
            //reset tab to display and put out message to select a customer
            {
                custSelected = false;
                custNoSelected = 0;
            }
            else if (dgvCustomer.SelectedRows.Count == 1)
            {
                custSelected = true;
                custNoSelected = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells[0].Value);
            }
        }

        private void frmCustomer_Shown(object sender, EventArgs e)
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
                cboEditTitle.Enabled = true;
                txtEditForename.Enabled = true;
                txtEditSurname.Enabled = true;
                txtEditStreet.Enabled = true;
                txtEditTown.Enabled = true;
                txtEditCounty.Enabled = true;
                txtEditPostcode.Enabled = true;
                txtEditTelNo.Enabled = true;

                btnEditEdit.Text = "Save"; //different bc i have a button not a button and separate label as in example code
            }
            else
            {
                MyCustomer myCustomer = new MyCustomer();
                bool ok = true;
                errP.Clear();

                try
                {
                    myCustomer.CustomerNo = Convert.ToInt32(lblEditCustomerNumber.Text.Trim());
                    //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblEditCustNo, MyEx.toString());
                }
                try
                {
                    myCustomer.Title = cboEditTitle.Text.Trim(); //passed to Customer class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cboEditTitle, MyEx.toString());
                }

                try
                {
                    myCustomer.Surname = txtEditSurname.Text.Trim(); //passed to Customer class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditSurname, MyEx.toString());
                }

                try
                {
                    myCustomer.Forename = txtEditForename.Text.Trim(); //passed to Customer class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditForename, MyEx.toString());
                }

                try
                {
                    myCustomer.Street = txtEditStreet.Text.Trim(); //passed to Customer class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditStreet, MyEx.toString());
                }

                try
                {
                    myCustomer.Town = txtEditTown.Text.Trim(); //passed to Customer class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditTown, MyEx.toString());
                }

                try
                {
                    myCustomer.County = txtEditCounty.Text.Trim(); //passed to Customer class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditCounty, MyEx.toString());
                }

                try
                {
                    myCustomer.Postcode = txtEditPostcode.Text.Trim(); //passed to Customer class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditPostcode, MyEx.toString());
                }

                try
                {
                    myCustomer.TelNo = txtEditTelNo.Text.Trim(); //passed to Customer class to check 
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditTelNo, MyEx.toString());
                }

                try
                {
                    if (ok)
                    {
                        drCustomer.BeginEdit();

                        drCustomer["CustomerNo"] = myCustomer.CustomerNo;
                        drCustomer["Title"] = myCustomer.Title;
                        drCustomer["Forename"] = myCustomer.Forename;
                        drCustomer["Surname"] = myCustomer.Surname;
                        drCustomer["Street"] = myCustomer.Street;
                        drCustomer["Town"] = myCustomer.Town;
                        drCustomer["County"] = myCustomer.County;
                        drCustomer["Postcode"] = myCustomer.Postcode;
                        drCustomer["TelNo"] = myCustomer.TelNo;

                        drCustomer.EndEdit();

                        daCustomer.Update(dsInTheDogHouse, "Customer");

                        MessageBox.Show("Customer Details Updated", "Customer");

                        cboEditTitle.Enabled = false;
                        txtEditForename.Enabled = false;
                        txtEditSurname.Enabled = false;
                        txtEditStreet.Enabled = false;
                        txtEditTown.Enabled = false;
                        txtEditCounty.Enabled = false;
                        txtEditPostcode.Enabled = false;
                        txtEditTelNo.Enabled = false;

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

        private void btnDisplayDelete_Click(object sender, EventArgs e)
        {
            //if (lstCustomer.SelectedIndices.Count == 0)
            if (dgvCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer from the list.", "Select Customer");
            }
            else
            {
                drCustomer = 
             dsInTheDogHouse.Tables["Customer"].Rows.Find(dgvCustomer.SelectedRows[0].Cells[0].Value);

                string tempName = drCustomer["Forename"].ToString() + " " + drCustomer["Surname"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete" + tempName + " details?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                    drCustomer.Delete();
                    daCustomer.Update(dsInTheDogHouse, "Customer");
                }
            }
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition of Customer No: " + lblAddCustomerNumber.Text + "?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabControl.SelectedIndex = 0;
        }

        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1; //CHANGED FEB08 22:45 REVERTPOINT SB
        }

        private void btnDisplayEdit_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDisplayExit_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form
        }

        private void lblAddCustomerNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the edit of Customer No: " + lblEditCustomerNumber.Text + "?", "Edit Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabControl.SelectedIndex = 0;
        }
    }
}

