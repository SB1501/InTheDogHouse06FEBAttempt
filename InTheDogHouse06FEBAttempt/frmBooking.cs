using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics.Eventing.Reader;

namespace InTheDogHouse06FEBAttempt
{
    public partial class frmBooking : Form
    {
        Button[] btns = new Button[26]; //array of buttons for customer surname picker

        SqlDataAdapter daNames, daCustomers, daDogs, daKennels, daBooking, daBookingDet, daBookedKennels; //data adapters for each table
        DataSet dsInTheDogHouse = new DataSet();
        SqlConnection conn;
        SqlCommand cmdCustomerDetails, cmdDogDetails, cmdKennelDetails;
        SqlCommandBuilder cmdBBooking, cmdBBookingDet, cmdBBookedKennels;
        DataRow drCustomer;

        String sqlNames, sqlCustomerDetails, sqlDogDetails, sqlKennelDetails, sqlBooking, sqlBookingDet, sqlBookedKennels;
        String connStr;

        public frmBooking()
        {
            InitializeComponent();
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            int no;

            lblBookingDate.Text = DateTime.Now.ToShortDateString();
            dtpStartDate.MinDate = DateTime.Now;

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
            connStr = @"Data Source = np:\\.\pipe\LOCALDB#E1E211DF\tsql\query; Initial Catalog = InTheDogHouse; Integrated Security = true";
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

            //set up dataAdapter for customer details for the listbox
            sqlCustomerDetails = @"SELECT customerNo, title, surname, forename, surname +', ' + Forename AS name, street, town , county, postcode, telno FROM customer WHERE surname LIKE @Letter ORDER BY surname, forename";
            conn = new SqlConnection(connStr);
            cmdCustomerDetails = new SqlCommand(sqlCustomerDetails, conn);
            cmdCustomerDetails.Parameters.Add("@Letter", SqlDbType.VarChar);
            daCustomers = new SqlDataAdapter(cmdCustomerDetails);
            daCustomers.FillSchema(dsInTheDogHouse, SchemaType.Source, "Customer");

            //set up dataAdapter for dog details for the listbox
            sqlDogDetails = @"SELECT dogNo, name, breedNo, dob, gender, colour, customerNo FROM dog WHERE customerNo LIKE @CustNo ORDER BY dogNo";
            cmdDogDetails = new SqlCommand(sqlDogDetails, conn);
            cmdDogDetails.Parameters.Add("@CustNo", SqlDbType.Int);
            daDogs = new SqlDataAdapter(cmdDogDetails);
            daDogs.FillSchema(dsInTheDogHouse, SchemaType.Source, "Dog");

            //set up dataAdapter for kennel details for the listbox
            sqlKennelDetails = @"SELECT distinct kennelNo, sizeK, sizeNo, sizeB, dog.breedNo, chargePerDay FROM kennel JOIN size ON sizeK = sizeNo JOIN breed ON sizeNo = sizeB JOIN dog ON dog.breedNo = breed.breedNo WHERE dog.breedNo = @BreedNo ORDER BY kennelNo";
            cmdKennelDetails = new SqlCommand(sqlKennelDetails, conn);
            cmdKennelDetails.Parameters.Add("@BreedNo", SqlDbType.Int);
            daKennels = new SqlDataAdapter(cmdKennelDetails);
            daKennels.FillSchema(dsInTheDogHouse, SchemaType.Source, "Kennel");

            //set up dataAdapter for kennels already booked details for the validation
            sqlBookedKennels = @"SELECT booking.bookingNo, dateStart, noDays, dogNo, kennelNo FROM booking JOIN bookingDetail ON booking.bookingNo = bookingDetail.bookingNo ORDER BY bookingNo";
            daBookedKennels = new SqlDataAdapter(sqlBookedKennels, conn);
            cmdBBookedKennels = new SqlCommandBuilder(daBookedKennels);
            daBookedKennels.FillSchema(dsInTheDogHouse, SchemaType.Source, "BookedKennels");
            daBookedKennels.Fill(dsInTheDogHouse, "BookedKennels");

            sqlBooking = @"SELECT * FROM Booking";
            daBooking = new SqlDataAdapter(sqlBooking, conn);
            cmdBBooking = new SqlCommandBuilder(daBooking);
            daBooking.FillSchema(dsInTheDogHouse, SchemaType.Source, "Booking");
            daBooking.Fill(dsInTheDogHouse, "Booking");

            sqlBookingDet = @"SELECT * FROM bookingDetail";
            daBookingDet = new SqlDataAdapter(sqlBookingDet, conn);
            cmdBBookingDet = new SqlCommandBuilder(daBookingDet);
            daBookingDet.FillSchema(dsInTheDogHouse, SchemaType.Source, "bookingDetail");
            daBookingDet.Fill(dsInTheDogHouse, "bookingDetail");
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
            dsInTheDogHouse.Tables["Dog"].Clear();
            dsInTheDogHouse.Tables["Kennel"].Clear();

            ClearCustomer();
            pnlBooking.Enabled = false;
        }

