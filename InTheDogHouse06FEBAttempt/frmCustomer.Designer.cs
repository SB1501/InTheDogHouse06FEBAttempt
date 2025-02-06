using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace InTheDogHouse06FEBAttempt
{
    public partial class frmCustomer : Form
    {
        //DECLARING VARIABLES
        SqlDataAdapter daCustomer;
        DataSet dsInTheDogHouse = new DataSet();
        SqlCommandBuilder cmdBCustomer;
        DataRow drCustomer;
        int selectedTab = 0;
        bool custSelected = false;
        int custNoSelected = 0;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder = @"Data Source = .; Initial Catalogue = InTheDogHouse; Integrated Security = true";

            sqlCustomer = @"select * from Customer";
            daCustomer = new SqlDataAdapter(sqlCustomer, SqlConnectionStringBuilder);
            cmbBCustomer = new SqlCommandBuilder(daCustomer);
            daCustomer.FillSchema(dsInTheDogHouse, SchemaType.Source, "Customer");
            daCustomer.Fill(dsInTheDogHouse, "Customer");

            dgvCustomer.DataSource = dsInTheDogHouse.Tables["Customer"];
            //Resize the DataGridView columns to fit the newly loaded content.

            dgvCustomer.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            tabCustomerDisplay.SelectedIndex = 1;
            tabCustomerDisplay.SelectedIndex = 0;



            ///////// Search Example /////////

            //sqlCustomerDetails = @"Select customerNo, title, surname, forename, street, town, county, postcode, telno, from customer where surname LIKE @Letter order by surname, forename";
            //conn = newSqlConnection(connStr);
            ////cmdCustonerDetails = new SqlCommand(sqlCustomerDetails, conn);
            /////cmdCustomerDetails.Parameters.Add("@Letter@, SqlDbType.Source, "Customers");
            ///
            //dgvCustomer.DataSource = dsInTheDogHouse.Tables["Customers"];

            dgvCustomer.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void btnAddAdd_Click(object sender, EventArgs e)
        {
            MyCustomer myCustomer = new MyCustomer();
            bool ok = true;
            errP.Clear();

            try
            {

                myCustomer.CustomerNo = Convert.ToInt32(lblCustomerAddCustNo.Text.Trim());
                //passed to CUstomer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblCustomerAddCustNo, MyEx.toString());
            }

            try
            {
                myCustomer.Title = cmbAddTitle.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddTitle, MyEx.toString());
            }

            try
            {
                myCustomer.Surname = txtCustomerAddSurname.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCustomerAddSurname, MyEx.toString());
            }

            try
            {
                myCustomer.Forename = txtCustomerAddForename.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCustomerAddForename, MyEx.toString());
            }

            try
            {
                myCustomer.Surname = txtCustomerAddSurname.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCustomerAddSurname, MyEx.toString());
            }

            try
            {
                myCustomer.Street = txtCustomerAddStreet.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCustomerAddStreet, MyEx.toString());
            }

            try
            {
                myCustomer.Town = txtCustomerAddTown.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCustomerAddTown, MyEx.toString());
            }

            try
            {
                myCustomer.County = txtCustomerAddCounty.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCustomerAddCounty, MyEx.toString());
            }

            try
            {
                myCustomer.Postcode = txtCustomerAddPostcode.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCustomerAddPostcode, MyEx.toString());
            }

            try
            {
                myCustomer.TelNo = txtCustomerAddTelNo.Text.Trim(); // passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCustomerAddTelNo, MyEx.toString());
            }

            try
            {
                if (ok)
                {
                    drCustomer = dsInTheDogHouse.Tables["Customer"].NewRow();
                    drCustomer["CustomerNo"] = myCustomer.CustomerNo;
                    drCustomer["Title"] = myCustomer.Title;
                    drCustomer["Forename"] = myCustomer.Forename;
                    drCustomer["Surname]"] = myCustomer.Surname;
                    drCustomer["Street"] = myCustomer.Street;
                    drCustomer["Town"] = myCustomer.Town;
                    drCustomer["County"] = myCustomer.County;
                    drCustomer["Postcode"] = myCustomer.Postcode;
                    drCustomer["TelNo"] = myCustomer.TelNo;

                    dsInTheDogHouse.Tables["Customer"].Rows.Add(drCustomer);
                    dsCustomer.Update(dsInTheDogHouse, "Customer");

                    MessageBox.Show("Customer Added");

                    if (MessageBox.Show("Do you wish to add another customer?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        clearAddForm();
                        getNumber(dsInTheDogHouse.Tables["Customer"].Rows.Count);
                    }
                    else
                        tabCustomerAdd.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
        void clear AddForm()
        {
            cboCustomerAddTitle.SelectedIndex = -1;
            txtCustomerAddForename.Clear();
            txtCustomerAddSurname.Clear();
            txtCustomerAddStreet.Clear();
            txtCustomerAddTown.Clear();
            txtCustomerAddCounty.Clear();
            txtCustomerAddPostcode.Clear();
            txtCustomerAddTelNo.Clear();
        }

        private void getNumber(int noRows)
        {
            drCustomer = dsInTheDogHouse.Tables["Customer"].Rows[noRows - 1];
            lblCustomerAddCustNo.Text = (int.Parse(drCustomer["CustomerNo"].ToString()) + 1).ToString();
        }

        private void tabCustomerDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTab = tabCustomerDisplay.SelectedIndex;

            tabCustomerDisplay.TabPages[tabCustomerDisplay.SelectedIndex].Focus();
            tabCustomerDisplay.TabPages[tabCustomerDisplay.SelectedIndex].CausesValidation = true;

            //if (dgvCustomer.SelectedRows.Count == 0 && tabCustomerDisplay.SelectedIndex == 2)
            // tabCustomerDisplay.TabPages[tabCustomers.SelectedIndex].CausesValidation = true;
            //else 
            //{
            switch (tabCustomerDisplay.SelectedIndex)
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
                            lblCustomerAddCustNo.Text = "10000";
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
                            tabCustomerAdd.SelectedIndex = 0;
                            break;
                        }
                        else
                        {
                            lblCustomerEditCustNo.Text = custNoSelected.ToString();

                            drCustomer = dsInTheDogHouse.Tables["Customer"].Rows.Find(lblCustomerEditCustNo.Text);

                            if (drCustomer["Title"].ToString() == "Mr")
                                cboCustomerEditTitle = 0;
                            if (drCustomer["Title"].ToString() == "Mrs")
                                cboCustomerEditTitle = 1;
                            if (drCustomer["Title"].ToString() == "Miss")
                                cboCustomerEditTitle = 2;
                            if (drCustomer["Title"].ToString() == "Ms")
                                cboCustomerEditTitle = 3;

                            txtCustomerEditForename.Text = drCustomer["Forename"].ToString();
                            txtCustomerEditSurname.Text = drCustomer["Surname"].ToString();
                            txtCustomerEditStreet.Text = drCustomer["Street"].ToString();
                            txtCustomerEditTown.Text = drCustomer["Town"].ToString();
                            txtCustomerEditCounty.Text = drCustomer["County"].ToString();
                            txtCustomerEditPostcode.Text = drCustomer["Postcode"].ToString();
                            txtCustomerEditTelNo.Text = drCustomer["TelNo"].ToString();

                            break;
                        }
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
                custtNoSelected = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells[0].Value);
                }
            }

        private void frmCustomer_Shown(object sender, EventArgs e)
        {
            tabCustomerDisplay.TabPages[0].CausesValidation = true;
            tabCustomerDisplay.TabPages[0].Validating += new
                CancelEventHandler(EditTabValidate);
            }

        private void btnEDEdit_Click(object sender, EventArgs e)
        {
            if (lblEdit.Text == "Edit")
            {
                cboEditTitle.Enabled = true;
                txtEditForename.Enabled = true;
                txtEditStreet.Enabled = true;
                txtEditTown.Enabled.= true;
                txtEditCounty.Enabled = true;
                txtEditPostcode.Enabled = true;
                txtEditTelNo.Enabled = true;

                lblEdit.Text = "Save" //might need changed bc button
            }
            else
            {
                MyCustomer myCustoner = new MyCustomer();
                bool ok = true;
                errP.Clear();

                try
                {
                    myCustomer.CustonerNo = Convert.ToInt32(lblEditCustNo.Text.Trim());
                    //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblEditCustNo, MyEx.toString());
                }
                try
                {
                    myCustomer.Title = cboCustomerEditTitle.Text.Trim(); //passed to Customer class to check 
                }
                catch
                {
                    ok = false;
                    errP.SetError(cboCustomerEditTitle, MyEx.toString());
                }

                try
                {
                    myCustomer.Surname = txtCustomerEditSurname.Text.Trim(); //passed to Customer class to check 
                }
                catch
                {
                    ok = false;
                    errP.SetError(txtCustomerEditSurname, MyEx.toString());
                }

                try
                {
                    myCustomer.Street = txtCustomerEditStreet.Text.Trim(); //passed to Customer class to check 
                }
                catch
                {
                    ok = false;
                    errP.SetError(txtCustomerEditStreet, MyEx.toString());
                }

                try
                {
                    myCustomer.Town = txtCustomerEditTown.Text.Trim(); //passed to Customer class to check 
                }
                catch
                {
                    ok = false;
                    errP.SetError(txtCustomerEditTown, MyEx.toString());
                }

                try
                {
                    myCustomer.County = txtCustomerEditCounty.Text.Trim(); //passed to Customer class to check 
                }
                catch
                {
                    ok = false;
                    errP.SetError(txtCustomerEditCounty, MyEx.toString());
                }

                try
                {
                    myCustomer.Postcode = txtCustomerEditPostcode.Text.Trim(); //passed to Customer class to check 
                }
                catch
                {
                    ok = false;
                    errP.SetError(txtCustomerEditPostcode, MyEx.toString());
                }

                try
                {
                    myCustomer.TelNo = txtCustomerEditTelNo.Text.Trim(); //passed to Customer class to check 
                }
                catch
                {
                    ok = false;
                    errP.SetError(txtCustomerEditTelNo, MyEx.toString());
                }

                try
                {
                    if (ok)
                    {
                        drCustomer.BeginEdit();

                        drCustomer["CustomerNo"] = myCustomer.CustomerNo;
                        drCustomer["Title"] = myCustomer.CustomerNo;
                        drCustomer["Forename"] = myCustomer.CustomerNo;
                        drCustomer["Surname"] = myCustomer.CustomerNo;
                        drCustomer["Street"] = myCustomer.CustomerNo;
                        drCustomer["Town"] = myCustomer.CustomerNo;
                        drCustomer["County"] = myCustomer.CustomerNo;
                        drCustomer["Postcode"] = myCustomer.CustomerNo;
                        drCustomer["TelNo"] = myCustomer.CustomerNo;

                        drCustomer.EndEdit();

                        daCustomer.Update(dsInTheDogHouse, "Customer");

                        MessageBox.Show("Customer Details Updated", "Customer");

                        cboCustomerEditTitle.Enabled = false;
                        txtCustomerEditForename.Enabled = false;
                        txtCustomerEditSurname.Enabled = false;
                        txtCustomerEditStreet.Enabled = false;
                        txtCustomerEditTown.Enabled = false;
                        txtCustomerEditCounty.Enabled = false;
                        txtCustomerEditPostcode.Enabled = false;
                        txtCustomerEditTelNo.Enabled = false;

                        lblEdit.Text = "Edit"; //MAY NEED CHANGED FOR MY BUTTONS
                        tabCustomerDisplay.SelectedIndex = 0;

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
                MessageBox.Show()("Please select a customer from the list.", "Select Customer")
            }
            else
            {
                drCustomer = dsInTheDogHouse.Tables["Customer"].Rows.Find(dgvCustomer.SelectedRows[0].Cells[0].Value);

                string tempName = drCustomer["Forename"].ToString() + "" + drCustomer["Surname"].ToString() + "\s";

               if () MesageBox.Show("Are you sure you want to delete" + tempName + @ details?", "Add customer@, MessageBoxButtons.YesNo == System.Windows.Forms.DialogResult.Yes)
                        {
                    drCustomer.Delete();
                    daCustomer.Update(dsInTheDogHouse, "Customer");
                }
            }
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition of Customer No: " + lblAddCustNo.Text + "?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabCustomerDisplay.SelectedIndex = 0;
        }

        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tabCustomerDisplay.SelectedIndex = 0;
        }

        private void btnDisplayEdit_Click(object sender, EventArgs e)
        {
            tabCustomerDisplay.SelectedIndex = 1;
        }
        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tabCustomerDisplay.SelectedIndex = 2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (MesageBox.Show("Cancel the edit of Customer No: " + lblEditCustNo.Text + "?", "Edit Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResults.Yes)
                tabCustomerDisplay.SelecteDIndex = 0;
        }
    }
}
