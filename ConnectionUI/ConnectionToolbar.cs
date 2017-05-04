using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AdamOneilSoftware
{
	public partial class ConnectionToolbar : UserControl
	{
		private dsConnections _connections = null;

		public event EventHandler ConnectionChanged;
		public event EventHandler ProjectIntegrationClicked;

		public ConnectionToolbar()
		{
			InitializeComponent();
		}

		public dsConnections Connections
		{
			get { return _connections; }
		}

		public void AddCommands(ToolStripItem[] commands)
		{			
			foreach (var tmi in commands) toolStrip1.Items.Add(tmi);
		}

		public bool ShowProjectIntegrationButton
		{
			get { return tsbCodeGenOptions.Visible; }
			set { tsbCodeGenOptions.Visible = value; }
		}

		public bool IsProjectIntegrationActive
		{
			get { return tsbCodeGenOptions.Checked; }
			set { tsbCodeGenOptions.Checked = value; }
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			frmConnections dlg = new frmConnections();
			dlg.Connections = _connections;
			dlg.ShowDialog();
			FillConnectionNames();
		}

		private void FillConnectionNames()
		{
			object currentConnection = tscbConnection.SelectedItem;
			tscbConnection.Items.Clear();
			tscbConnection.Items.AddRange(_connections.ConnectionItem.AsEnumerable().Select(row => row.Name).ToArray());
			if (currentConnection != null) tscbConnection.SelectedItem = currentConnection;
		}

		private void tscbConnection_SelectedIndexChanged(object sender, EventArgs e)
		{
			ConnectionChanged?.Invoke(sender, e);
		}

		public dsConnections.ConnectionItemRow CurrentConnection
		{
			get
			{				
				return _connections.ConnectionItem.SingleOrDefault(row => row.Name.Equals(tscbConnection.SelectedItem));
			}			
		}
		
		public void SetConnectionByName(string name)
		{
			if (string.IsNullOrEmpty(name)) return;
			tscbConnection.SelectedItem = name;
		}		

		private void ConnectionToolbar_Load(object sender, EventArgs e)
		{
			_connections = dsConnections.Load();
			FillConnectionNames();
		}

		public bool HasConnectionName(string connectionName)
		{
			if (string.IsNullOrEmpty(connectionName)) return false;
			return _connections.ConnectionItem.Any(row => row.Name.ToLower().Equals(connectionName.ToLower()));
		}

		private void tsbCodeGenOptions_Click(object sender, EventArgs e)
		{
			ProjectIntegrationClicked?.Invoke(this, e);
		}
	}
}
