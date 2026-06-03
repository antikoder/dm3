namespace WindowsFormsApp.Forms
{
    partial class ProductListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._userLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this._searchBox = new System.Windows.Forms.TextBox();
            this.supplierLabel = new System.Windows.Forms.Label();
            this._supplierFilter = new System.Windows.Forms.ComboBox();
            this.sortLabel = new System.Windows.Forms.Label();
            this._sortBox = new System.Windows.Forms.ComboBox();
            this._grid = new System.Windows.Forms.DataGridView();
            this._addButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._ordersButton = new System.Windows.Forms.Button();
            this._logoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();

            this._userLabel.AutoSize = true;
            this._userLabel.Location = new System.Drawing.Point(10, 10);
            this._userLabel.Name = "_userLabel";
            this._userLabel.Text = "";

            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(10, 45);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Text = "Поиск:";

            this._searchBox.Location = new System.Drawing.Point(90, 42);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(200, 27);
            this._searchBox.TextChanged += new System.EventHandler(this.Filter_Changed);

            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Location = new System.Drawing.Point(310, 45);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Text = "Поставщик:";

            this._supplierFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._supplierFilter.Location = new System.Drawing.Point(420, 42);
            this._supplierFilter.Name = "_supplierFilter";
            this._supplierFilter.Size = new System.Drawing.Size(180, 28);
            this._supplierFilter.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this.sortLabel.AutoSize = true;
            this.sortLabel.Location = new System.Drawing.Point(620, 45);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Text = "Сортировка:";

            this._sortBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._sortBox.Items.AddRange(new object[] {
            "Без сортировки",
            "Кол-во: по возрастанию",
            "Кол-во: по убыванию"});
            this._sortBox.Location = new System.Drawing.Point(745, 42);
            this._sortBox.Name = "_sortBox";
            this._sortBox.Size = new System.Drawing.Size(200, 28);
            this._sortBox.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14F);
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14F);
            this._grid.Location = new System.Drawing.Point(10, 85);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 28;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(960, 460);
            this._grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);

            this._addButton.Location = new System.Drawing.Point(10, 555);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(150, 30);
            this._addButton.Text = "Добавить";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);

            this._deleteButton.Location = new System.Drawing.Point(170, 555);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(150, 30);
            this._deleteButton.Text = "Удалить";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);

            this._ordersButton.Location = new System.Drawing.Point(330, 555);
            this._ordersButton.Name = "_ordersButton";
            this._ordersButton.Size = new System.Drawing.Size(150, 30);
            this._ordersButton.Text = "Заказы";
            this._ordersButton.UseVisualStyleBackColor = true;
            this._ordersButton.Click += new System.EventHandler(this.OrdersButton_Click);

            this._logoutButton.Location = new System.Drawing.Point(820, 555);
            this._logoutButton.Name = "_logoutButton";
            this._logoutButton.Size = new System.Drawing.Size(150, 30);
            this._logoutButton.Text = "Выход";
            this._logoutButton.UseVisualStyleBackColor = true;
            this._logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);

            this.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.ClientSize = new System.Drawing.Size(984, 600);
            this.Controls.Add(this._logoutButton);
            this.Controls.Add(this._ordersButton);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._sortBox);
            this.Controls.Add(this.sortLabel);
            this.Controls.Add(this._supplierFilter);
            this.Controls.Add(this.supplierLabel);
            this.Controls.Add(this._searchBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this._userLabel);
            this.Name = "ProductListForm";
            this.Text = "Товары";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label _userLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox _searchBox;
        private System.Windows.Forms.Label supplierLabel;
        private System.Windows.Forms.ComboBox _supplierFilter;
        private System.Windows.Forms.Label sortLabel;
        private System.Windows.Forms.ComboBox _sortBox;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Button _ordersButton;
        private System.Windows.Forms.Button _logoutButton;
    }
}
