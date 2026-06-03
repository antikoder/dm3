namespace WindowsFormsApp.Forms
{
    partial class OrderListForm
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
            this._editButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this._grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();

            this._addButton.Location = new System.Drawing.Point(10, 10);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(140, 30);
            this._addButton.Text = "Добавить";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);

            this._editButton.Location = new System.Drawing.Point(160, 10);
            this._editButton.Name = "_editButton";
            this._editButton.Size = new System.Drawing.Size(140, 30);
            this._editButton.Text = "Изменить";
            this._editButton.UseVisualStyleBackColor = true;
            this._editButton.Click += new System.EventHandler(this.EditButton_Click);

            this._deleteButton.Location = new System.Drawing.Point(310, 10);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(140, 30);
            this._deleteButton.Text = "Удалить";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);

            this._closeButton.Location = new System.Drawing.Point(630, 10);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(140, 30);
            this._closeButton.Text = "Закрыть";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14F);
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14F);
            this._grid.Location = new System.Drawing.Point(10, 55);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 28;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(760, 400);
            this._grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);

            this.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.ClientSize = new System.Drawing.Size(784, 465);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._editButton);
            this.Controls.Add(this._addButton);
            this.Name = "OrderListForm";
            this.Text = "Заказы";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _editButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Button _closeButton;
    }
}
