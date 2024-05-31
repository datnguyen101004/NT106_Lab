using MailKit.Net.Imap;
using MailKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using MailKit.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab5
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("127.0.0.1", 143, SecureSocketOptions.None);
                    client.Authenticate(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim());
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    label3.Text = "Total : " + inbox.Count.ToString();
                    label4.Text = "Recent : " + inbox.Recent.ToString();
                    for (int i = 0; i < inbox.Count; i++)
                    {
                        var message = inbox.GetMessage(i);
                        ListViewItem name = new ListViewItem(message.Subject);
                        name.SubItems.Add(message.From.ToString());
                        name.SubItems.Add(message.Date.ToString());
                        listView1.Items.Add(name);
                    }
                    client.Disconnect(true);
                    MessageBox.Show("Successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
