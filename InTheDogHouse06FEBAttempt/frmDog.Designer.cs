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
using InTheDogHouse06FEBAttempt;

namespace InTheDogHouse06FEBAttempt
{
    partial class frmDog
    {
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDog));
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabDog = new System.Windows.Forms.TabControl();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.btnDisplayExit = new System.Windows.Forms.Button();
            this.btnDisplayDelete = new System.Windows.Forms.Button();
            this.btnDisplayEdit = new System.Windows.Forms.Button();
            this.btnDisplayAdd = new System.Windows.Forms.Button();
            this.dgvDog = new System.Windows.Forms.DataGridView();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.cmbAddBreedNo = new System.Windows.Forms.ComboBox();
            this.cmbAddGender = new System.Windows.Forms.ComboBox();
            this.dtpAddDOB = new System.Windows.Forms.DateTimePicker();
            this.txtAddName = new System.Windows.Forms.TextBox();
            this.btnAddCancel = new System.Windows.Forms.Button();
            this.btnAddAdd = new System.Windows.Forms.Button();
            this.txtAddColour = new System.Windows.Forms.TextBox();
            this.cmbAddCustNo = new System.Windows.Forms.ComboBox();
            this.lblAddDogNumber = new System.Windows.Forms.Label();
            this.lblAddCustNo = new System.Windows.Forms.Label();
            this.lblAddColour = new System.Windows.Forms.Label();
            this.lblAddGender = new System.Windows.Forms.Label();
            this.lblAddDOB = new System.Windows.Forms.Label();
            this.lblAddBreed = new System.Windows.Forms.Label();
            this.lblAddName = new System.Windows.Forms.Label();
            this.lblAddDogNo = new System.Windows.Forms.Label();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.cmbEditBreedNo = new System.Windows.Forms.ComboBox();
            this.cmbEditGender = new System.Windows.Forms.ComboBox();
            this.dtpEditDOB = new System.Windows.Forms.DateTimePicker();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.txtEditColour = new System.Windows.Forms.TextBox();
            this.cmbEditCustNo = new System.Windows.Forms.ComboBox();
            this.lblEditDogNumber = new System.Windows.Forms.Label();
            this.lblEditCustNo = new System.Windows.Forms.Label();
            this.lblEditColour = new System.Windows.Forms.Label();
            this.lblEditGender = new System.Windows.Forms.Label();
            this.lblEditDOB = new System.Windows.Forms.Label();
            this.lblEditBreedNo = new System.Windows.Forms.Label();
            this.lblEditName = new System.Windows.Forms.Label();
            this.lblEditDogNo = new System.Windows.Forms.Label();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnEditEdit = new System.Windows.Forms.Button();
            this.lblDogForm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabDog.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDog)).BeginInit();
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
            // tabDog
            // 
            this.tabDog.Controls.Add(this.tabDisplay);
            this.tabDog.Controls.Add(this.tabAdd);
            this.tabDog.Controls.Add(this.tabEdit);
            this.tabDog.Location = new System.Drawing.Point(38, 210);
            this.tabDog.Name = "tabDog";
            this.tabDog.SelectedIndex = 0;
            this.tabDog.Size = new System.Drawing.Size(1228, 517);
            this.tabDog.TabIndex = 1;
            this.tabDog.SelectedIndexChanged += new System.EventHandler(this.tabDog_SelectedIndexChanged);
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.btnDisplayExit);
            this.tabDisplay.Controls.Add(this.btnDisplayDelete);
            this.tabDisplay.Controls.Add(this.btnDisplayEdit);
            this.tabDisplay.Controls.Add(this.btnDisplayAdd);
            this.tabDisplay.Controls.Add(this.dgvDog);
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
            // dgvDog
            // 
            this.dgvDog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDog.Location = new System.Drawing.Point(2, 2);
            this.dgvDog.Name = "dgvDog";
            this.dgvDog.RowHeadersWidth = 82;
            this.dgvDog.RowTemplate.Height = 33;
            this.dgvDog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDog.Size = new System.Drawing.Size(915, 468);
            this.dgvDog.TabIndex = 0;
            this.dgvDog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDog_CellContentClick);
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.cmbAddBreedNo);
            this.tabAdd.Controls.Add(this.cmbAddGender);
            this.tabAdd.Controls.Add(this.dtpAddDOB);
            this.tabAdd.Controls.Add(this.txtAddName);
            this.tabAdd.Controls.Add(this.btnAddCancel);
            this.tabAdd.Controls.Add(this.btnAddAdd);
            this.tabAdd.Controls.Add(this.txtAddColour);
            this.tabAdd.Controls.Add(this.cmbAddCustNo);
            this.tabAdd.Controls.Add(this.lblAddDogNumber);
            this.tabAdd.Controls.Add(this.lblAddCustNo);
            this.tabAdd.Controls.Add(this.lblAddColour);
            this.tabAdd.Controls.Add(this.lblAddGender);
            this.tabAdd.Controls.Add(this.lblAddDOB);
            this.tabAdd.Controls.Add(this.lblAddBreed);
            this.tabAdd.Controls.Add(this.lblAddName);
            this.tabAdd.Controls.Add(this.lblAddDogNo);
            this.tabAdd.Location = new System.Drawing.Point(8, 39);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(1212, 470);
            this.tabAdd.TabIndex = 1;
            this.tabAdd.Text = "Add";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // cmbAddBreedNo
            // 
            this.cmbAddBreedNo.FormattingEnabled = true;
            this.cmbAddBreedNo.Location = new System.Drawing.Point(226, 124);
            this.cmbAddBreedNo.Name = "cmbAddBreedNo";
            this.cmbAddBreedNo.Size = new System.Drawing.Size(350, 33);
            this.cmbAddBreedNo.TabIndex = 58;
            // 
            // cmbAddGender
            // 
            this.cmbAddGender.FormattingEnabled = true;
            this.cmbAddGender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cmbAddGender.Location = new System.Drawing.Point(226, 224);
            this.cmbAddGender.Name = "cmbAddGender";
            this.cmbAddGender.Size = new System.Drawing.Size(350, 33);
            this.cmbAddGender.TabIndex = 23;
            // 
            // dtpAddDOB
            // 
            this.dtpAddDOB.Location = new System.Drawing.Point(226, 173);
            this.dtpAddDOB.Name = "dtpAddDOB";
            this.dtpAddDOB.Size = new System.Drawing.Size(350, 31);
            this.dtpAddDOB.TabIndex = 22;
            // 
            // txtAddName
            // 
            this.txtAddName.Location = new System.Drawing.Point(226, 80);
            this.txtAddName.Name = "txtAddName";
            this.txtAddName.Size = new System.Drawing.Size(350, 31);
            this.txtAddName.TabIndex = 20;
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
            // txtAddColour
            // 
            this.txtAddColour.Location = new System.Drawing.Point(226, 270);
            this.txtAddColour.Name = "txtAddColour";
            this.txtAddColour.Size = new System.Drawing.Size(350, 31);
            this.txtAddColour.TabIndex = 14;
            // 
            // cmbAddCustNo
            // 
            this.cmbAddCustNo.FormattingEnabled = true;
            this.cmbAddCustNo.Location = new System.Drawing.Point(226, 315);
            this.cmbAddCustNo.Name = "cmbAddCustNo";
            this.cmbAddCustNo.Size = new System.Drawing.Size(350, 33);
            this.cmbAddCustNo.TabIndex = 10;
            // 
            // lblAddDogNumber
            // 
            this.lblAddDogNumber.AutoSize = true;
            this.lblAddDogNumber.Location = new System.Drawing.Point(221, 40);
            this.lblAddDogNumber.Name = "lblAddDogNumber";
            this.lblAddDogNumber.Size = new System.Drawing.Size(84, 25);
            this.lblAddDogNumber.TabIndex = 9;
            this.lblAddDogNumber.Text = "000000";
            // 
            // lblAddCustNo
            // 
            this.lblAddCustNo.AutoSize = true;
            this.lblAddCustNo.Location = new System.Drawing.Point(23, 315);
            this.lblAddCustNo.Name = "lblAddCustNo";
            this.lblAddCustNo.Size = new System.Drawing.Size(137, 25);
            this.lblAddCustNo.TabIndex = 7;
            this.lblAddCustNo.Text = "Customer No";
            // 
            // lblAddColour
            // 
            this.lblAddColour.AutoSize = true;
            this.lblAddColour.Location = new System.Drawing.Point(23, 270);
            this.lblAddColour.Name = "lblAddColour";
            this.lblAddColour.Size = new System.Drawing.Size(75, 25);
            this.lblAddColour.TabIndex = 5;
            this.lblAddColour.Text = "Colour";
            // 
            // lblAddGender
            // 
            this.lblAddGender.AutoSize = true;
            this.lblAddGender.Location = new System.Drawing.Point(23, 224);
            this.lblAddGender.Name = "lblAddGender";
            this.lblAddGender.Size = new System.Drawing.Size(83, 25);
            this.lblAddGender.TabIndex = 4;
            this.lblAddGender.Text = "Gender";
            // 
            // lblAddDOB
            // 
            this.lblAddDOB.AutoSize = true;
            this.lblAddDOB.Location = new System.Drawing.Point(23, 178);
            this.lblAddDOB.Name = "lblAddDOB";
            this.lblAddDOB.Size = new System.Drawing.Size(57, 25);
            this.lblAddDOB.TabIndex = 3;
            this.lblAddDOB.Text = "DOB";
            // 
            // lblAddBreed
            // 
            this.lblAddBreed.AutoSize = true;
            this.lblAddBreed.Location = new System.Drawing.Point(23, 132);
            this.lblAddBreed.Name = "lblAddBreed";
            this.lblAddBreed.Size = new System.Drawing.Size(131, 25);
            this.lblAddBreed.TabIndex = 2;
            this.lblAddBreed.Text = "Breed Name";
            // 
            // lblAddName
            // 
            this.lblAddName.AutoSize = true;
            this.lblAddName.Location = new System.Drawing.Point(23, 86);
            this.lblAddName.Name = "lblAddName";
            this.lblAddName.Size = new System.Drawing.Size(68, 25);
            this.lblAddName.TabIndex = 1;
            this.lblAddName.Text = "Name";
            // 
            // lblAddDogNo
            // 
            this.lblAddDogNo.AutoSize = true;
            this.lblAddDogNo.Location = new System.Drawing.Point(23, 40);
            this.lblAddDogNo.Name = "lblAddDogNo";
            this.lblAddDogNo.Size = new System.Drawing.Size(84, 25);
            this.lblAddDogNo.TabIndex = 0;
            this.lblAddDogNo.Text = "Dog No";
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.cmbEditBreedNo);
            this.tabEdit.Controls.Add(this.cmbEditGender);
            this.tabEdit.Controls.Add(this.dtpEditDOB);
            this.tabEdit.Controls.Add(this.txtEditName);
            this.tabEdit.Controls.Add(this.txtEditColour);
            this.tabEdit.Controls.Add(this.cmbEditCustNo);
            this.tabEdit.Controls.Add(this.lblEditDogNumber);
            this.tabEdit.Controls.Add(this.lblEditCustNo);
            this.tabEdit.Controls.Add(this.lblEditColour);
            this.tabEdit.Controls.Add(this.lblEditGender);
            this.tabEdit.Controls.Add(this.lblEditDOB);
            this.tabEdit.Controls.Add(this.lblEditBreedNo);
            this.tabEdit.Controls.Add(this.lblEditName);
            this.tabEdit.Controls.Add(this.lblEditDogNo);
            this.tabEdit.Controls.Add(this.btnEditCancel);
            this.tabEdit.Controls.Add(this.btnEditEdit);
            this.tabEdit.Location = new System.Drawing.Point(8, 39);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Size = new System.Drawing.Size(1212, 470);
            this.tabEdit.TabIndex = 2;
            this.tabEdit.Text = "Edit";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // cmbEditBreedNo
            // 
            this.cmbEditBreedNo.Enabled = false;
            this.cmbEditBreedNo.FormattingEnabled = true;
            this.cmbEditBreedNo.Location = new System.Drawing.Point(238, 124);
            this.cmbEditBreedNo.Name = "cmbEditBreedNo";
            this.cmbEditBreedNo.Size = new System.Drawing.Size(350, 33);
            this.cmbEditBreedNo.TabIndex = 57;
            // 
            // cmbEditGender
            // 
            this.cmbEditGender.Enabled = false;
            this.cmbEditGender.FormattingEnabled = true;
            this.cmbEditGender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cmbEditGender.Location = new System.Drawing.Point(238, 221);
            this.cmbEditGender.Name = "cmbEditGender";
            this.cmbEditGender.Size = new System.Drawing.Size(350, 33);
            this.cmbEditGender.TabIndex = 56;
            // 
            // dtpEditDOB
            // 
            this.dtpEditDOB.Enabled = false;
            this.dtpEditDOB.Location = new System.Drawing.Point(238, 174);
            this.dtpEditDOB.Name = "dtpEditDOB";
            this.dtpEditDOB.Size = new System.Drawing.Size(350, 31);
            this.dtpEditDOB.TabIndex = 55;
            // 
            // txtEditName
            // 
            this.txtEditName.Enabled = false;
            this.txtEditName.Location = new System.Drawing.Point(238, 80);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(350, 31);
            this.txtEditName.TabIndex = 54;
            // 
            // txtEditColour
            // 
            this.txtEditColour.Enabled = false;
            this.txtEditColour.Location = new System.Drawing.Point(238, 270);
            this.txtEditColour.Name = "txtEditColour";
            this.txtEditColour.Size = new System.Drawing.Size(350, 31);
            this.txtEditColour.TabIndex = 52;
            // 
            // cmbEditCustNo
            // 
            this.cmbEditCustNo.Enabled = false;
            this.cmbEditCustNo.FormattingEnabled = true;
            this.cmbEditCustNo.Location = new System.Drawing.Point(238, 318);
            this.cmbEditCustNo.Name = "cmbEditCustNo";
            this.cmbEditCustNo.Size = new System.Drawing.Size(350, 33);
            this.cmbEditCustNo.TabIndex = 49;
            // 
            // lblEditDogNumber
            // 
            this.lblEditDogNumber.AutoSize = true;
            this.lblEditDogNumber.Location = new System.Drawing.Point(233, 40);
            this.lblEditDogNumber.Name = "lblEditDogNumber";
            this.lblEditDogNumber.Size = new System.Drawing.Size(84, 25);
            this.lblEditDogNumber.TabIndex = 48;
            this.lblEditDogNumber.Text = "000000";
            // 
            // lblEditCustNo
            // 
            this.lblEditCustNo.AutoSize = true;
            this.lblEditCustNo.Location = new System.Drawing.Point(35, 318);
            this.lblEditCustNo.Name = "lblEditCustNo";
            this.lblEditCustNo.Size = new System.Drawing.Size(137, 25);
            this.lblEditCustNo.TabIndex = 47;
            this.lblEditCustNo.Text = "Customer No";
            // 
            // lblEditColour
            // 
            this.lblEditColour.AutoSize = true;
            this.lblEditColour.Location = new System.Drawing.Point(35, 270);
            this.lblEditColour.Name = "lblEditColour";
            this.lblEditColour.Size = new System.Drawing.Size(75, 25);
            this.lblEditColour.TabIndex = 45;
            this.lblEditColour.Text = "Colour";
            // 
            // lblEditGender
            // 
            this.lblEditGender.AutoSize = true;
            this.lblEditGender.Location = new System.Drawing.Point(35, 224);
            this.lblEditGender.Name = "lblEditGender";
            this.lblEditGender.Size = new System.Drawing.Size(83, 25);
            this.lblEditGender.TabIndex = 44;
            this.lblEditGender.Text = "Gender";
            // 
            // lblEditDOB
            // 
            this.lblEditDOB.AutoSize = true;
            this.lblEditDOB.Location = new System.Drawing.Point(35, 178);
            this.lblEditDOB.Name = "lblEditDOB";
            this.lblEditDOB.Size = new System.Drawing.Size(57, 25);
            this.lblEditDOB.TabIndex = 43;
            this.lblEditDOB.Text = "DOB";
            // 
            // lblEditBreedNo
            // 
            this.lblEditBreedNo.AutoSize = true;
            this.lblEditBreedNo.Location = new System.Drawing.Point(35, 132);
            this.lblEditBreedNo.Name = "lblEditBreedNo";
            this.lblEditBreedNo.Size = new System.Drawing.Size(131, 25);
            this.lblEditBreedNo.TabIndex = 42;
            this.lblEditBreedNo.Text = "Breed Name";
            // 
            // lblEditName
            // 
            this.lblEditName.AutoSize = true;
            this.lblEditName.Location = new System.Drawing.Point(35, 86);
            this.lblEditName.Name = "lblEditName";
            this.lblEditName.Size = new System.Drawing.Size(68, 25);
            this.lblEditName.TabIndex = 41;
            this.lblEditName.Text = "Name";
            // 
            // lblEditDogNo
            // 
            this.lblEditDogNo.AutoSize = true;
            this.lblEditDogNo.Location = new System.Drawing.Point(35, 40);
            this.lblEditDogNo.Name = "lblEditDogNo";
            this.lblEditDogNo.Size = new System.Drawing.Size(84, 25);
            this.lblEditDogNo.TabIndex = 40;
            this.lblEditDogNo.Text = "Dog No";
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
            // lblDogForm
            // 
            this.lblDogForm.AutoSize = true;
            this.lblDogForm.Location = new System.Drawing.Point(1153, 201);
            this.lblDogForm.Name = "lblDogForm";
            this.lblDogForm.Size = new System.Drawing.Size(106, 25);
            this.lblDogForm.TabIndex = 2;
            this.lblDogForm.Text = "Dog Form";
            // 
            // frmDog
            // 
            this.ClientSize = new System.Drawing.Size(1291, 782);
            this.Controls.Add(this.lblDogForm);
            this.Controls.Add(this.tabDog);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmDog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDog_Load);
            this.Shown += new System.EventHandler(this.frmDog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabDog.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDog)).EndInit();
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            this.tabEdit.ResumeLayout(false);
            this.tabEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private IContainer components;
        private TextBox txtAddName;
        private TextBox txtEditName;
        private TextBox txtEditColour;
        private ComboBox cmbEditCustNo;
        private Label lblEditDogNumber;
        private Label lblEditCustNo;
        private Label lblEditColour;
        private Label lblEditGender;
        private Label lblEditDOB;
        private Label lblEditBreedNo;
        private Label lblEditName;
        private Label lblEditDogNo;
        private Label lblDogForm;
        private DateTimePicker dtpAddDOB;
        private DateTimePicker dtpEditDOB;
        private ComboBox cmbAddGender;
        private ComboBox cmbEditGender;
        private ComboBox cmbAddBreedNo;
        private ComboBox cmbEditBreedNo;
    }
}