using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdamOneilSoftware
{
    public partial class frmLogin : Form
    {		
        public frmLogin()
        {
            InitializeComponent();
        }

		public string ConnectionName { get; set; }		

		public string UserName
		{
			get { return tbUserName.Text; }
		}

		public string Password
		{
			get { return tbPassword.Text; }
		}

		public bool SavePassword
		{
			get { return chkSavePassword.Checked; }
		}

        private void btnOK_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.OK;
        }

		private void frmLogin_Load(object sender, EventArgs e)
		{
			label3.Text = string.Format(label3.Text, ConnectionName);
		}		
	}
}
