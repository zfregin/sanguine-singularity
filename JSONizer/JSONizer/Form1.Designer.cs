namespace JSONizer
{
    partial class Form1
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
            this.filenameTB = new System.Windows.Forms.RichTextBox();
            this.readFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.jsonTB = new System.Windows.Forms.RichTextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filenameTB
            // 
            this.filenameTB.Location = new System.Drawing.Point(58, 50);
            this.filenameTB.Name = "filenameTB";
            this.filenameTB.ReadOnly = true;
            this.filenameTB.Size = new System.Drawing.Size(523, 35);
            this.filenameTB.TabIndex = 0;
            this.filenameTB.Text = "";
            // 
            // readFileButton
            // 
            this.readFileButton.Location = new System.Drawing.Point(596, 50);
            this.readFileButton.Name = "readFileButton";
            this.readFileButton.Size = new System.Drawing.Size(124, 35);
            this.readFileButton.TabIndex = 1;
            this.readFileButton.Text = "Select File";
            this.readFileButton.UseVisualStyleBackColor = true;
            this.readFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // jsonTB
            // 
            this.jsonTB.Location = new System.Drawing.Point(58, 151);
            this.jsonTB.Name = "jsonTB";
            this.jsonTB.Size = new System.Drawing.Size(653, 253);
            this.jsonTB.TabIndex = 2;
            this.jsonTB.Text = "";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(293, 100);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(173, 35);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.jsonTB);
            this.Controls.Add(this.readFileButton);
            this.Controls.Add(this.filenameTB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox filenameTB;
        private System.Windows.Forms.Button readFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox jsonTB;
        private System.Windows.Forms.Button convertButton;
    }
}

