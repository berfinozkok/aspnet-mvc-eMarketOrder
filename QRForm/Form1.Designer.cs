namespace QRForm
{
    partial class BarcodeQRGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Barcode = new System.Windows.Forms.Label();
            this.BarcodeTextBox = new System.Windows.Forms.TextBox();
            this.BarcodeButton = new System.Windows.Forms.Button();
            this.QRButton = new System.Windows.Forms.Button();
            this.QRTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Barcode
            // 
            this.Barcode.AutoSize = true;
            this.Barcode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Barcode.Location = new System.Drawing.Point(28, 38);
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new System.Drawing.Size(104, 26);
            this.Barcode.TabIndex = 0;
            this.Barcode.Text = "Barcode";
            this.Barcode.Click += new System.EventHandler(this.label1_Click);
            // 
            // BarcodeTextBox
            // 
            this.BarcodeTextBox.Location = new System.Drawing.Point(161, 35);
            this.BarcodeTextBox.Name = "BarcodeTextBox";
            this.BarcodeTextBox.Size = new System.Drawing.Size(414, 31);
            this.BarcodeTextBox.TabIndex = 1;
            this.BarcodeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BarcodeButton
            // 
            this.BarcodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BarcodeButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BarcodeButton.Location = new System.Drawing.Point(615, 36);
            this.BarcodeButton.Name = "BarcodeButton";
            this.BarcodeButton.Size = new System.Drawing.Size(135, 37);
            this.BarcodeButton.TabIndex = 2;
            this.BarcodeButton.Text = "Generate";
            this.BarcodeButton.UseVisualStyleBackColor = true;
            this.BarcodeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // QRButton
            // 
            this.QRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QRButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QRButton.Location = new System.Drawing.Point(615, 94);
            this.QRButton.Name = "QRButton";
            this.QRButton.Size = new System.Drawing.Size(135, 41);
            this.QRButton.TabIndex = 5;
            this.QRButton.Text = "Generate";
            this.QRButton.UseVisualStyleBackColor = true;
            this.QRButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // QRTextBox
            // 
            this.QRTextBox.Location = new System.Drawing.Point(161, 93);
            this.QRTextBox.Name = "QRTextBox";
            this.QRTextBox.Size = new System.Drawing.Size(414, 31);
            this.QRTextBox.TabIndex = 4;
            this.QRTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(28, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "QRCode";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.Location = new System.Drawing.Point(28, 151);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(722, 232);
            this.resultPictureBox.TabIndex = 6;
            this.resultPictureBox.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(313, 412);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(135, 45);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // BarcodeQRGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.QRButton);
            this.Controls.Add(this.QRTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BarcodeButton);
            this.Controls.Add(this.BarcodeTextBox);
            this.Controls.Add(this.Barcode);
            this.Name = "BarcodeQRGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode & QR Generator";
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Barcode;
        private TextBox BarcodeTextBox;
        private Button BarcodeButton;
        private Button QRButton;
        private TextBox QRTextBox;
        private Label label1;
        private PictureBox resultPictureBox;
        private Button SaveButton;
    }
}