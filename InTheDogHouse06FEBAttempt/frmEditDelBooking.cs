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

namespace InTheDogHouse06FEBAttempt
{
    public partial class frmEditDelBooking : Form
    {
        Button[] btns = new Button[26]; //array of buttons for customer surname picker

        SqlDataAdapter daNames, daCustomers, daBooking, daBooking2, daBookingDet, daBookingDet2, daDogs, daKennels; //data adapters for each table
        DataSet dsInTheDogHouse = new DataSet();
        SqlConnection conn;
        SqlCommand cmdBooking, cmdBookingDet, cmdCustomerDetails, cmdKennelDetails, cmdDogDetails;
        SqlCommandBuilder cmdBBooking2, cmdBBookingDet2;
        DataRow drCustomer;

        String sqlNames, sqlCustomerDetails, sqlBooking, sqlBooking2, sqlBookingDet, sqlBookingDet2;
        String sqlDogDetails, sqlKennelDetails, connStr;
        
        public frmEditDelBooking()
        {
            InitializeComponent();
        }

        private void frmEditDelBooking_Load(object sender, EventArgs e)
        {
            int no;

            //lblBookingDate.Text = DateTime.Now.ToShortDateString();
            //dtpStartDate.MinDate = DateTime.Now;

            // Reverse the order of controls, if necessary
            var controls = pnlButtons.Controls.Cast<Control>().OrderBy(c => c.TabIndex).ToArray();

            for (int i = 0; i < 26; i++)
            {
                btns[i] = (Button)controls[i]; // Access the reversed order of controls
                btns[i].Text = "" + (char)(65 + i); // A to Z
                btns[i].Enabled = false;
                btns[i].Click += new EventHandler(button1_Click);
            }

            //FILL IN PIPE HERE 
            connStr = @"Data Source = np:\\.\pipe\LOCALDB#58361F88\tsql\query; Initial Catalog = InTheDogHouse; Integrated Security = true";
            //connStr = Properties.Resources.connectionStr;

            //get surnames for alphabet buttons
            sqlNames = @"SELECT surname FROM customer ORDER BY surname";
            daNames = new SqlDataAdapter(sqlNames, connStr);
            daNames.Fill(dsInTheDogHouse, "Names");

            //enable relevant alphabet buttons
            foreach (DataRow dr in dsInTheDogHouse.Tables["Names"].Rows)
            {
                no = (int)dr["Surname"].ToString()[0] - 65;
                btns[no].Enabled = true;
                btns[no].BackColor = Color.Black;
                btns[no].ForeColor = Color.White;
            }

            //DATA ADAPTER - Customer Details - LIST BOX lstCustomer TOP LEFT//
            sqlCustomerDetails = @"SELECT customerNo, title, surname, forename, surname +', ' + Forename AS name, street, town , county, postcode, telno FROM customer WHERE surname LIKE @Letter ORDER BY surname, forename ";
            conn = new SqlConnection(connStr);
            cmdCustomerDetails = new SqlCommand(sqlCustomerDetails, conn);
            cmdCustomerDetails.Parameters.Add("@Letter", SqlDbType.VarChar);
            daCustomers = new SqlDataAdapter(cmdCustomerDetails);
            daCustomers.FillSchema(dsInTheDogHouse, SchemaType.Source, "Customer");

                                                            //DATA ADAPTER - Bookings - LIST BOX lstBooking TOP RIGHT //
                                                            sqlBooking = @"SELECT * FROM Booking WHERE customerNo LIKE @CustNo ORDER BY BookingNo";
                                                            daBooking = new SqlDataAdapter(sqlBooking, conn);
                                                            cmdBooking = new SqlCommand(sqlBooking, conn);
                                                            cmdBooking.Parameters.Add("@CustNo", SqlDbType.Int);
                                                            daBooking = new SqlDataAdapter(cmdBooking);
                                                            daBooking.FillSchema(dsInTheDogHouse, SchemaType.Source, "Booking");

            //SIMPLE DATA SET WITH NO PARAMETERS - for Delete Booking Function //
            sqlBooking2 = @"SELECT * FROM Booking";
            daBooking2 = new SqlDataAdapter(sqlBooking2, conn);
            cmdBBooking2 = new SqlCommandBuilder(daBooking2);
            daBooking2.FillSchema(dsInTheDogHouse, SchemaType.Source, "Booking2");
            daBooking2.Fill(dsInTheDogHouse, "Booking2");

            //DATA ADAPTER - Bookings - LIST /VIEW/ lvwBooking BOTTOM LEFT //
            sqlBookingDet = @"SELECT * FROM bookingDetail WHERE BookingNo LIKE @BookingNo ORDER BY DogNo";
            daBookingDet = new SqlDataAdapter(sqlBookingDet, conn);
            cmdBookingDet = new SqlCommand(sqlBookingDet, conn);
            cmdBookingDet.Parameters.Add("@BookingNo", SqlDbType.Int);
            daBookingDet = new SqlDataAdapter(cmdBookingDet);
            daBookingDet.FillSchema(dsInTheDogHouse, SchemaType.Source, "BookingDet");

            //SIMPLE DATA SET WITH NO PARAMETERS - for Delete Booking Function //
            sqlBookingDet2 = @"SELECT * FROM bookingDetail";
            daBookingDet2 = new SqlDataAdapter(sqlBookingDet2, conn);
            cmdBBookingDet2 = new SqlCommandBuilder(daBookingDet2);
            daBookingDet2.FillSchema(dsInTheDogHouse, SchemaType.Source, "BookingDet2");
            daBookingDet2.Fill(dsInTheDogHouse, "BookingDet2");

            //DATA ADAPTER - Dog Details - LIST BOX lstDog LOWER CENTER //
            sqlDogDetails = @"SELECT dogNo, name, breedNo, dob, gender, colour, customerNo FROM dog WHERE customerNo LIKE @CustNo ORDER BY dogNo";
            cmdDogDetails = new SqlCommand(sqlDogDetails, conn);
            cmdDogDetails.Parameters.Add("@CustNo", SqlDbType.Int);
            daDogs = new SqlDataAdapter(cmdDogDetails);
            daDogs.FillSchema(dsInTheDogHouse, SchemaType.Source, "Dog");

            //DATA ADAPTER - Kennel Details - LIST BOX lstKennel BOTTOM CENTER//
            sqlKennelDetails = @"SELECT distinct kennelNo, sizeK, sizeNo, sizeB, dog.breedNo, chargePerDay FROM kennel JOIN size ON sizeK = sizeNo JOIN breed ON sizeNo = sizeB JOIN dog ON dog.breedNo = breed.breedNo WHERE dog.breedNo = @BreedNo ORDER BY kennelNo";
            cmdKennelDetails = new SqlCommand(sqlKennelDetails, conn);
            cmdKennelDetails.Parameters.Add("@BreedNo", SqlDbType.Int);
            daKennels = new SqlDataAdapter(cmdKennelDetails);
            daKennels.FillSchema(dsInTheDogHouse, SchemaType.Source, "Kennel");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            //get customer details for listbox - use selected button letter for parameter
            String str = b.Text;

            //empty dataset table customer 
            dsInTheDogHouse.Tables["Customer"].Clear();

            fillListboxCustomers(str);

            //clear any previously selected dogs/kennels by emptying the dataset tables
            dsInTheDogHouse.Tables["Booking"].Clear();
            dsInTheDogHouse.Tables["Kennel"].Clear();

            ClearCustomer();
            //pnlAddEdit.Enabled = true;
        }

