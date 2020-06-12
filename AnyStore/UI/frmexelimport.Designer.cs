namespace AnyStore.UI
{
    partial class frmexelimport
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.locatefile = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-8, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 336);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // locatefile
            // 
            this.locatefile.Location = new System.Drawing.Point(12, 12);
            this.locatefile.Name = "locatefile";
            this.locatefile.Size = new System.Drawing.Size(175, 44);
            this.locatefile.TabIndex = 1;
            this.locatefile.Text = "file locator";
            this.locatefile.UseVisualStyleBackColor = true;
            this.locatefile.Click += new System.EventHandler(this.locatefile_Click);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(203, 12);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(169, 44);
            this.import.TabIndex = 2;
            this.import.Text = "import company";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "import user";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(578, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 44);
            this.button2.TabIndex = 4;
            this.button2.Text = "import query";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmexelimport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.import);
            this.Controls.Add(this.locatefile);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmexelimport";
            this.Text = "frmexelimport";
            this.Load += new System.EventHandler(this.frmexelimport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button locatefile;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}