        private void fillListboxCustomers(String str)
        {
            //enable after alphabet button pressed
            lstCustomer.Enabled = true;

            //get all customer details for listbox - use wildcard for parameter
            cmdCustomerDetails.Parameters["@Letter"].Value = str + "%";
            daCustomers.Fill(dsInTheDogHouse, "Customer");

            //fill listbox
            lstCustomer.DataSource = dsInTheDogHouse.Tables["Customer"];
            lstCustomer.DisplayMember = "name";
            lstCustomer.ValueMember = "CustomerNo";

            //enable lstDog for next step
            lstDog.Enabled = true;
        }

        private void lstKennel_Click(object sender, EventArgs e)
        {
            if (lstKennel.Items.Count != 0)
            {
                pnlBooking.Enabled = true;
            }

            
        }
        private void lstDog_Click(object sender, EventArgs e)
        {
            if (lstDog.Items.Count != 0)
            {
                //empty dataset table Kennel
                dsInTheDogHouse.Tables["Kennel"].Clear();

                //get all kennel details for listbox 
                cmdKennelDetails.Parameters["@BreedNo"].Value = lstDog.SelectedValue;

                daKennels.Fill(dsInTheDogHouse, "Kennel");

                //fill listbox
                lstKennel.DataSource = dsInTheDogHouse.Tables["Kennel"];
                lstKennel.DisplayMember = "KennelNo";
                lstKennel.ValueMember = "KennelNo";

                lstKennel.SelectedIndex = -1;
            }

            //enable lstKennel for next step
            lstKennel.Enabled = true;
            
        }