        private void fillListboxCustomers(String str)
        {
            //enable after alphabet button pressed
            lstCustomer.Enabled = true; //CHECK IF STILL APPLICABLE TO THIS FORM SB

            //get all customer details for listbox - use wildcard for parameter
            cmdCustomerDetails.Parameters["@Letter"].Value = str + "%";
            daCustomers.Fill(dsInTheDogHouse, "Customer");

            //fill listbox
            lstCustomer.DataSource = dsInTheDogHouse.Tables["Customer"];
            lstCustomer.DisplayMember = "name";
            lstCustomer.ValueMember = "CustomerNo";

            //enable lstDog for next step
            lstBooking.Enabled = true;
        }

        private void ClearCustomer()
        {
            lstCustomer.SelectedIndex = -1;

            lblCust0.Text = "";
            lblCust1.Text = "";
            lblCust2.Text = "";
            lblCust3.Text = "";
            lblCust4.Text = "";
            lblCust5.Text = "";
        }

        private void lstCustomer_Click(object sender, EventArgs e) //CHECK IF MY CHANGES APPLY HERE FOR THIS FORM
        {
            String title = "";

            PopulateBookingListbox();

            lstBooking.SelectedIndex = -1;

            drCustomer = 
                dsInTheDogHouse.Tables["Customer"].Rows.Find(lstCustomer.SelectedValue);

            if (drCustomer["Title"].ToString() == "Mr")
                title = "Mr";
            if (drCustomer["Title"].ToString() == "Mrs")
                title = "Mrs";
            if (drCustomer["Title"].ToString() == "Miss")
                title = "Miss";
            if (drCustomer["Title"].ToString() == "Ms")
                title = "Ms";

            lblCust0.Text = drCustomer["CustomerNo"].ToString();
            lblCust1.Text = title + " " + drCustomer["Forename"].ToString() + " " + drCustomer["Surname"].ToString();
            lblCust2.Text = drCustomer["Street"].ToString();
            lblCust3.Text = drCustomer["Town"].ToString();
            lblCust4.Text = drCustomer["County"].ToString();
            lblCust5.Text = drCustomer["Postcode"].ToString();

            PopulateDogListview();

            lstDog.SelectedIndex = -1;

            // clear booking list view when another customer is selected - CHECK IF STILL NEEDED SB
            ClearBooking();

            // clear kennel as each customer is selected to prevent different customer dogs in same bookings
            //ClearKennel();
        }

