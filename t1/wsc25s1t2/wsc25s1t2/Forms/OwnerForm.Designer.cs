
namespace wsc25s1t2.Forms
{
    partial class OwnerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ownerNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 0;
            // 
            // ownerNameLabel
            // 
            this.ownerNameLabel.AutoSize = true;
            this.ownerNameLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ownerNameLabel.Location = new System.Drawing.Point(12, 9);
            this.ownerNameLabel.Name = "ownerNameLabel";
            this.ownerNameLabel.Size = new System.Drawing.Size(87, 32);
            this.ownerNameLabel.TabIndex = 1;
            this.ownerNameLabel.Text = "label2";
            // 
            // OwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 389);
            this.Controls.Add(this.ownerNameLabel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "OwnerForm";
            this.Text = "ownerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ownerNameLabel;
    }
}