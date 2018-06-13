using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Drawing;

namespace Christmas
{
    public partial class LoginForm : Form
    {
        private ValidationClass VC = new ValidationClass();
        private DataTable PT;
        private DataTable ET;
        public string EmailAddress;
        public int DomainID;
        public string Password;

        public LoginForm(DataTable PeopleTable, DataTable ExceptionTable, int X, int Y,  string email, int domain, string pw)
        {
            InitializeComponent();
            ProgressLabel.Text = "";
            ProgressLabel.Refresh();
            PT = PeopleTable;
            ET = ExceptionTable;
            this.Location = new Point(X,Y);
            EmailTextbox.Text = email;
            DomainCombobox.SelectedIndex = domain;
            PasswordTextbox.Text = pw;
        }

        //Validators
        private void EmailAddress_Validated(object sender, EventArgs e)
        {
            EmailAddressValidator.Clear();
            EmailDomainValidator.Clear();
            if (EmailTextbox.Text.Equals(""))
            {
                EmailAddressValidator.SetError(EmailTextbox, "Email Address Cannot Be Left Blank");
            }
            if (DomainCombobox.SelectedIndex == -1)
            {
                EmailDomainValidator.SetError(DomainCombobox, "Domain Cannot Be Left Blank");
            }
            else if (!VC.IsEmailAddressValid(EmailTextbox.Text + "@" + DomainCombobox.SelectedItem.ToString()))
            {
                EmailAddressValidator.SetError(EmailTextbox, "Email Address Not Valid");
            }
        }

        private void Password_Validated(object sender, EventArgs e)
        {
            PasswordValidator.Clear();
            if (PasswordTextbox.Text.Equals(""))
            {
                EmailAddressValidator.SetError(PasswordTextbox, "Password Cannot Be Left Blank");
            }
            else if (PasswordTextbox.Text.Length < 5)
            {
                EmailAddressValidator.SetError(PasswordTextbox, "Password Length Is Incorrect");
            }
        }

        private bool IsAddressValid(string domainHost, string address)
        {
            try
            {
                SmtpClient smtp = new SmtpClient(domainHost);
                smtp.Host = domainHost;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(address, PasswordTextbox.Text);
                smtp.EnableSsl = true;
                MailAddress from = new MailAddress(address);
                MailAddress to = from;
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Testing Connection";
                smtp.Send(mail);
                return true;
            }
            catch
            {
                ConnectionValidator.SetError(PasswordTextbox, "Login details are incorrect.");
                return false;
            }
        }
        
        //Buttons
        private void SendEmailButton_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 15;
            progressBar1.Value = 0;

            ProgressLabel.Text = "Validating login details";
            ProgressLabel.Refresh();
            EmailAddress_Validated(sender, e);
            Password_Validated(sender, e);

