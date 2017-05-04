using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamOneilSoftware
{
	public class DbConnectionToolbar : ToolStrip
	{
		private dsConnections _connections = null;
		private ToolStripComboBox _tscbConnection;
		private bool _designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);

		public event EventHandler ConnectionChanged;

		public DbConnectionToolbar()
		{
			ToolStripButton btnConnectionDlg = new ToolStripButton()
			{
				DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
				Image = ToolbarImages.Connect_grey_16x,
				ImageTransparentColor = System.Drawing.Color.Magenta				
			};
			btnConnectionDlg.Click += ConnectionsDialogClick;

			_tscbConnection = new ToolStripComboBox()
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				Size = new System.Drawing.Size(150, 25),
				Name = "tscbConnection"
			};
			_tscbConnection.SelectedIndexChanged += OnConnectionChanged;

			Items.AddRange(new ToolStripItem[] {  btnConnectionDlg, _tscbConnection });

			if (!_designMode) FillConnectionNames();
		}

		private void OnConnectionChanged(object sender, EventArgs e)
		{
			ConnectionChanged?.Invoke(this, new EventArgs());
		}

		private void ConnectionsDialogClick(object sender, EventArgs e)
		{
			if (_connections == null) _connections = dsConnections.Load();
			frmConnections dlg = new frmConnections();
			dlg.Connections = _connections;
			dlg.ShowDialog();
			FillConnectionNames();
		}

		private void FillConnectionNames()
		{
			if (_connections == null) _connections = dsConnections.Load();
			object currentConnection = _tscbConnection.SelectedItem;
			_tscbConnection.Items.Clear();			
			_tscbConnection.Items.AddRange(_connections.ConnectionItem.AsEnumerable().Select(row => row.Name).ToArray());						
			if (currentConnection != null) _tscbConnection.SelectedItem = currentConnection;
		}

		public void SetConnectionByName(string name)
		{
			if (string.IsNullOrEmpty(name)) return;
			_tscbConnection.SelectedItem = name;
		}

		public bool HasConnectionName(string connectionName)
		{
			if (string.IsNullOrEmpty(connectionName)) return false;
			return _connections.ConnectionItem.Any(row => row.Name.ToLower().Equals(connectionName.ToLower()));
		}

		public dsConnections.ConnectionItemRow CurrentConnection
		{
			get
			{
				return _connections.ConnectionItem.SingleOrDefault(row => row.Name.Equals(_tscbConnection.SelectedItem));
			}
		}

	}
}
