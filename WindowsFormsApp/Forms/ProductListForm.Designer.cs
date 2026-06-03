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
            this._addButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._ordersButton = new System.Windows.Forms.Button();
            this._logoutButton = new System.Windows.Forms.Button();
            this._userLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this._searchBox = new System.Windows.Forms.TextBox();
            this.supplierLabel = new System.Windows.Forms.Label();
            this._supplierFilter = new System.Windows.Forms.ComboBox();
            this.sortLabel = new System.Windows.Forms.Label();
            this._sortBox = new System.Windows.Forms.ComboBox();
            this._flow = new System.Windows.Forms.FlowLayoutPanel();
            this._emptyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this._addButton.Location = new System.Drawing.Point(10, 10);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(150, 32);
            this._addButton.Text = "Добавить товар";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);

            this._deleteButton.Location = new System.Drawing.Point(170, 10);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(150, 32);
            this._deleteButton.Text = "Удалить товар";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);

            this._ordersButton.Location = new System.Drawing.Point(330, 10);
            this._ordersButton.Name = "_ordersButton";
            this._ordersButton.Size = new System.Drawing.Size(150, 32);
            this._ordersButton.Text = "Заказы";
            this._ordersButton.UseVisualStyleBackColor = true;
            this._ordersButton.Click += new System.EventHandler(this.OrdersButton_Click);

            this._logoutButton.Location = new System.Drawing.Point(840, 10);
            this._logoutButton.Name = "_logoutButton";
            this._logoutButton.Size = new System.Drawing.Size(150, 32);
            this._logoutButton.Text = "Выйти";
            this._logoutButton.UseVisualStyleBackColor = true;
            this._logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);

            this._userLabel.AutoSize = false;
            this._userLabel.Location = new System.Drawing.Point(490, 15);
            this._userLabel.Name = "_userLabel";
            this._userLabel.Size = new System.Drawing.Size(340, 25);
            this._userLabel.Text = "";
            this._userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(10, 60);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Text = "Поиск";

            this._searchBox.Location = new System.Drawing.Point(10, 85);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(300, 27);
            this._searchBox.TextChanged += new System.EventHandler(this.Filter_Changed);

            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Location = new System.Drawing.Point(330, 60);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Text = "Поставщик";

            this._supplierFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._supplierFilter.Location = new System.Drawing.Point(330, 85);
            this._supplierFilter.Name = "_supplierFilter";
            this._supplierFilter.Size = new System.Drawing.Size(300, 28);
            this._supplierFilter.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this.sortLabel.AutoSize = true;
            this.sortLabel.Location = new System.Drawing.Point(650, 60);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Text = "Сортировка";

            this._sortBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._sortBox.Items.AddRange(new object[] {
            "Без сортировки",
            "Кол-во: по возрастанию",
            "Кол-во: по убыванию"});
            this._sortBox.Location = new System.Drawing.Point(650, 85);
            this._sortBox.Name = "_sortBox";
            this._sortBox.Size = new System.Drawing.Size(340, 28);
            this._sortBox.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this._flow.AutoScroll = true;
            this._flow.BackColor = System.Drawing.Color.WhiteSmoke;
            this._flow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flow.Location = new System.Drawing.Point(10, 130);
            this._flow.Name = "_flow";
            this._flow.Padding = new System.Windows.Forms.Padding(5);
            this._flow.Size = new System.Drawing.Size(980, 460);
            this._flow.WrapContents = false;

            this._emptyLabel.AutoSize = true;
            this._emptyLabel.Location = new System.Drawing.Point(20, 150);
            this._emptyLabel.Name = "_emptyLabel";
            this._emptyLabel.Text = "Нет данных";
            this._emptyLabel.Visible = false;

            this.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this._emptyLabel);
            this.Controls.Add(this._flow);
            this.Controls.Add(this._sortBox);
            this.Controls.Add(this.sortLabel);
            this.Controls.Add(this._supplierFilter);
            this.Controls.Add(this.supplierLabel);
            this.Controls.Add(this._searchBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this._userLabel);
            this.Controls.Add(this._logoutButton);
            this.Controls.Add(this._ordersButton);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._addButton);
            this.Name = "ProductListForm";
            this.Text = "Список товаров";
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
        private System.Windows.Forms.FlowLayoutPanel _flow;
        private System.Windows.Forms.Label _emptyLabel;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Button _ordersButton;
        private System.Windows.Forms.Button _logoutButton;
    }
}
