
namespace wsc25s2t1
{
    partial class MainForm
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
            this.Dgvpanel = new System.Windows.Forms.Panel();
            this.Clinicdgv = new System.Windows.Forms.DataGridView();
            this.ClinicTypeFilterComboBox = new System.Windows.Forms.ComboBox();
            this.Dgvpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clinicdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgvpanel
            // 
            this.Dgvpanel.Controls.Add(this.ClinicTypeFilterComboBox);
            this.Dgvpanel.Location = new System.Drawing.Point(5, 24);
            this.Dgvpanel.Name = "Dgvpanel";
            this.Dgvpanel.Size = new System.Drawing.Size(742, 476);
            this.Dgvpanel.TabIndex = 7;
            // 
            // Clinicdgv
            // 
            this.Clinicdgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Clinicdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Clinicdgv.Location = new System.Drawing.Point(14, 70);
            this.Clinicdgv.Name = "Clinicdgv";
            this.Clinicdgv.Size = new System.Drawing.Size(713, 418);
            this.Clinicdgv.TabIndex = 5;
            this.Clinicdgv.TabStop = false;
            this.Clinicdgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Clinicdgv_CellContentClick);
            // 
            // ClinicTypeFilterComboBox
            // 
            this.ClinicTypeFilterComboBox.FormattingEnabled = true;
            this.ClinicTypeFilterComboBox.Items.AddRange(new object[] {
            "s",
            "a",
            "b"});
            this.ClinicTypeFilterComboBox.Location = new System.Drawing.Point(9, 3);
            this.ClinicTypeFilterComboBox.Name = "ClinicTypeFilterComboBox";
            this.ClinicTypeFilterComboBox.Size = new System.Drawing.Size(121, 32);
            this.ClinicTypeFilterComboBox.TabIndex = 6;
            this.ClinicTypeFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.ClinicTypeFilterComboBox_SelectedIndexChanged_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(908, 540);
            this.Controls.Add(this.Clinicdgv);
            this.Controls.Add(this.Dgvpanel);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ForeColor = System.Drawing.Color.Coral;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Dgvpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Clinicdgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView Clinicdgv;
        private System.Windows.Forms.ComboBox ClinicTypeFilterComboBox;
        private System.Windows.Forms.Panel Dgvpanel;
    }
}

