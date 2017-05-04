using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace AdamOneilSoftware
{
	partial class dsConnections
	{
		public static dsConnections Load()
		{
			dsConnections ds = new dsConnections();
			if (File.Exists(FileName)) ds.ReadXml(FileName);
			return ds;
		}

		public static string FileName
		{
			get { return Path.Combine(SaveFolder, "Connections.xml"); }
		}

		public void Save()
		{
			string folder = Path.GetDirectoryName(FileName);
			if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
			WriteXml(FileName);
		}

		public static string SaveFolder
		{
			get
			{
				return Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
					"Adam O'Neil Software", "Query Tools");
			}
		}

		public partial class ConnectionItemRow
		{
			private string _secureConnectionString = null;

			public string SecureConnectionString
			{
				get
				{
					string result = ConnectionString;
					if (result.Contains("{login}"))
					{
						if (_secureConnectionString == null)
						{
							string userName;
							string password;
							if (Login(out userName, out password))
							{
								result = result.Replace("{login}", string.Format("User ID={0};Password={1}", userName, password));
								_secureConnectionString = result;
							}
							else
							{
								throw new Exception("Login failed or was canceled.");
							}
						}
						else
						{
							result = _secureConnectionString;
						}
					}
					return result;
				}
			}

			private bool Login(out string userName, out string password)
			{
				if (GetSavedCredentials(out userName, out password)) return true;

				return InteractiveLogin(out userName, out password);
			}

			private bool GetSavedCredentials(out string userName, out string password)
			{
				userName = null;
				password = null;

				string fileName = SavedCredentialsFilename();
				if (File.Exists(fileName))
				{
					SavedCredentials sc = SavedCredentials.Load(fileName);
					userName = sc.UserName;
					password = sc.Password;
					return true;
				}
				return false;
			}

			public bool InteractiveLogin()
			{
				string userName, password;
				return InteractiveLogin(out userName, out password);
			}

			private bool InteractiveLogin(out string userName, out string password)
			{
				_secureConnectionString = null;

				frmLogin dlg = new frmLogin();
				dlg.ConnectionName = Name;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					userName = dlg.UserName;
					password = dlg.Password;
					if (dlg.SavePassword)
					{
						SavedCredentials sc = new SavedCredentials() { UserName = userName, Password = password };
						sc.Save(SavedCredentialsFilename());
					}
					return true;
				}

				userName = null;
				password = null;
				return false;
			}

			private string SavedCredentialsFilename()
			{
				return Path.Combine(SaveFolder, Name + ".credentials.xml");
			}

			public bool Test(out string message, Form waitingForm = null)
			{
				bool result = false;
				try
				{
					if (waitingForm != null) waitingForm.Cursor = Cursors.WaitCursor;
					result = TestInner(SecureConnectionString, out message);
				}
				finally
				{
					if (waitingForm != null) waitingForm.Cursor = Cursors.Default;
				}
				return result;
			}

			private bool TestInner(string connectionString, out string message)
			{
				message = null;
				try
				{
					using (SqlConnection cn = new SqlConnection(connectionString))
					{
						cn.Open();
						cn.Close();
						return true;
					}
				}
				catch (Exception exc)
				{
					message = exc.Message;
					return false;
				}
			}

			public override string ToString()
			{
				return Name;
			}
		}

		public static bool Test(string connectionString)
		{
			throw new NotImplementedException();
		}
	}
}
