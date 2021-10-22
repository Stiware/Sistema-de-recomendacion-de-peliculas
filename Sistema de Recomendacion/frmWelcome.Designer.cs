
namespace Sistema_de_Recomendacion
{
    partial class frmWelcome
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
            this.btnProfile1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbProfile1 = new System.Windows.Forms.PictureBox();
            this.pbProfile2 = new System.Windows.Forms.PictureBox();
            this.pbProfile3 = new System.Windows.Forms.PictureBox();
            this.btnProfile2 = new System.Windows.Forms.Button();
            this.btnProfile3 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProfile1
            // 
            this.btnProfile1.Location = new System.Drawing.Point(142, 163);
            this.btnProfile1.Name = "btnProfile1";
            this.btnProfile1.Size = new System.Drawing.Size(75, 23);
            this.btnProfile1.TabIndex = 0;
            this.btnProfile1.Text = "Tommy";
            this.btnProfile1.UseVisualStyleBackColor = true;
            this.btnProfile1.Click += new System.EventHandler(this.btnProfile1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(151, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido a mi sistema de recomendación de peliculas";
            // 
            // pbProfile1
            // 
            this.pbProfile1.Location = new System.Drawing.Point(133, 68);
            this.pbProfile1.Name = "pbProfile1";
            this.pbProfile1.Size = new System.Drawing.Size(112, 89);
            this.pbProfile1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfile1.TabIndex = 2;
            this.pbProfile1.TabStop = false;
            // 
            // pbProfile2
            // 
            this.pbProfile2.Location = new System.Drawing.Point(302, 68);
            this.pbProfile2.Name = "pbProfile2";
            this.pbProfile2.Size = new System.Drawing.Size(112, 89);
            this.pbProfile2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfile2.TabIndex = 3;
            this.pbProfile2.TabStop = false;
            // 
            // pbProfile3
            // 
            this.pbProfile3.Location = new System.Drawing.Point(467, 68);
            this.pbProfile3.Name = "pbProfile3";
            this.pbProfile3.Size = new System.Drawing.Size(112, 89);
            this.pbProfile3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfile3.TabIndex = 4;
            this.pbProfile3.TabStop = false;
            // 
            // btnProfile2
            // 
            this.btnProfile2.Location = new System.Drawing.Point(317, 163);
            this.btnProfile2.Name = "btnProfile2";
            this.btnProfile2.Size = new System.Drawing.Size(75, 23);
            this.btnProfile2.TabIndex = 5;
            this.btnProfile2.Text = "May";
            this.btnProfile2.UseVisualStyleBackColor = true;
            this.btnProfile2.Click += new System.EventHandler(this.btnProfile2_Click);
            // 
            // btnProfile3
            // 
            this.btnProfile3.Location = new System.Drawing.Point(489, 163);
            this.btnProfile3.Name = "btnProfile3";
            this.btnProfile3.Size = new System.Drawing.Size(75, 23);
            this.btnProfile3.TabIndex = 6;
            this.btnProfile3.Text = "Willy";
            this.btnProfile3.UseVisualStyleBackColor = true;
            this.btnProfile3.Click += new System.EventHandler(this.btnProfile3_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(664, 183);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(751, 218);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProfile3);
            this.Controls.Add(this.btnProfile2);
            this.Controls.Add(this.pbProfile3);
            this.Controls.Add(this.pbProfile2);
            this.Controls.Add(this.pbProfile1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProfile1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWelcome";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido";
            this.Load += new System.EventHandler(this.frmWelcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProfile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbProfile1;
        private System.Windows.Forms.PictureBox pbProfile2;
        private System.Windows.Forms.PictureBox pbProfile3;
        private System.Windows.Forms.Button btnProfile2;
        private System.Windows.Forms.Button btnProfile3;
        private System.Windows.Forms.Button btnClose;
    }
}