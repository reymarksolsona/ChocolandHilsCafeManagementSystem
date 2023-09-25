
namespace Main.Forms.AttendanceTerminal
{
    partial class FrmConfirmation
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
            this.components = new System.ComponentModel.Container();
            this.PicBoxConfirmationImg = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxConfirmationImg)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBoxConfirmationImg
            // 
            this.PicBoxConfirmationImg.Location = new System.Drawing.Point(12, 12);
            this.PicBoxConfirmationImg.Name = "PicBoxConfirmationImg";
            this.PicBoxConfirmationImg.Size = new System.Drawing.Size(119, 105);
            this.PicBoxConfirmationImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicBoxConfirmationImg.TabIndex = 0;
            this.PicBoxConfirmationImg.TabStop = false;
            // 
            // FrmConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(144, 124);
            this.Controls.Add(this.PicBoxConfirmationImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfirmation";
            this.Load += new System.EventHandler(this.FrmConfirmation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxConfirmationImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBoxConfirmationImg;
        private System.Windows.Forms.Timer timer1;
    }
}