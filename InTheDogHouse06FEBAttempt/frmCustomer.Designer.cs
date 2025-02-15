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
using InTheDogHouse06FEBAttempt; //Everything Windows needs for elements of the form.

namespace InTheDogHouse06FEBAttempt //Namespace for this project
{
    partial class frmCustomer
    {
        private void InitializeComponent() //INITIALISES EVERY ELEMENT ON THE CUSTOMER FORM
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.btnDisplayExit = new System.Windows.Forms.Button();
            this.btnDisplayDelete = new System.Windows.Forms.Button();
            this.btnDisplayEdit = new System.Windows.Forms.Button();
            this.btnDisplayAdd = new System.Windows.Forms.Button();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.btnAddCancel = new System.Windows.Forms.Button();
            this.btnAddAdd = new System.Windows.Forms.Button();
            this.txtAddTelNo = new System.Windows.Forms.TextBox();
            this.txtAddPostcode = new System.Windows.Forms.TextBox();
            this.txtAddCounty = new System.Windows.Forms.TextBox();
            this.txtAddTown = new System.Windows.Forms.TextBox();
            this.txtAddStreet = new System.Windows.Forms.TextBox();
            this.txtAddForename = new System.Windows.Forms.TextBox();
            this.txtAddSurname = new System.Windows.Forms.TextBox();
            this.cboAddTitle = new System.Windows.Forms.ComboBox();
            this.lblAddCustomerNumber = new System.Windows.Forms.Label();
            this.lblAddTelNo = new System.Windows.Forms.Label();
            this.lblAddPostcode = new System.Windows.Forms.Label();
            this.lblAddCounty = new System.Windows.Forms.Label();
            this.lblAddTown = new System.Windows.Forms.Label();
            this.lblAddStreet = new System.Windows.Forms.Label();
            this.lblAddForename = new System.Windows.Forms.Label();
            this.lblAddSurname = new System.Windows.Forms.Label();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.lblAddCustNo = new System.Windows.Forms.Label();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.lblEditCustomerNumber = new System.Windows.Forms.Label();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnEditEdit = new System.Windows.Forms.Button();
            this.txtEditTelNo = new System.Windows.Forms.TextBox();
            this.txtEditPostcode = new System.Windows.Forms.TextBox();
            this.txtEditCounty = new System.Windows.Forms.TextBox();
            this.txtEditTown = new System.Windows.Forms.TextBox();
            this.txtEditStreet = new System.Windows.Forms.TextBox();
            this.txtEditForename = new System.Windows.Forms.TextBox();
            this.txtEditSurname = new System.Windows.Forms.TextBox();
            this.cboEditTitle = new System.Windows.Forms.ComboBox();
            this.lblEditTelNo = new System.Windows.Forms.Label();
            this.lblEditPostcode = new System.Windows.Forms.Label();
            this.lblEditCounty = new System.Windows.Forms.Label();
            this.lblEditTown = new System.Windows.Forms.Label();
            this.lblEditStreet = new System.Windows.Forms.Label();
            this.lblEditForename = new System.Windows.Forms.Label();
            this.lblEditSurname = new System.Windows.Forms.Label();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.lblEditCustNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.tabAdd.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1237, 177);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDisplay);
            this.tabControl.Controls.Add(this.tabAdd);
            this.tabControl.Controls.Add(this.tabEdit);
            this.tabControl.Location = new System.Drawing.Point(38, 210);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1228, 517);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.btnDisplayExit);
            this.tabDisplay.Controls.Add(this.btnDisplayDelete);
            this.tabDisplay.Controls.Add(this.btnDisplayEdit);
            this.tabDisplay.Controls.Add(this.btnDisplayAdd);
            this.tabDisplay.Controls.Add(this.dgvCustomer);
            this.tabDisplay.Location = new System.Drawing.Point(8, 39);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplay.Size = new System.Drawing.Size(1212, 470);
            this.tabDisplay.TabIndex = 0;
            this.tabDisplay.Text = "Display";
            this.tabDisplay.UseVisualStyleBackColor = true;
            // 
            // btnDisplayExit
            // 
            this.btnDisplayExit.Location = new System.Drawing.Point(939, 200);
            this.btnDisplayExit.Name = "btnDisplayExit";
            this.btnDisplayExit.Size = new System.Drawing.Size(251, 55);
            this.btnDisplayExit.TabIndex = 4;
            this.btnDisplayExit.Text = "Exit";
            this.btnDisplayExit.UseVisualStyleBackColor = true;
            this.btnDisplayExit.Click += new System.EventHandler(this.btnDisplayExit_Click);
            // 
            // btnDisplayDelete
            // 
            this.btnDisplayDelete.Location = new System.Drawing.Point(939, 138);
            this.btnDisplayDelete.Name = "btnDisplayDelete";
            this.btnDisplayDelete.Size = new System.Drawing.Size(251, 55);
            this.btnDisplayDelete.TabIndex = 3;
            this.btnDisplayDelete.Text = "Delete";
            this.btnDisplayDelete.UseVisualStyleBackColor = true;
            this.btnDisplayDelete.Click += new System.EventHandler(this.btnDisplayDelete_Click);
            // 
            // btnDisplayEdit
            // 
            this.btnDisplayEdit.Location = new System.Drawing.Point(939, 77);
            this.btnDisplayEdit.Name = "btnDisplayEdit";
            this.btnDisplayEdit.Size = new System.Drawing.Size(251, 55);
            this.btnDisplayEdit.TabIndex = 2;
            this.btnDisplayEdit.Text = "Edit";
            this.btnDisplayEdit.UseVisualStyleBackColor = true;
            this.btnDisplayEdit.Click += new System.EventHandler(this.btnDisplayEdit_Click);
            // 
            // btnDisplayAdd
            // 
            this.btnDisplayAdd.Location = new System.Drawing.Point(939, 16);
            this.btnDisplayAdd.Name = "btnDisplayAdd";
            this.btnDisplayAdd.Size = new System.Drawing.Size(251, 55);
            this.btnDisplayAdd.TabIndex = 1;
            this.btnDisplayAdd.Text = "Add";
            this.btnDisplayAdd.UseVisualStyleBackColor = true;
            this.btnDisplayAdd.Click += new System.EventHandler(this.btnDisplayAdd_Click);
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Location = new System.Drawing.Point(2, 2);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersWidth = 82;
            this.dgvCustomer.RowTemplate.Height = 33;
            this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(915, 468);
            this.dgvCustomer.TabIndex = 0;
            this.dgvCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellContentClick);
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.btnAddCancel);
            this.tabAdd.Controls.Add(this.btnAddAdd);
            this.tabAdd.Controls.Add(this.txtAddTelNo);
            this.tabAdd.Controls.Add(this.txtAddPostcode);
            this.tabAdd.Controls.Add(this.txtAddCounty);
            this.tabAdd.Controls.Add(this.txtAddTown);
            this.tabAdd.Controls.Add(this.txtAddStreet);
            this.tabAdd.Controls.Add(this.txtAddForename);
            this.tabAdd.Controls.Add(this.txtAddSurname);
            this.tabAdd.Controls.Add(this.cboAddTitle);
            this.tabAdd.Controls.Add(this.lblAddCustomerNumber);
            this.tabAdd.Controls.Add(this.lblAddTelNo);
            this.tabAdd.Controls.Add(this.lblAddPostcode);
            this.tabAdd.Controls.Add(this.lblAddCounty);
            this.tabAdd.Controls.Add(this.lblAddTown);
            this.tabAdd.Controls.Add(this.lblAddStreet);
            this.tabAdd.Controls.Add(this.lblAddForename);
            this.tabAdd.Controls.Add(this.lblAddSurname);
            this.tabAdd.Controls.Add(this.lblAddTitle);
            this.tabAdd.Controls.Add(this.lblAddCustNo);
            this.tabAdd.Location = new System.Drawing.Point(8, 39);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(1212, 470);
            this.tabAdd.TabIndex = 1;
            this.tabAdd.Text = "Add";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // btnAddCancel
            // 
            this.btnAddCancel.Location = new System.Drawing.Point(935, 86);
            this.btnAddCancel.Name = "btnAddCancel";
            this.btnAddCancel.Size = new System.Drawing.Size(251, 55);
            this.btnAddCancel.TabIndex = 19;
            this.btnAddCancel.Text = "Cancel";
            this.btnAddCancel.UseVisualStyleBackColor = true;
            this.btnAddCancel.Click += new System.EventHandler(this.btnAddCancel_Click);
            // 
            // btnAddAdd
            // 
            this.btnAddAdd.Location = new System.Drawing.Point(935, 25);
            this.btnAddAdd.Name = "btnAddAdd";
            this.btnAddAdd.Size = new System.Drawing.Size(251, 55);
            this.btnAddAdd.TabIndex = 18;
            this.btnAddAdd.Text = "Add";
            this.btnAddAdd.UseVisualStyleBackColor = true;
            this.btnAddAdd.Click += new System.EventHandler(this.btnAddAdd_Click);
            // 
            // txtAddTelNo
            // 
            this.txtAddTelNo.Location = new System.Drawing.Point(226, 408);
            this.txtAddTelNo.Name = "txtAddTelNo";
            this.txtAddTelNo.Size = new System.Drawing.Size(350, 31);
            this.txtAddTelNo.TabIndex = 17;
            // 
            // txtAddPostcode
            // 
            this.txtAddPostcode.Location = new System.Drawing.Point(226, 362);
            this.txtAddPostcode.Name = "txtAddPostcode";
            this.txtAddPostcode.Size = new System.Drawing.Size(350, 31);
            this.txtAddPostcode.TabIndex = 16;
            // 
            // txtAddCounty
            // 
            this.txtAddCounty.Location = new System.Drawing.Point(226, 316);
            this.txtAddCounty.Name = "txtAddCounty";
            this.txtAddCounty.Size = new System.Drawing.Size(350, 31);
            this.txtAddCounty.TabIndex = 15;
            // 
            // txtAddTown
            // 
            this.txtAddTown.Location = new System.Drawing.Point(226, 270);
            this.txtAddTown.Name = "txtAddTown";
            this.txtAddTown.Size = new System.Drawing.Size(350, 31);
            this.txtAddTown.TabIndex = 14;
            // 
            // txtAddStreet
            // 
            this.txtAddStreet.Location = new System.Drawing.Point(226, 224);
            this.txtAddStreet.Name = "txtAddStreet";
            this.txtAddStreet.Size = new System.Drawing.Size(350, 31);
            this.txtAddStreet.TabIndex = 13;
            // 
            // txtAddForename
            // 
            this.txtAddForename.Location = new System.Drawing.Point(226, 175);
            this.txtAddForename.Name = "txtAddForename";
            this.txtAddForename.Size = new System.Drawing.Size(350, 31);
            this.txtAddForename.TabIndex = 12;
            // 
            // txtAddSurname
            // 
            this.txtAddSurname.Location = new System.Drawing.Point(226, 126);
            this.txtAddSurname.Name = "txtAddSurname";
            this.txtAddSurname.Size = new System.Drawing.Size(350, 31);
            this.txtAddSurname.TabIndex = 11;
            // 
            // cboAddTitle
            // 
            this.cboAddTitle.FormattingEnabled = true;
            this.cboAddTitle.Items.AddRange(new object[] {
            "Mr",
            "Mrs",
            "Miss",
            "Ms"});
            this.cboAddTitle.Location = new System.Drawing.Point(226, 86);
            this.cboAddTitle.Name = "cboAddTitle";
            this.cboAddTitle.Size = new System.Drawing.Size(152, 33);
            this.cboAddTitle.TabIndex = 10;
            this.cboAddTitle.SelectedIndexChanged += new System.EventHandler(this.cboAddTitle_SelectedIndexChanged);
            // 
            // lblAddCustomerNumber
            // 
            this.lblAddCustomerNumber.AutoSize = true;
            this.lblAddCustomerNumber.Location = new System.Drawing.Point(221, 40);
            this.lblAddCustomerNumber.Name = "lblAddCustomerNumber";
            this.lblAddCustomerNumber.Size = new System.Drawing.Size(84, 25);
            this.lblAddCustomerNumber.TabIndex = 9;
            this.lblAddCustomerNumber.Text = "000000";
            this.lblAddCustomerNumber.Click += new System.EventHandler(this.lblAddCustomerNumber_Click);
            // 
            // lblAddTelNo
            // 
            this.lblAddTelNo.AutoSize = true;
            this.lblAddTelNo.Location = new System.Drawing.Point(23, 408);
            this.lblAddTelNo.Name = "lblAddTelNo";
            this.lblAddTelNo.Size = new System.Drawing.Size(75, 25);
            this.lblAddTelNo.TabIndex = 8;
            this.lblAddTelNo.Text = "Tel No";
            // 
            // lblAddPostcode
            // 
            this.lblAddPostcode.AutoSize = true;
            this.lblAddPostcode.Location = new System.Drawing.Point(23, 362);
            this.lblAddPostcode.Name = "lblAddPostcode";
            this.lblAddPostcode.Size = new System.Drawing.Size(102, 25);
            this.lblAddPostcode.TabIndex = 7;
            this.lblAddPostcode.Text = "Postcode";
            // 
            // lblAddCounty
            // 
            this.lblAddCounty.AutoSize = true;
            this.lblAddCounty.Location = new System.Drawing.Point(23, 316);
            this.lblAddCounty.Name = "lblAddCounty";
            this.lblAddCounty.Size = new System.Drawing.Size(80, 25);
            this.lblAddCounty.TabIndex = 6;
            this.lblAddCounty.Text = "County";
            // 
            // lblAddTown
            // 
            this.lblAddTown.AutoSize = true;
            this.lblAddTown.Location = new System.Drawing.Point(23, 270);
            this.lblAddTown.Name = "lblAddTown";
            this.lblAddTown.Size = new System.Drawing.Size(64, 25);
            this.lblAddTown.TabIndex = 5;
            this.lblAddTown.Text = "Town";
            // 
            // lblAddStreet
            // 
            this.lblAddStreet.AutoSize = true;
            this.lblAddStreet.Location = new System.Drawing.Point(23, 224);
            this.lblAddStreet.Name = "lblAddStreet";
            this.lblAddStreet.Size = new System.Drawing.Size(69, 25);
            this.lblAddStreet.TabIndex = 4;
            this.lblAddStreet.Text = "Street";
            // 
            // lblAddForename
            // 
            this.lblAddForename.AutoSize = true;
            this.lblAddForename.Location = new System.Drawing.Point(23, 178);
            this.lblAddForename.Name = "lblAddForename";
            this.lblAddForename.Size = new System.Drawing.Size(109, 25);
            this.lblAddForename.TabIndex = 3;
            this.lblAddForename.Text = "Forename";
            // 
            // lblAddSurname
            // 
            this.lblAddSurname.AutoSize = true;
            this.lblAddSurname.Location = new System.Drawing.Point(23, 132);
            this.lblAddSurname.Name = "lblAddSurname";
            this.lblAddSurname.Size = new System.Drawing.Size(98, 25);
            this.lblAddSurname.TabIndex = 2;
            this.lblAddSurname.Text = "Surname";
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Location = new System.Drawing.Point(23, 86);
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(53, 25);
            this.lblAddTitle.TabIndex = 1;
            this.lblAddTitle.Text = "Title";
            // 
            // lblAddCustNo
            // 
            this.lblAddCustNo.AutoSize = true;
            this.lblAddCustNo.Location = new System.Drawing.Point(23, 40);
            this.lblAddCustNo.Name = "lblAddCustNo";
            this.lblAddCustNo.Size = new System.Drawing.Size(137, 25);
            this.lblAddCustNo.TabIndex = 0;
            this.lblAddCustNo.Text = "Customer No";
            this.lblAddCustNo.Click += new System.EventHandler(this.lblAddCustNo_Click);
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.lblEditCustomerNumber);
            this.tabEdit.Controls.Add(this.btnEditCancel);
            this.tabEdit.Controls.Add(this.btnEditEdit);
            this.tabEdit.Controls.Add(this.txtEditTelNo);
            this.tabEdit.Controls.Add(this.txtEditPostcode);
            this.tabEdit.Controls.Add(this.txtEditCounty);
            this.tabEdit.Controls.Add(this.txtEditTown);
            this.tabEdit.Controls.Add(this.txtEditStreet);
            this.tabEdit.Controls.Add(this.txtEditForename);
            this.tabEdit.Controls.Add(this.txtEditSurname);
            this.tabEdit.Controls.Add(this.cboEditTitle);
            this.tabEdit.Controls.Add(this.lblEditTelNo);
            this.tabEdit.Controls.Add(this.lblEditPostcode);
            this.tabEdit.Controls.Add(this.lblEditCounty);
            this.tabEdit.Controls.Add(this.lblEditTown);
            this.tabEdit.Controls.Add(this.lblEditStreet);
            this.tabEdit.Controls.Add(this.lblEditForename);
            this.tabEdit.Controls.Add(this.lblEditSurname);
            this.tabEdit.Controls.Add(this.lblEditTitle);
            this.tabEdit.Controls.Add(this.lblEditCustNo);
            this.tabEdit.Location = new System.Drawing.Point(8, 39);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Size = new System.Drawing.Size(1212, 470);
            this.tabEdit.TabIndex = 2;
            this.tabEdit.Text = "Edit";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // lblEditCustomerNumber
            // 
            this.lblEditCustomerNumber.AutoSize = true;
            this.lblEditCustomerNumber.Location = new System.Drawing.Point(232, 39);
            this.lblEditCustomerNumber.Name = "lblEditCustomerNumber";
            this.lblEditCustomerNumber.Size = new System.Drawing.Size(84, 25);
            this.lblEditCustomerNumber.TabIndex = 40;
            this.lblEditCustomerNumber.Text = "000000";
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.Location = new System.Drawing.Point(937, 89);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(251, 55);
            this.btnEditCancel.TabIndex = 39;
            this.btnEditCancel.Text = "Cancel";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            this.btnEditCancel.Click += new System.EventHandler(this.btnEditCancel_Click);
            // 
            // btnEditEdit
            // 
            this.btnEditEdit.Location = new System.Drawing.Point(937, 28);
            this.btnEditEdit.Name = "btnEditEdit";
            this.btnEditEdit.Size = new System.Drawing.Size(251, 55);
            this.btnEditEdit.TabIndex = 38;
            this.btnEditEdit.Text = "Edit";
            this.btnEditEdit.UseVisualStyleBackColor = true;
            this.btnEditEdit.Click += new System.EventHandler(this.btnEditEdit_Click);
            // 
            // txtEditTelNo
            // 
            this.txtEditTelNo.Enabled = false;
            this.txtEditTelNo.Location = new System.Drawing.Point(228, 411);
            this.txtEditTelNo.Name = "txtEditTelNo";
            this.txtEditTelNo.Size = new System.Drawing.Size(350, 31);
            this.txtEditTelNo.TabIndex = 37;
            // 
            // txtEditPostcode
            // 
            this.txtEditPostcode.Enabled = false;
            this.txtEditPostcode.Location = new System.Drawing.Point(228, 365);
            this.txtEditPostcode.Name = "txtEditPostcode";
            this.txtEditPostcode.Size = new System.Drawing.Size(350, 31);
            this.txtEditPostcode.TabIndex = 36;
            // 
            // txtEditCounty
            // 
            this.txtEditCounty.Enabled = false;
            this.txtEditCounty.Location = new System.Drawing.Point(228, 319);
            this.txtEditCounty.Name = "txtEditCounty";
            this.txtEditCounty.Size = new System.Drawing.Size(350, 31);
            this.txtEditCounty.TabIndex = 35;
            // 
            // txtEditTown
            // 
            this.txtEditTown.Enabled = false;
            this.txtEditTown.Location = new System.Drawing.Point(228, 273);
            this.txtEditTown.Name = "txtEditTown";
            this.txtEditTown.Size = new System.Drawing.Size(350, 31);
            this.txtEditTown.TabIndex = 34;
            // 
            // txtEditStreet
            // 
            this.txtEditStreet.Enabled = false;
            this.txtEditStreet.Location = new System.Drawing.Point(228, 227);
            this.txtEditStreet.Name = "txtEditStreet";
            this.txtEditStreet.Size = new System.Drawing.Size(350, 31);
            this.txtEditStreet.TabIndex = 33;
            // 
            // txtEditForename
            // 
            this.txtEditForename.Enabled = false;
            this.txtEditForename.Location = new System.Drawing.Point(228, 178);
            this.txtEditForename.Name = "txtEditForename";
            this.txtEditForename.Size = new System.Drawing.Size(350, 31);
            this.txtEditForename.TabIndex = 32;
            // 
            // txtEditSurname
            // 
            this.txtEditSurname.Enabled = false;
            this.txtEditSurname.Location = new System.Drawing.Point(228, 129);
            this.txtEditSurname.Name = "txtEditSurname";
            this.txtEditSurname.Size = new System.Drawing.Size(350, 31);
            this.txtEditSurname.TabIndex = 31;
            // 
            // cboEditTitle
            // 
            this.cboEditTitle.Enabled = false;
            this.cboEditTitle.FormattingEnabled = true;
            this.cboEditTitle.Items.AddRange(new object[] {
            "Mr",
            "Mrs",
            "Miss",
            "Ms"});
            this.cboEditTitle.Location = new System.Drawing.Point(228, 89);
            this.cboEditTitle.Name = "cboEditTitle";
            this.cboEditTitle.Size = new System.Drawing.Size(152, 33);
            this.cboEditTitle.TabIndex = 30;
            // 
            // lblEditTelNo
            // 
            this.lblEditTelNo.AutoSize = true;
            this.lblEditTelNo.Location = new System.Drawing.Point(25, 411);
            this.lblEditTelNo.Name = "lblEditTelNo";
            this.lblEditTelNo.Size = new System.Drawing.Size(75, 25);
            this.lblEditTelNo.TabIndex = 28;
            this.lblEditTelNo.Text = "Tel No";
            // 
            // lblEditPostcode
            // 
            this.lblEditPostcode.AutoSize = true;
            this.lblEditPostcode.Location = new System.Drawing.Point(25, 365);
            this.lblEditPostcode.Name = "lblEditPostcode";
            this.lblEditPostcode.Size = new System.Drawing.Size(102, 25);
            this.lblEditPostcode.TabIndex = 27;
            this.lblEditPostcode.Text = "Postcode";
            // 
            // lblEditCounty
            // 
            this.lblEditCounty.AutoSize = true;
            this.lblEditCounty.Location = new System.Drawing.Point(25, 319);
            this.lblEditCounty.Name = "lblEditCounty";
            this.lblEditCounty.Size = new System.Drawing.Size(80, 25);
            this.lblEditCounty.TabIndex = 26;
            this.lblEditCounty.Text = "County";
            // 
            // lblEditTown
            // 
            this.lblEditTown.AutoSize = true;
            this.lblEditTown.Location = new System.Drawing.Point(25, 273);
            this.lblEditTown.Name = "lblEditTown";
            this.lblEditTown.Size = new System.Drawing.Size(64, 25);
            this.lblEditTown.TabIndex = 25;
            this.lblEditTown.Text = "Town";
            // 
            // lblEditStreet
            // 
            this.lblEditStreet.AutoSize = true;
            this.lblEditStreet.Location = new System.Drawing.Point(25, 227);
            this.lblEditStreet.Name = "lblEditStreet";
            this.lblEditStreet.Size = new System.Drawing.Size(69, 25);
            this.lblEditStreet.TabIndex = 24;
            this.lblEditStreet.Text = "Street";
            // 
            // lblEditForename
            // 
            this.lblEditForename.AutoSize = true;
            this.lblEditForename.Location = new System.Drawing.Point(25, 181);
            this.lblEditForename.Name = "lblEditForename";
            this.lblEditForename.Size = new System.Drawing.Size(109, 25);
            this.lblEditForename.TabIndex = 23;
            this.lblEditForename.Text = "Forename";
            // 
            // lblEditSurname
            // 
            this.lblEditSurname.AutoSize = true;
            this.lblEditSurname.Location = new System.Drawing.Point(25, 135);
            this.lblEditSurname.Name = "lblEditSurname";
            this.lblEditSurname.Size = new System.Drawing.Size(98, 25);
            this.lblEditSurname.TabIndex = 22;
            this.lblEditSurname.Text = "Surname";
            // 
            // lblEditTitle
            // 
            this.lblEditTitle.AutoSize = true;
            this.lblEditTitle.Location = new System.Drawing.Point(25, 89);
            this.lblEditTitle.Name = "lblEditTitle";
            this.lblEditTitle.Size = new System.Drawing.Size(53, 25);
            this.lblEditTitle.TabIndex = 21;
            this.lblEditTitle.Text = "Title";
            // 
            // lblEditCustNo
            // 
            this.lblEditCustNo.AutoSize = true;
            this.lblEditCustNo.Location = new System.Drawing.Point(25, 43);
            this.lblEditCustNo.Name = "lblEditCustNo";
            this.lblEditCustNo.Size = new System.Drawing.Size(137, 25);
            this.lblEditCustNo.TabIndex = 20;
            this.lblEditCustNo.Text = "Customer No";
            // 
            // frmCustomer
            // 
            this.ClientSize = new System.Drawing.Size(1291, 782);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmCustomer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.Shown += new System.EventHandler(this.frmCustomer_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            this.tabEdit.ResumeLayout(false);
            this.tabEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        private IContainer components;
        private Label lblEditCustomerNumber;
    }
}