namespace RomanNumeralConverter
{
    partial class Form_numeralConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_numeralConverter));
            this.textBox_roman = new System.Windows.Forms.TextBox();
            this.label_roman = new System.Windows.Forms.Label();
            this.label_arabic = new System.Windows.Forms.Label();
            this.textBox_arabic = new System.Windows.Forms.TextBox();
            this.checkBox_strictMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_roman
            // 
            this.textBox_roman.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_roman.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_roman.Location = new System.Drawing.Point(12, 29);
            this.textBox_roman.Name = "textBox_roman";
            this.textBox_roman.Size = new System.Drawing.Size(376, 26);
            this.textBox_roman.TabIndex = 0;
            this.textBox_roman.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_roman_KeyPress);
            this.textBox_roman.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_roman_KeyUp);
            // 
            // label_roman
            // 
            this.label_roman.AutoSize = true;
            this.label_roman.Location = new System.Drawing.Point(13, 13);
            this.label_roman.Name = "label_roman";
            this.label_roman.Size = new System.Drawing.Size(41, 13);
            this.label_roman.TabIndex = 1;
            this.label_roman.Text = "Roman";
            // 
            // label_arabic
            // 
            this.label_arabic.AutoSize = true;
            this.label_arabic.Location = new System.Drawing.Point(13, 78);
            this.label_arabic.Name = "label_arabic";
            this.label_arabic.Size = new System.Drawing.Size(81, 13);
            this.label_arabic.TabIndex = 3;
            this.label_arabic.Text = "Arabic (0–4999)";
            // 
            // textBox_arabic
            // 
            this.textBox_arabic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_arabic.Location = new System.Drawing.Point(12, 94);
            this.textBox_arabic.Name = "textBox_arabic";
            this.textBox_arabic.Size = new System.Drawing.Size(376, 26);
            this.textBox_arabic.TabIndex = 2;
            this.textBox_arabic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_arabic_KeyPress);
            this.textBox_arabic.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_arabic_KeyUp);
            // 
            // checkBox_strictMode
            // 
            this.checkBox_strictMode.AutoSize = true;
            this.checkBox_strictMode.Checked = true;
            this.checkBox_strictMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_strictMode.Location = new System.Drawing.Point(308, 12);
            this.checkBox_strictMode.Name = "checkBox_strictMode";
            this.checkBox_strictMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_strictMode.Size = new System.Drawing.Size(80, 17);
            this.checkBox_strictMode.TabIndex = 5;
            this.checkBox_strictMode.Text = "Strict Mode";
            this.checkBox_strictMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_strictMode.UseVisualStyleBackColor = true;
            // 
            // Form_numeralConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 135);
            this.Controls.Add(this.checkBox_strictMode);
            this.Controls.Add(this.label_arabic);
            this.Controls.Add(this.textBox_arabic);
            this.Controls.Add(this.label_roman);
            this.Controls.Add(this.textBox_roman);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_numeralConverter";
            this.Text = "Numeral Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_roman;
        private System.Windows.Forms.Label label_roman;
        private System.Windows.Forms.Label label_arabic;
        private System.Windows.Forms.TextBox textBox_arabic;
        private System.Windows.Forms.CheckBox checkBox_strictMode;
    }
}

