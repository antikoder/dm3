using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp.Models;

namespace WindowsFormsApp.Forms
{
    public partial class ProductCard : UserControl
    {
        public event EventHandler CardDoubleClicked;
        public Product Product { get; private set; }

        public ProductCard(Product product)
        {
            InitializeComponent();
            Bind(product);
            WireDoubleClick(this);
        }

        private void WireDoubleClick(Control root)
        {
            root.DoubleClick += Card_DoubleClick;
            foreach (Control c in root.Controls)
                WireDoubleClick(c);
        }

        private void Card_DoubleClick(object sender, EventArgs e)
        {
            if (CardDoubleClicked != null)
                CardDoubleClicked(this, EventArgs.Empty);
        }

        private void Bind(Product p)
        {
            Product = p;

            _titleLabel.Text = p.CategoryName + " | " + p.ProductName;

            string descText;
            if (string.IsNullOrEmpty(p.Description))
                descText = "—";
            else
                descText = p.Description;
            _descLabel.Text = "Описание: " + descText;

            _manufLabel.Text = "Производитель: " + p.ManufacturerName;
            _suppLabel.Text = "Поставщик: " + p.SupplierName;
            _unitLabel.Text = "Единица измерения: " + p.UnitName;
            _qtyLabel.Text = "Количество на складе: " + p.Quantity;
            _discountLabel.Text = p.Discount + "%";

            if (p.Discount > 0)
            {
                _priceLabel.Text = p.Price.ToString("N2");
                _priceLabel.Font = new Font(_priceLabel.Font, FontStyle.Strikeout);
                _priceLabel.ForeColor = Color.Red;
                _finalPriceLabel.Text = p.FinalPrice.ToString("N2");
                _finalPriceLabel.ForeColor = Color.Black;
                _finalPriceLabel.Visible = true;
                _priceCaption.Text = "Цена:";
            }
            else
            {
                _priceLabel.Text = p.Price.ToString("N2");
                _priceLabel.Font = new Font(_priceLabel.Font, FontStyle.Regular);
                _priceLabel.ForeColor = Color.Black;
                _finalPriceLabel.Visible = false;
                _priceCaption.Text = "Цена:";
            }

            if (p.Quantity == 0)
                BackColor = Color.LightBlue;
            else if (p.Discount > 15)
                BackColor = Color.FromArgb(0x2E, 0x8B, 0x57);
            else
                BackColor = Color.White;

            try
            {
                if (!string.IsNullOrEmpty(p.ImagePath) && File.Exists(p.ImagePath))
                    _photo.Image = Image.FromFile(p.ImagePath);
                else
                    _photo.Image = MakePlaceholder();
            }
            catch
            {
                _photo.Image = MakePlaceholder();
            }
        }

        private static Image MakePlaceholder()
        {
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Gainsboro);
                using (Font f = new Font("Times New Roman", 11F))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString("нет фото", f, Brushes.DimGray, new RectangleF(0, 0, 120, 120), sf);
                }
            }
            return bmp;
        }
    }
}
