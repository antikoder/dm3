namespace WindowsFormsApp.Forms
{
    partial class OrderEditForm
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
            this.codeLabel = new System.Windows.Forms.Label();
            this._codeBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this._statusBox = new System.Windows.Forms.ComboBox();
            this.pickupLabel = new System.Windows.Forms.Label();
            this._pickupBox = new System.Windows.Forms.ComboBox();
            this.orderDateLabel = new System.Windows.Forms.Label();
            this._orderDatePicker = new System.Windows.Forms.DateTimePicker();
            this.deliveryDateLabel = new System.Windows.Forms.Label();
            this._hasDeliveryBox = new System.Windows.Forms.CheckBox();
            this._deliveryDatePicker = new System.Windows.Forms.DateTimePicker();
            this._saveButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(15, 15);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Text = "Артикул";

            this._codeBox.Location = new System.Drawing.Point(15, 40);
            this._codeBox.Name = "_codeBox";
            this._codeBox.Size = new System.Drawing.Size(250, 27);

            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(285, 15);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Text = "Статус";

            this._statusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._statusBox.Location = new System.Drawing.Point(285, 40);
            this._statusBox.Name = "_statusBox";
            this._statusBox.Size = new System.Drawing.Size(250, 28);

            this.pickupLabel.AutoSize = true;
            this.pickupLabel.Location = new System.Drawing.Point(15, 85);
            this.pickupLabel.Name = "pickupLabel";
            this.pickupLabel.Text = "Пункт выдачи";

            this._pickupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._pickupBox.Location = new System.Drawing.Point(15, 110);
            this._pickupBox.Name = "_pickupBox";
            this._pickupBox.Size = new System.Drawing.Size(520, 28);

            this.orderDateLabel.AutoSize = true;
            this.orderDateLabel.Location = new System.Drawing.Point(15, 155);
            this.orderDateLabel.Name = "orderDateLabel";
            this.orderDateLabel.Text = "Дата заказа";

            this._orderDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._orderDatePicker.Location = new System.Drawing.Point(15, 180);
            this._orderDatePicker.Name = "_orderDatePicker";
            this._orderDatePicker.Size = new System.Drawing.Size(250, 27);

            this.deliveryDateLabel.AutoSize = true;
            this.deliveryDateLabel.Location = new System.Drawing.Point(285, 155);
            this.deliveryDateLabel.Name = "deliveryDateLabel";
            this.deliveryDateLabel.Text = "Дата выдачи";

            this._hasDeliveryBox.AutoSize = true;
            this._hasDeliveryBox.Location = new System.Drawing.Point(285, 185);
            this._hasDeliveryBox.Name = "_hasDeliveryBox";
            this._hasDeliveryBox.Text = "Есть";
            this._hasDeliveryBox.UseVisualStyleBackColor = true;
            this._hasDeliveryBox.CheckedChanged += new System.EventHandler(this.HasDelivery_Changed);

            this._deliveryDatePicker.Enabled = false;
            this._deliveryDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._deliveryDatePicker.Location = new System.Drawing.Point(365, 182);
            this._deliveryDatePicker.Name = "_deliveryDatePicker";
            this._deliveryDatePicker.Size = new System.Drawing.Size(170, 27);

            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(235, 245);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(140, 35);
            this._cancelButton.Text = "Отмена";
            this._cancelButton.UseVisualStyleBackColor = true;

            this._saveButton.Location = new System.Drawing.Point(395, 245);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(140, 35);
            this._saveButton.Text = "Сохранить";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);

            this.CancelButton = this._cancelButton;
            this.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.ClientSize = new System.Drawing.Size(550, 300);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._deliveryDatePicker);
            this.Controls.Add(this._hasDeliveryBox);
            this.Controls.Add(this.deliveryDateLabel);
            this.Controls.Add(this._orderDatePicker);
            this.Controls.Add(this.orderDateLabel);
            this.Controls.Add(this._pickupBox);
            this.Controls.Add(this.pickupLabel);
            this.Controls.Add(this._statusBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this._codeBox);
            this.Controls.Add(this.codeLabel);
            this.Name = "OrderEditForm";
            this.Text = "Заказ";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox _codeBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox _statusBox;
        private System.Windows.Forms.Label pickupLabel;
        private System.Windows.Forms.ComboBox _pickupBox;
        private System.Windows.Forms.Label orderDateLabel;
        private System.Windows.Forms.DateTimePicker _orderDatePicker;
        private System.Windows.Forms.Label deliveryDateLabel;
        private System.Windows.Forms.CheckBox _hasDeliveryBox;
        private System.Windows.Forms.DateTimePicker _deliveryDatePicker;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}
