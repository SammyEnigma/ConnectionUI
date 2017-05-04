using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamOneilSoftware
{
	public partial class frmConnections : Form
	{
		private BindingSource _bs = null;

		public frmConnections()
		{
			InitializeComponent();
			dataGridView1.AutoGenerateColumns = false;			
		}
		
		public dsConnections Connections { get; set; }

		private void frmConnections_Load(object sender, EventArgs e)
		{
			if (Connections != null)
			{				
				_bs = new BindingSource();
				_bs.DataSource = Connections;
				_bs.DataMember = "ConnectionItem";
				dataGridView1.DataSource = _bs;				
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnSaveAndClose_Click(object sender, EventArgs e)
		{
			try
			{
				Connections.Save();				
				DialogResult = DialogResult.OK;
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void btnTestAll_Click(object sender, EventArgs e)
		{
			try
			{
				bool anyErrors = false;
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					row.ErrorText = null;
					if (row.IsNewRow) continue;
					dsConnections.ConnectionItemRow ci = (dsConnections.ConnectionItemRow)((DataRowView)row.DataBoundItem).Row;
					string message;
					if (!ci.Test(out message, this))
					{
						anyErrors = true;
						row.ErrorText = message;
					}
				}
				if (!anyErrors) MessageBox.Show("All connection strings are valid.");
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{				
				ProcessStartInfo psi = new ProcessStartInfo(dsConnections.SaveFolder);
				Process.Start(psi);
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colLoginButton.Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    if (row.IsNewRow) return;

                    row.ErrorText = null;
                    dsConnections.ConnectionItemRow ci = (dsConnections.ConnectionItemRow)((DataRowView)row.DataBoundItem).Row;
                    if (ci.InteractiveLogin())
                    {
                        string message;
                        if (!ci.Test(out message, this))
                        {                            
                            row.ErrorText = message;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
