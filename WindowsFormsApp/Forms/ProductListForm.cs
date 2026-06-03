using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp.Models;

namespace WindowsFormsApp.Forms
{
    public partial class ProductListForm : Form
    {
        private List<Product> _allProducts = new List<Product>();
        private static ProductEditForm _editForm;
        private ProductCard _selectedCard;

        public ProductListForm()
        {
            InitializeComponent();
            ApplyRoleVisibility();
            LoadProducts();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void ApplyRoleVisibility()
        {
            if (AppSession.IsGuest)
                _userLabel.Text = "Гость";
            else
                _userLabel.Text = AppSession.CurrentUser.FullName + " (" + AppSession.CurrentUser.RoleName + ")";

            bool canFilter = AppSession.IsManager || AppSession.IsAdmin;
            _searchBox.Enabled = canFilter;
            _supplierFilter.Enabled = canFilter;
            _sortBox.Enabled = canFilter;

            _addButton.Visible = AppSession.IsAdmin;
            _deleteButton.Visible = AppSession.IsAdmin;
            _ordersButton.Visible = AppSession.IsManager || AppSession.IsAdmin;
        }

        private void LoadProducts()
        {
            try
            {
                string sql = "SELECT p.ProductId, p.ProductName, p.Description, p.CategoryId, c.CategoryName, p.ManufacturerId, m.ManufacturerName, p.SupplierId, s.SupplierName, p.UnitId, u.UnitName, p.Price, p.Quantity, p.Discount, p.ImagePath FROM Products p INNER JOIN Categories c ON p.CategoryId = c.CategoryId INNER JOIN Manufacturers m ON p.ManufacturerId = m.ManufacturerId INNER JOIN Suppliers s ON p.SupplierId = s.SupplierId INNER JOIN Units u ON p.UnitId = u.UnitId ORDER BY p.ProductId;";

                DataTable table = DatabaseHelper.ExecuteQuery(sql);
                _allProducts.Clear();
                foreach (DataRow r in table.Rows)
                {
                    Product p = new Product();
                    p.ProductId = (int)r["ProductId"];
                    p.ProductName = r["ProductName"].ToString();
                    p.Description = r["Description"] == DBNull.Value ? "" : r["Description"].ToString();
                    p.CategoryId = (int)r["CategoryId"];
                    p.CategoryName = r["CategoryName"].ToString();
                    p.ManufacturerId = (int)r["ManufacturerId"];
                    p.ManufacturerName = r["ManufacturerName"].ToString();
                    p.SupplierId = (int)r["SupplierId"];
                    p.SupplierName = r["SupplierName"].ToString();
                    p.UnitId = (int)r["UnitId"];
                    p.UnitName = r["UnitName"].ToString();
                    p.Price = (decimal)r["Price"];
                    p.Quantity = (int)r["Quantity"];
                    p.Discount = (int)r["Discount"];
                    p.ImagePath = r["ImagePath"] == DBNull.Value ? null : r["ImagePath"].ToString();
                    _allProducts.Add(p);
                }

                ReloadSupplierFilter();
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки товаров: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadSupplierFilter()
        {
            object prev = _supplierFilter.SelectedItem;
            _supplierFilter.Items.Clear();
            _supplierFilter.Items.Add("Все поставщики");
            List<string> added = new List<string>();
            foreach (Product p in _allProducts)
            {
                if (!added.Contains(p.SupplierName))
                {
                    added.Add(p.SupplierName);
                    _supplierFilter.Items.Add(p.SupplierName);
                }
            }
            if (prev != null && _supplierFilter.Items.Contains(prev))
                _supplierFilter.SelectedItem = prev;
            else
                _supplierFilter.SelectedIndex = 0;
        }

        private void RefreshList()
        {
            List<Product> data = new List<Product>();

            if (AppSession.IsManager || AppSession.IsAdmin)
            {
                string query = _searchBox.Text.Trim().ToLower();
                string supplier = "";
                if (_supplierFilter.SelectedItem != null)
                    supplier = _supplierFilter.SelectedItem.ToString();

                foreach (Product p in _allProducts)
                {
                    if (query != "")
                    {
                        string all = p.ProductName + " " + p.Description + " " + p.CategoryName + " " +
                                     p.ManufacturerName + " " + p.SupplierName + " " + p.UnitName;
                        if (!all.ToLower().Contains(query))
                            continue;
                    }

                    if (supplier != "" && supplier != "Все поставщики" && p.SupplierName != supplier)
                        continue;

                    data.Add(p);
                }

                if (_sortBox.SelectedIndex == 1)
                    data.Sort(delegate (Product a, Product b) { return a.Quantity - b.Quantity; });
                else if (_sortBox.SelectedIndex == 2)
                    data.Sort(delegate (Product a, Product b) { return b.Quantity - a.Quantity; });
            }
            else
            {
                foreach (Product p in _allProducts)
                    data.Add(p);
            }

            RenderCards(data);
        }

        private void RenderCards(List<Product> list)
        {
            _selectedCard = null;
            _flow.SuspendLayout();
            foreach (Control c in _flow.Controls)
                c.Dispose();
            _flow.Controls.Clear();

            foreach (Product p in list)
            {
                ProductCard card = new ProductCard(p);
                card.Width = _flow.ClientSize.Width - 25;
                card.Click += Card_Click;
                WireClick(card);
                card.CardDoubleClicked += Card_DoubleClicked;
                _flow.Controls.Add(card);
            }

            _flow.ResumeLayout();
            _emptyLabel.Visible = list.Count == 0;
        }

        private void WireClick(Control root)
        {
            foreach (Control c in root.Controls)
            {
                c.Click += Card_Click;
                WireClick(c);
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            ProductCard card = sender as ProductCard;
            if (card == null && sender is Control)
                card = FindParentCard((Control)sender);
            if (card == null) return;

            if (_selectedCard != null && _selectedCard != card)
                _selectedCard.BorderStyle = BorderStyle.FixedSingle;
            _selectedCard = card;
            card.BorderStyle = BorderStyle.Fixed3D;
        }

        private ProductCard FindParentCard(Control c)
        {
            while (c != null && !(c is ProductCard))
                c = c.Parent;
            return c as ProductCard;
        }

        private void Card_DoubleClicked(object sender, EventArgs e)
        {
            if (!AppSession.IsAdmin)
            {
                MessageBox.Show("Редактирование доступно только администратору.", "Доступ запрещён",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductCard card = sender as ProductCard;
            if (card != null && card.Product != null)
                OpenEditForm(card.Product);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            OpenEditForm(null);
        }

        private void OpenEditForm(Product product)
        {
            if (_editForm != null && !_editForm.IsDisposed)
            {
                MessageBox.Show("Окно редактирования уже открыто.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _editForm.Activate();
                return;
            }

            _editForm = new ProductEditForm(product);
            _editForm.FormClosed += EditForm_Closed;
            _editForm.ShowDialog(this);
        }

        private void EditForm_Closed(object sender, FormClosedEventArgs e)
        {
            _editForm = null;
            LoadProducts();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_selectedCard == null || _selectedCard.Product == null)
            {
                MessageBox.Show("Выберите товар для удаления (один клик по карточке).", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Product product = _selectedCard.Product;

            if (MessageBox.Show("Удалить товар \"" + product.ProductName + "\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                int count = (int)DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM OrderItems WHERE ProductId = @id;",
                    new SqlParameter("@id", product.ProductId));

                if (count > 0)
                {
                    MessageBox.Show("Этот товар присутствует в заказах и не может быть удалён.",
                        "Удаление невозможно", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM Products WHERE ProductId = @id;",
                    new SqlParameter("@id", product.ProductId));

                if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                {
                    try { File.Delete(product.ImagePath); }
                    catch { }
                }

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            OrderListForm form = new OrderListForm();
            form.ShowDialog(this);
        }
    }
}