        private void lstCustomer_Click(object sender, EventArgs e)
        {
            if (lstCustomer.SelectedIndex == -1)
            {
                // No item is selected, clear the dog list and customer details
                dsInTheDogHouse.Tables["Dog"].Clear();
                ClearCustomer();
                pnlBooking.Enabled = false;
                return;
            }

            String title = "";

            dsInTheDogHouse.Tables["Dog"].Clear();

            // get all dog details for listbox
            cmdDogDetails.Parameters["@CustNo"].Value = lstCustomer.SelectedValue;

            daDogs.Fill(dsInTheDogHouse, "Dog");

            // fill listbox
            lstDog.DataSource = dsInTheDogHouse.Tables["Dog"];
            lstDog.DisplayMember = "name";
            lstDog.ValueMember = "breedNo";

            lstDog.SelectedIndex = -1;

            drCustomer = dsInTheDogHouse.Tables["Customer"].Rows.Find(lstCustomer.SelectedValue);

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

            // clear booking list view when another customer is selected
            ClearBooking();

            // clear kennel as each customer is selected to prevent different customer dogs in same bookings
            ClearKennel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow drBooking, drBookingDets;
            int bookingNo;

            int noRows = dsInTheDogHouse.Tables["Booking"].Rows.Count;

            drBooking = dsInTheDogHouse.Tables["Booking"].Rows[noRows - 1];
            bookingNo = (int.Parse(drBooking["BookingNo"].ToString()) + 1);

            if (lstCustomer.SelectedIndex == -1)
                MessageBox.Show("Please select a Customer", "Customer");
            else if (lstDog.SelectedIndex == -1)
                MessageBox.Show("Please select a Dog", "Dog");
            else if (lstKennel.SelectedIndex == -1)
                MessageBox.Show("Please select a Kennel", "Kennel");
            else if (string.IsNullOrEmpty(cmbNoOfDays.Text))
            {
                MessageBox.Show("Please input the number of days required", "No of Days");
                cmbNoOfDays.Focus();
            }
            else if (lvwBooking.Items.Count == 0)
                MessageBox.Show("Please add a dog/kennel to the booking", "Booking Details");
            else
            {
                drBooking = dsInTheDogHouse.Tables["Booking"].NewRow();

                drBooking["BookingNo"] = bookingNo;
                drBooking["customerNo"] = int.Parse(lblCust0.Text);
                drBooking["dateBooked"] = DateTime.Parse(lblBookingDate.Text.Trim());
                drBooking["dateStart"] = DateTime.Parse(dtpStartDate.Text.Trim());
                drBooking["noDays"] = int.Parse(cmbNoOfDays.Text);

                dsInTheDogHouse.Tables["Booking"].Rows.Add(drBooking);
                daBooking.Update(dsInTheDogHouse, "Booking");

                foreach (ListViewItem item in lvwBooking.Items)
                {
                    drBookingDets = dsInTheDogHouse.Tables["BookingDetail"].NewRow();
                    drBookingDets["bookingNo"] = drBooking["bookingNo"];
                    drBookingDets["dogNo"] = int.Parse(item.SubItems[0].Text);
                    drBookingDets["kennelNo"] = int.Parse(item.SubItems[2].Text);
                    dsInTheDogHouse.Tables["BookingDetail"].Rows.Add(drBookingDets);
                    daBookingDet.Update(dsInTheDogHouse, "BookingDetail");
                }

                MessageBox.Show("Booking No: " + drBooking["BookingNo"].ToString() + " added to system");

                pnlBooking.Enabled = false;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            bool ok = true;
            bool exits = false;

            if (lstCustomer.SelectedIndex == -1)
                MessageBox.Show("Please select a Customer", "Customer");
            else if (lstDog.SelectedIndex == -1)
                MessageBox.Show("Please select a Dog", "Dog");
            else if (lstKennel.SelectedIndex == -1)
                MessageBox.Show("Please select a Kennel", "Kennel");
            else if (string.IsNullOrEmpty(cmbNoOfDays.Text))
            {
                MessageBox.Show("Please input number of days required", "No Of Days");
                cmbNoOfDays.Focus();
            }
            else
            {
                foreach (ListViewItem item in lvwBooking.Items)
                {
                    if (item.SubItems[1].Text == lstDog.Text || item.SubItems[2].Text == lstKennel.Text)
                    {
                        MessageBox.Show("Dog or kennel already selected for this booking.", "Booking");
                        exits = true;
                        break;
                    }
                }

                if (!exits)
                {
                    DateTime start = DateTime.Parse(dtpStartDate.Text.Trim());

                    foreach (DataRow dr in dsInTheDogHouse.Tables["BookedKennels"].Rows)
                    {
                        DateTime bookedDate = DateTime.Parse(dr["dateStart"].ToString());

                        if (start >= bookedDate && start <= bookedDate.AddDays(int.Parse(cmbNoOfDays.Text)))
                        {
                            if ((dr["dogNo"] == lstDog.SelectedValue) || (dr["kennelNo"].ToString() == lstKennel.Text))
                            {
                                MessageBox.Show("Either the selected kennel or dog is already included in a booking for this date range. Please re-select.", "Booking");
                                ok = false;
                            }
                            if (!ok)
                                break;
                        }
                    }

                    if (ok)
                    {
                        foreach (DataRow dr in dsInTheDogHouse.Tables["dog"].Rows)
                        {
                            if (dr["name"].ToString() == lstDog.Text)
                            {
                                ListViewItem item = new ListViewItem(dr["dogNo"].ToString());
                                item.SubItems.Add(dr["name"].ToString());
                                item.SubItems.Add(lstKennel.Text);
                                lvwBooking.Items.Add(item);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e) 
        {
        if (lvwBooking.SelectedItems.Count != 0)
            {
                var item = lvwBooking.SelectedItems[0];
                lvwBooking.Items.Remove(item);
            }
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

        private void ClearBooking()
        {
            lvwBooking.Items.Clear();
        }

        private void ClearKennel()
        {
            lstKennel.DataSource = null;
            lstKennel.Items.Clear();
        }


    }
}
