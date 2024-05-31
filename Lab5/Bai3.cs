using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            textBox1.Text = "datnguyen101004@gmail.com";
            textBox1.ReadOnly = true;
            textBox2.Text = "cush jubq codg xofo";
            textBox2.ReadOnly = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                String to = textBox3.Text;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(textBox1.Text);
                mailMessage.To.Add(to);
                mailMessage.Subject = textBox4.Text;
                mailMessage.Body = richTextBox1.Text;

                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(textBox1.Text, textBox2.Text);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Attachment attachment = new Attachment(filePath);
                    mailMessage.Attachments.Add(attachment);
                }

                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