            if (PasswordValidator.GetError(PasswordTextbox).Equals("") && EmailAddressValidator.GetError(EmailTextbox).Equals("") && EmailDomainValidator.GetError(DomainCombobox).Equals(""))
            {
                //Test email address and pw
                ConnectionValidator.Clear();
                string senderAddress = EmailTextbox.Text + "@" + DomainCombobox.SelectedItem.ToString();

                string domainHost = "";
                switch (DomainCombobox.SelectedIndex)
                {
                    case 0:
                        domainHost = "smtp.gmail.com";
                        break;
                    case 1:
                        domainHost = "smtp.live.com";
                        break;
                    case 2:
                        domainHost = "smtp.live.com";
                        break;
                    case 3:
                        domainHost = "smtp-mail.outlook.com";
                        break;
                    case 4:
                        domainHost = "smtp.mail.yahoo.com";
                        break;
                }

                if (IsAddressValid(domainHost, senderAddress))
                {

                    //Shuffling Names
                    progressBar1.Value = 5;
                    ProgressLabel.Text = "Shuffling Names";
                    ProgressLabel.Refresh();
                    bool shuffled = false;
                    int[] ShuffledIDs = new int[PT.Rows.Count];
                    int ShuffleAttemptNo = 0;
                    while (!shuffled && ShuffleAttemptNo < (PT.Rows.Count*10))
                    {
                        ShuffleAttemptNo = ShuffleAttemptNo + 1;
                        Random random = new Random();
                        ShuffledIDs = PT.AsEnumerable().Select(r => r.Field<int>("id")).ToList().OrderBy(x => random.Next()).ToArray();
                        shuffled = true;

                        foreach (DataRow row in PT.Rows)
                        {
                            var IDsToIgnore = (from et in ET.AsEnumerable()
                                               where et.Field<int>("ID") == row.Field<int>("ID")
                                               select et.Field<int>("ExcludedID"));

                            if (row.Field<int>("ID") == ShuffledIDs[PT.Rows.IndexOf(row)] || (IDsToIgnore.AsEnumerable().Any(et => et == ShuffledIDs[PT.Rows.IndexOf(row)])))
                            {
                                shuffled = false;
                                break;
                            }
                        }
                    }

                    if (!shuffled)
                    {
                        ProgressLabel.Text = "Error: Unable to shuffle names";
                        ProgressLabel.Refresh();
                        progressBar1.Value = 0;
                        MessageBox.Show(@"Unable to shuffle names. Please remove some of the restrictions
                                        or add more people to the selection and try again");
                    }
                    else
                    {
                        //Sending Emails
                        ProgressLabel.Text = "Sending Emails";
                        ProgressLabel.Refresh();
                        progressBar1.Value = 10;

                        MailAddress from = new MailAddress(senderAddress);

                        bool complete = false;

                        foreach (DataRow row in PT.Rows)
                        {
                            try
                            {
                                MailAddress to = new MailAddress(row.Field<string>("Email"));
                                MailMessage mail = new MailMessage(from, to);

                                string ChosenName = (from pt in PT.AsEnumerable()
                                                     where pt.Field<int>("ID") == ShuffledIDs[PT.Rows.IndexOf(row)]
                                                     select pt.Field<string>("Name")).First();

                                mail.Subject = row.Field<string>("Name") + ", Your Secret Santa Is...";
                                mail.IsBodyHtml = true;
                                mail.Body = ChosenName;

                                SmtpClient smtp = new SmtpClient(domainHost);
                                smtp.Host = domainHost;
                                smtp.Port = 587;
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new NetworkCredential(senderAddress, PasswordTextbox.Text);
                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                                complete = true;
                            }
                            catch
                            {
                                string message = "An error has occured during the sending process. Please check all details including " +
                                    "email addresses/names and try again.";
                                if (PT.Rows.IndexOf(row) > 0)
                                {
                                    message = message + " Those which were contacted before this error have been notified.";
                                    for (int resend = 0; resend < (PT.Rows.IndexOf(row)); resend++)
                                    {
                                        MailAddress to = new MailAddress(PT.Rows[resend].Field<string>("Email"));
                                        MailMessage mail = new MailMessage(from, to);

                                        mail.Subject = "IMPORTANT. Please ignore previous email";
                                        mail.IsBodyHtml = true;
                                        mail.Body = "An error occured and the email process could not be completed. Please delete the previous email.";

                                        SmtpClient smtp = new SmtpClient(domainHost);
                                        smtp.Host = domainHost;
                                        smtp.Port = 587;
                                        smtp.UseDefaultCredentials = false;
                                        smtp.Credentials = new NetworkCredential(senderAddress, PasswordTextbox.Text);
                                        smtp.EnableSsl = true;
                                        smtp.Send(mail);
                                        complete = true;
                                    }
                                }
                                complete = false;
                                MessageBox.Show(message);
                                break;
                            }
                        }
                        if (complete)
                        {
                            ProgressLabel.Text = "Emails sent";
                            ProgressLabel.Refresh();
                            progressBar1.Value = 15;
                            MessageBox.Show("All emails have been sent correctly.");
                            Environment.Exit(1);
                        }
                        else
                        {
                            ProgressLabel.Text = "Error has occurred";
                            ProgressLabel.Refresh();
                            progressBar1.Value = 0;
                        }
                    }
                }
                else
                {
                    progressBar1.Value = 0;
                    ProgressLabel.Text = "Error: Invalid login details";
                    ProgressLabel.Refresh();
                }
            }
            else
            {
                progressBar1.Value = 0;
                ProgressLabel.Text = "Error: Invalid login details";
                ProgressLabel.Refresh();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            EmailAddress = EmailTextbox.Text;
            DomainID = DomainCombobox.SelectedIndex;
            Password = PasswordTextbox.Text;
            this.Close();
        }
    }
}
