namespace GraStatki
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
            this.lblNazwaGracza.Location = new System.Drawing.Point(532, 112);
            this.lblNazwaGracza.Name = "lblNazwaGracza";
            this.lblNazwaGracza.Size = new System.Drawing.Size(51, 17);
            this.lblNazwaGracza.TabIndex = 0;
            this.lblNazwaGracza.Text = "Gracz";
            // 
            // txtNazwaGracza
            // 
            this.txtNazwaGracza.Location = new System.Drawing.Point(509, 141);
            this.txtNazwaGracza.Name = "txtNazwaGracza";
            this.txtNazwaGracza.Size = new System.Drawing.Size(100, 20);
            this.txtNazwaGracza.TabIndex = 1;
            // 
            // txtInfo
            // 
            this.txtInfo.AutoSize = true;
            this.txtInfo.BackColor = System.Drawing.Color.Transparent;
            this.txtInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.txtInfo.Location = new System.Drawing.Point(511, 179);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(98, 13);
            this.txtInfo.TabIndex = 2;
            this.txtInfo.Text = "Podaj swoją nazwę";
            // 
            // btnObrot
            // 
            this.btnObrot.Location = new System.Drawing.Point(523, 262);
            this.btnObrot.Name = "btnObrot";
            this.btnObrot.Size = new System.Drawing.Size(75, 23);
            this.btnObrot.TabIndex = 3;
            this.btnObrot.Text = "Obróć";
            this.btnObrot.UseVisualStyleBackColor = true;
            this.btnObrot.Click += new System.EventHandler(this.btnObrot_Click);
            // 
            // btnDalej
            // 
            this.btnDalej.Location = new System.Drawing.Point(523, 306);
            this.btnDalej.Name = "btnDalej";
            this.btnDalej.Size = new System.Drawing.Size(75, 23);
            this.btnDalej.TabIndex = 4;
            this.btnDalej.Text = "Dalej";
            this.btnDalej.UseVisualStyleBackColor = true;
            this.btnDalej.Click += new System.EventHandler(this.btnDalej_Click);
            // 
            // planszaGracza
            // 
            this.planszaGracza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planszaGracza.Image = global::GraStatki.Properties.Resources.board;
            this.planszaGracza.Location = new System.Drawing.Point(36, 12);
            this.planszaGracza.Name = "planszaGracza";
            this.planszaGracza.Size = new System.Drawing.Size(400, 400);
            this.planszaGracza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.planszaGracza.TabIndex = 5;
            this.planszaGracza.TabStop = false;
            this.planszaGracza.Click += new System.EventHandler(this.planszaGracza_Click);
            this.planszaGracza.Paint += new System.Windows.Forms.PaintEventHandler(this.PlanszaGracza_Rysowanie);
            this.planszaGracza.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PlanszaGracza_PoruszanieMysza);
            // 
            // UstawienieStatkow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 448);
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

