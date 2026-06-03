namespace WindowsFormsApp.Forms
{
    partial class ProductCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._photo = new System.Windows.Forms.PictureBox();
            this._titleLabel = new System.Windows.Forms.Label();
            this._descLabel = new System.Windows.Forms.Label();
            this._manufLabel = new System.Windows.Forms.Label();
            this._suppLabel = new System.Windows.Forms.Label();
            this._priceCaption = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._finalPriceLabel = new System.Windows.Forms.Label();
            this._unitLabel = new System.Windows.Forms.Label();
            this._qtyLabel = new System.Windows.Forms.Label();
            this._discountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._photo)).BeginInit();
            this.SuspendLayout();

            this._photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._photo.Location = new System.Drawing.Point(10, 10);
            this._photo.Name = "_photo";
            this._photo.Size = new System.Drawing.Size(140, 140);
            this._photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._photo.TabStop = false;

            this._titleLabel.AutoSize = true;
            this._titleLabel.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this._titleLabel.Location = new System.Drawing.Point(165, 10);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Text = "";

            this._descLabel.AutoSize = true;
            this._descLabel.Location = new System.Drawing.Point(165, 40);
            this._descLabel.MaximumSize = new System.Drawing.Size(550, 0);
            this._descLabel.Name = "_descLabel";
            this._descLabel.Text = "";

            this._manufLabel.AutoSize = true;
            this._manufLabel.Location = new System.Drawing.Point(165, 65);
            this._manufLabel.Name = "_manufLabel";
            this._manufLabel.Text = "";

            this._suppLabel.AutoSize = true;
            this._suppLabel.Location = new System.Drawing.Point(165, 88);
            this._suppLabel.Name = "_suppLabel";
            this._suppLabel.Text = "";

            this._priceCaption.AutoSize = true;
            this._priceCaption.Location = new System.Drawing.Point(165, 111);
            this._priceCaption.Name = "_priceCaption";
            this._priceCaption.Text = "Цена:";

            this._priceLabel.AutoSize = true;
            this._priceLabel.Location = new System.Drawing.Point(225, 111);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Text = "";

            this._finalPriceLabel.AutoSize = true;
            this._finalPriceLabel.Location = new System.Drawing.Point(325, 111);
            this._finalPriceLabel.Name = "_finalPriceLabel";
            this._finalPriceLabel.Text = "";

            this._unitLabel.AutoSize = true;
            this._unitLabel.Location = new System.Drawing.Point(450, 65);
            this._unitLabel.Name = "_unitLabel";
            this._unitLabel.Text = "";

            this._qtyLabel.AutoSize = true;
            this._qtyLabel.Location = new System.Drawing.Point(450, 88);
            this._qtyLabel.Name = "_qtyLabel";
            this._qtyLabel.Text = "";

            this._discountLabel.AutoSize = false;
            this._discountLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._discountLabel.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this._discountLabel.Location = new System.Drawing.Point(750, 10);
            this._discountLabel.Name = "_discountLabel";
            this._discountLabel.Size = new System.Drawing.Size(120, 140);
            this._discountLabel.Text = "";
            this._discountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._discountLabel);
            this.Controls.Add(this._qtyLabel);
            this.Controls.Add(this._unitLabel);
            this.Controls.Add(this._finalPriceLabel);
            this.Controls.Add(this._priceLabel);
            this.Controls.Add(this._priceCaption);
            this.Controls.Add(this._suppLabel);
            this.Controls.Add(this._manufLabel);
            this.Controls.Add(this._descLabel);
            this.Controls.Add(this._titleLabel);
            this.Controls.Add(this._photo);
            this.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(880, 160);
            ((System.ComponentModel.ISupportInitialize)(this._photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox _photo;
        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _descLabel;
        private System.Windows.Forms.Label _manufLabel;
        private System.Windows.Forms.Label _suppLabel;
        private System.Windows.Forms.Label _priceCaption;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _finalPriceLabel;
        private System.Windows.Forms.Label _unitLabel;
        private System.Windows.Forms.Label _qtyLabel;
        private System.Windows.Forms.Label _discountLabel;
    }
}
