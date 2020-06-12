namespace AnyStore.UI
{
    partial class queryfrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblName = new System.Windows.Forms.Label();
            this.txtu_Name = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtu_Contact = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textqry = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textsoln = new System.Windows.Forms.TextBox();
            this.dgvquery = new System.Windows.Forms.DataGridView();
            this.dgvpending = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.useremail = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvquery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpending)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(8, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 17);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // txtu_Name
            // 
            this.txtu_Name.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtu_Name.Location = new System.Drawing.Point(68, 27);
            this.txtu_Name.Name = "txtu_Name";
            this.txtu_Name.Size = new System.Drawing.Size(223, 25);
            this.txtu_Name.TabIndex = 12;
            this.txtu_Name.TextChanged += new System.EventHandler(this.txtu_Name_TextChanged);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(8, 72);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(52, 17);
            this.lblContact.TabIndex = 13;
            this.lblContact.Text = "Contact";
            // 
            // txtu_Contact
            // 
            this.txtu_Contact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtu_Contact.Location = new System.Drawing.Point(68, 67);
            this.txtu_Contact.Name = "txtu_Contact";
            this.txtu_Contact.Size = new System.Drawing.Size(223, 25);
            this.txtu_Contact.TabIndex = 14;
            this.txtu_Contact.TextChanged += new System.EventHandler(this.txtu_Contact_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Account";
            // 
            // txtcompany
            // 
            this.txtcompany.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcompany.Location = new System.Drawing.Point(68, 131);
            this.txtcompany.Name = "txtcompany";
            this.txtcompany.Size = new System.Drawing.Size(223, 25);
            this.txtcompany.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "query";
            // 
            // textqry
            // 
            this.textqry.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textqry.Location = new System.Drawing.Point(68, 171);
            this.textqry.Multiline = true;
            this.textqry.Name = "textqry";
            this.textqry.Size = new System.Drawing.Size(223, 123);
            this.textqry.TabIndex = 18;
            this.textqry.TextChanged += new System.EventHandler(this.textqry_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "soln";
            // 
            // textsoln
            // 
            this.textsoln.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textsoln.Location = new System.Drawing.Point(68, 309);
            this.textsoln.Multiline = true;
            this.textsoln.Name = "textsoln";
            this.textsoln.Size = new System.Drawing.Size(223, 123);
            this.textsoln.TabIndex = 20;
            this.textsoln.TextChanged += new System.EventHandler(this.textsoln_TextChanged);
            // 
            // dgvquery
            // 
            this.dgvquery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvquery.Location = new System.Drawing.Point(323, 27);
            this.dgvquery.Name = "dgvquery";
            this.dgvquery.RowHeadersWidth = 100;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvquery.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvquery.Size = new System.Drawing.Size(725, 249);
            this.dgvquery.TabIndex = 22;
            this.dgvquery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvquery_CellContentClick);
            this.dgvquery.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvquery_CellContentDoubleClick);
            this.dgvquery.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvquery_CellMouseClick);
            // 
            // dgvpending
            // 
            this.dgvpending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpending.Location = new System.Drawing.Point(322, 296);
            this.dgvpending.Name = "dgvpending";
            this.dgvpending.RowHeadersWidth = 51;
            this.dgvpending.Size = new System.Drawing.Size(726, 262);
            this.dgvpending.TabIndex = 23;
            this.dgvpending.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvquery_CellContentDoubleClick);
            this.dgvpending.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpending_CellContentDoubleClick);
            this.dgvpending.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvpending_CellMouseDoubleClick);
            this.dgvpending.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvpending_MouseClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(8, 505);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 31);
            this.button2.TabIndex = 25;
            this.button2.Text = "UPDATE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button3.Location = new System.Drawing.Point(8, 454);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 31);
            this.button3.TabIndex = 26;
            this.button3.Text = "ADD AS CLOSED";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtemail
            // 
            this.txtemail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(68, 101);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(223, 25);
            this.txtemail.TabIndex = 28;
            // 
            // useremail
            // 
            this.useremail.AutoSize = true;
            this.useremail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useremail.Location = new System.Drawing.Point(5, 106);
            this.useremail.Name = "useremail";
            this.useremail.Size = new System.Drawing.Size(52, 17);
            this.useremail.TabIndex = 27;
            this.useremail.Text = "U email";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Yellow;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button4.Location = new System.Drawing.Point(159, 454);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 31);
            this.button4.TabIndex = 29;
            this.button4.Text = "Add IN PENDING";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 279);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "pending querys";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 580);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Devloped by Vaibhav Dwivedi";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(158, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 31);
            this.button1.TabIndex = 32;
            this.button1.Text = "CLOSE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // queryfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 592);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.useremail);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvpending);
            this.Controls.Add(this.dgvquery);
            this.Controls.Add(this.textsoln);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textqry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtu_Contact);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.txtu_Name);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "queryfrm";
            this.Text = "query";
            this.Load += new System.EventHandler(this.queryfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvquery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpending)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtu_Name;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtu_Contact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textqry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textsoln;
        private System.Windows.Forms.DataGridView dgvquery;
        private System.Windows.Forms.DataGridView dgvpending;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label useremail;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}