        private void lstBooking_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            cmbNoOfDays.Enabled = true;
            lvwBooking.Enabled = true;

            lvwBooking.Items.Clear();
            lblBookingDate.Text = string.Empty; // Clear the label text MAY NEED REMOVED
            dtpStartDate.Value = DateTime.Now; // Reset the DateTimePicker to the current date
            cmbNoOfDays.SelectedIndex = -1;

            if (lstBooking.Items.Count != 0)
            {
                DataRow drBooking =
                    dsInTheDogHouse.Tables["Booking"].Rows.Find(lstBooking.SelectedValue);

                lblBookingDate.Text =
                    (Convert.ToDateTime(drBooking["DateBooked"].ToString())).ToShortDateString();
                dtpStartDate.Value =
                    Convert.ToDateTime(drBooking["DateStart"].ToString());
                cmbNoOfDays.Text = drBooking["NoDays"].ToString();

                if (dtpStartDate.Value < DateTime.Now)
                {
                    dtpStartDate.Enabled = false;
                    cmbNoOfDays.Enabled = false;
                    lvwBooking.Enabled = false;
                }

                //enable pnlAddEdit for next steps
                //pnlAddEdit.Enabled = true; 
                //empty dataset table Kennel
                dsInTheDogHouse.Tables["BookingDet"].Clear();

                //get all kennel details for listbox
                cmdBookingDet.Parameters["@BookingNo"].Value = lstBooking.SelectedValue;

                daBookingDet.Fill(dsInTheDogHouse, "BookingDet");

                //fill listview
                foreach (DataRow dr in dsInTheDogHouse.Tables["BookingDet"].Rows)
                {
                    if (dr["BookingNo"].ToString() == lstBooking.Text)  //CAN THIS BE DOT TEXT???
                    {
                        ListViewItem item = new ListViewItem(dr["DogNo"].ToString());
                        item.SubItems.Add(dr["KennelNo"].ToString());
                        lvwBooking.Items.Add(item);
                    }
                }
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lvwBooking.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the booking details for Dog No: " + lvwBooking.SelectedItems[0].SubItems[0].Text + "?", "Delete Dog Details", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    object[] primaryKey = new object[2];

                    ListViewItem currItem = lvwBooking.SelectedItems[0];

                    primaryKey[0] = Convert.ToInt32(lstBooking.Text);
                    primaryKey[1] = Convert.ToInt32(currItem.SubItems[0].Text);

                    DataRow drBookingDet =
                        dsInTheDogHouse.Tables["BookingDet2"].Rows.Find(primaryKey);

                    lvwBooking.Items.Remove(currItem);

                    drBookingDet.Delete();
                    daBookingDet2.Update(dsInTheDogHouse, "BooingDet2");

                    if(lvwBooking.Items.Count == 0)
                    {
                        MessageBox.Show("As there are no booking details, Booking No " + primaryKey[0].ToString() + " will now be deleted.");

                        DataRow drBooking =
                            dsInTheDogHouse.Tables["Booking2"].Rows.Find(primaryKey[0]);
                        drBooking.Delete();
                        daBooking2.Update(dsInTheDogHouse, "Booking2");

                        PopulateBookingListbox();
                    }
                }
            }
        }

        private void PopulateBookingListbox()
        {
            dsInTheDogHouse.Tables["Booking"].Clear();

            //get all dog details for listbox
            cmdBooking.Parameters["@CustNo"].Value = lstCustomer.SelectedValue;

            daBooking.Fill(dsInTheDogHouse, "Booking");

            //fill listbox
            lstBooking.DataSource = dsInTheDogHouse.Tables["Booking"];
            lstBooking.DisplayMember = "BookingNo";
            lstBooking.ValueMember = "BookingNo";
        }

        private void PopulateDogListview()
        {
            dsInTheDogHouse.Tables["Dog"].Clear();

            //get all dog details for listbox
            cmdDogDetails.Parameters["@CustNo"].Value = lstCustomer.SelectedValue;

            daDogs.Fill(dsInTheDogHouse, "Dog");

            //fill listbox
            lstDog.DataSource = dsInTheDogHouse.Tables["Dog"];
            lstDog.DisplayMember = "DogNo";
            lstDog.ValueMember = "BreedNo";
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (lstBooking.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to delete Booking No: " +
                    lstBooking.Text + "?", "Delete Booking", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] primaryKey = new object[2];

                    foreach (ListViewItem item in lvwBooking.Items)
                    {
                        primaryKey[0] = Convert.ToInt32(lstBooking.Text);
                        primaryKey[1] = Convert.ToInt32(item.SubItems[0].Text);

                        DataRow drBookingDet =
                            dsInTheDogHouse.Tables["BookingDet2"].Rows.Find(primaryKey);
                        lvwBooking.Items.Remove(item);

                        drBookingDet.Delete();
                        daBookingDet2.Update(dsInTheDogHouse, "BookingDet2");
                    }

                    if (lvwBooking.Items.Count == 0)
                    {
                        DataRow drBooking =
                            dsInTheDogHouse.Tables["Booking2"].Rows.Find(primaryKey[0]);

                        drBooking.Delete();
                        daBooking2.Update(dsInTheDogHouse, "Booking2");

                        PopulateBookingListbox();
                    }
                }
            }
            else    
                MessageBox.Show("Please select a booking from the list!", "Delete Booking");            
        }

     private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (btnAddItem.Text == "Add Item")
            {
                pnlAddEdit.Enabled = true;
                btnAddItem.Text = "Save";

                btnEditItem.Enabled = false;
                btnDeleteItem.Enabled = false;
                btnEditBooking.Enabled = false;
                btnDeleteBooking.Enabled = false;

            }
            else
            {
                pnlAddEdit.Enabled = false;
                btnAddItem.Text = "Add Item";

                btnEditItem.Enabled = true;
                btnDeleteItem.Enabled = true;
                btnEditBooking.Enabled = true;
                btnDeleteBooking.Enabled = true;
            }
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value >= DateTime.Now)
            {
                if(btnEditBooking.Text == "Edit Booking")
                {
                    pnlEditBooking.Enabled = true;
                    btnEditBooking.Text = "Save";

                    btnAddItem.Enabled = false;
                    btnEditItem.Enabled = false;
                    btnDeleteItem.Enabled = false;
                    btnDeleteBooking.Enabled = false;
                }
                else
                {
                    DataRow drBooking =
                        dsInTheDogHouse.Tables["Booking2"].Rows.Find(Convert.ToInt32(lstBooking.Text));

                    drBooking.BeginEdit();

                    drBooking["DateStart"] = Convert.ToDateTime(dtpStartDate.Value);
                    drBooking["NoDays"] = Convert.ToInt32(cmbNoOfDays.Text);

                    drBooking.EndEdit();
                    daBooking2.Update(dsInTheDogHouse, "Booking2");

                    pnlEditBooking.Enabled = false;
                    btnEditBooking.Text = "Edit Booking";

                    btnAddItem.Enabled = true;
                    btnEditItem.Enabled = true;
                    btnDeleteItem.Enabled = true;
                    btnDeleteBooking.Enabled = true;
                }
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            pnlAddEdit.Enabled = true;
        }
          
        private void lstDog_Click(object sender, EventArgs e) //CHECK IF STILL APPLICABLE TO THIS FORM SB
        {
           
                //empty dataset table Kennel
                dsInTheDogHouse.Tables["Kennel"].Clear();

                //get all kennel details for listbox 
                cmdKennelDetails.Parameters["@BreedNo"].Value = 
                Convert.ToInt32(lstDog.SelectedValue);

                daKennels.Fill(dsInTheDogHouse, "Kennel");

                //fill listbox
                lstKennel.DataSource = dsInTheDogHouse.Tables["Kennel"];
                lstKennel.DisplayMember = "KennelNo";
                lstKennel.ValueMember = "KennelNo";

            lstKennel.SelectedIndex = -1;        

        } 
       

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (lvwBooking.SelectedItems.Count != 0)
            {
                var item = lvwBooking.SelectedItems[0];
                lvwBooking.Items.Remove(item);
            }
        }

 
        private void ClearBooking()
        {
            lvwBooking.Items.Clear();
        }

        private void ClearKennel()
        {
            lstBooking.DataSource = null;
            lstBooking.Items.Clear();
        }


    }
}
