﻿namespace GraStatki
{
    partial class UstawienieStatkow
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
            this.lblNazwaGracza = new System.Windows.Forms.Label();
            this.txtNazwaGracza = new System.Windows.Forms.TextBox();
            this.txtInfo = new System.Windows.Forms.Label();
            this.btnObrot = new System.Windows.Forms.Button();
            this.btnDalej = new System.Windows.Forms.Button();
            this.planszaGracza = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.planszaGracza)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNazwaGracza
            // 
            this.lblNazwaGracza.AutoSize = true;
            this.lblNazwaGracza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNazwaGracza.Location = new System.Drawing.Point(593, 91);
            this.lblNazwaGracza.Name = "lblNazwaGracza";
            this.lblNazwaGracza.Size = new System.Drawing.Size(51, 17);
            this.lblNazwaGracza.TabIndex = 0;
            this.lblNazwaGracza.Text = "Gracz";
            // 
            // txtNazwaGracza
            // 
            this.txtNazwaGracza.Location = new System.Drawing.Point(570, 120);
            this.txtNazwaGracza.Name = "txtNazwaGracza";
            this.txtNazwaGracza.Size = new System.Drawing.Size(100, 20);
            this.txtNazwaGracza.TabIndex = 1;
            // 
            // txtInfo
            // 
            this.txtInfo.AutoSize = true;
            this.txtInfo.BackColor = System.Drawing.Color.Transparent;
            this.txtInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.txtInfo.Location = new System.Drawing.Point(572, 158);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(98, 13);
            this.txtInfo.TabIndex = 2;
            this.txtInfo.Text = "Podaj swoją nazwę";
            // 
            // btnObrot
            // 
            this.btnObrot.Location = new System.Drawing.Point(584, 241);
            this.btnObrot.Name = "btnObrot";
            this.btnObrot.Size = new System.Drawing.Size(75, 23);
            this.btnObrot.TabIndex = 3;
            this.btnObrot.Text = "Obróć";
            this.btnObrot.UseVisualStyleBackColor = true;
            // 
            // btnDalej
            // 
            this.btnDalej.Location = new System.Drawing.Point(584, 285);
            this.btnDalej.Name = "btnDalej";
            this.btnDalej.Size = new System.Drawing.Size(75, 23);
            this.btnDalej.TabIndex = 4;
            this.btnDalej.Text = "Dalej";
            this.btnDalej.UseVisualStyleBackColor = true;
            // 
            // planszaGracza
            // 
            this.planszaGracza.Image = global::GraStatki.Properties.Resources.board;
            this.planszaGracza.Location = new System.Drawing.Point(36, 12);
            this.planszaGracza.Name = "planszaGracza";
            this.planszaGracza.Size = new System.Drawing.Size(450, 450);
            this.planszaGracza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.planszaGracza.TabIndex = 5;
            this.planszaGracza.TabStop = false;
            // 
            // UstawienieStatkow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 479);
            this.Controls.Add(this.planszaGracza);
            this.Controls.Add(this.btnDalej);
            this.Controls.Add(this.btnObrot);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txtNazwaGracza);
            this.Controls.Add(this.lblNazwaGracza);
            this.Name = "UstawienieStatkow";
            this.Text = "UstawienieStatkow";
            ((System.ComponentModel.ISupportInitialize)(this.planszaGracza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNazwaGracza;
        private System.Windows.Forms.TextBox txtNazwaGracza;
        private System.Windows.Forms.Label txtInfo;
        private System.Windows.Forms.Button btnObrot;
        private System.Windows.Forms.Button btnDalej;
        private System.Windows.Forms.PictureBox planszaGracza;
    }
}

