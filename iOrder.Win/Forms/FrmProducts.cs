﻿namespace iOrder.Win.Forms
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Text;
    using System.Windows.Forms;
    using DbAccess.Contexts.iOrder;

    public partial class FrmProducts : Form
    {
        iOrderContext orderContext = new iOrderContext();

        public FrmProducts()
        {
            InitializeComponent();
        }

        private void FrmProductsLoad(object sender, System.EventArgs e)
        {
            orderContext = new iOrderContext();

            orderContext.Products.Load();

            productDataGridView.DataSource = orderContext.Products.Local.ToBindingList();
        }

        private void productDataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = productDataGridView[e.ColumnIndex, e.RowIndex];

            try
            {
                if (cell == null || cell.OwningColumn == null)
                    throw new Exception("Error selecting cell");

                if (cell.OwningColumn.DataPropertyName.Equals("ImageUrl"))
                {
                    var cellValue = cell.Value?.ToString();
                    using (var openDialog = new OpenFileDialog())
                    {
                        openDialog.FileName = cellValue;
                        if (openDialog.ShowDialog() == DialogResult.OK)
                        {
                            productDataGridView[e.ColumnIndex, e.RowIndex].Value = openDialog.FileName;
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmProductsFormClosing(object sender, FormClosingEventArgs e)
        {
            orderContext.Dispose();
        }

        private void productBindingNavigatorSaveItem_Click_1(object sender, System.EventArgs e)
        {
            try
            {
                Validate();

                orderContext.SaveChanges();

                productDataGridView.Refresh();
            }
            catch (DbEntityValidationException validationException)
            {
                var sBuilder = new StringBuilder();
                foreach (var entityValidationError in validationException.EntityValidationErrors)
                {
                    sBuilder.AppendLine($"{entityValidationError.Entry.Entity.GetType().Name} has the following errors:");
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        sBuilder.AppendLine($" - Property: {validationError.PropertyName} Value: {entityValidationError.Entry.CurrentValues.GetValue<object>(validationError.PropertyName)} Error: {validationError.ErrorMessage}");
                    }
                }
                MessageBox.Show(sBuilder.ToString(), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
