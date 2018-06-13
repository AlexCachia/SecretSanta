using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Christmas
{
    public partial class OptionsForm : Form
    {
        public List<string[]> rowsToAdd = new List<string[]>();
        public int key;

        public OptionsForm(int Key)
        {
            InitializeComponent();
            listDialog.Filter = "Text files (*.txt)|*.txt";
            this.DialogResult = DialogResult.OK;
            key = Key;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (listDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader r = new StreamReader(listDialog.FileName))
                {
                    string line;
                    string[] str;
                    bool Incomplete = false;
                    while ((line = r.ReadLine()) != null)// for each line in the txt file
                    {
                        if (!line.Trim().Equals("")) //if line is not blank
                        {
                            str = line.Split(',');
                            if (str.Length == 1)
                            {
                                str = line.Split(' ');
                            }
                            if (!str[0].Trim().Equals("") && str.Length == 2) //if row is valid then add to list
                            {
                                if (!str[1].Trim().Equals(""))
                                {
                                    rowsToAdd.Add(new string[] { key.ToString(), str[0], str[1].Trim() }); 
                                }
                                else
                                {
                                    Incomplete = true;
                                    break;
                                }

                            }
                            else
                            {
                                Incomplete = true;
                                break;
                            }
                        }
                    }
                    if (Incomplete) //if any of the information is not valid then display error
                    {
                        MessageBox.Show(@"An error has occurred. Please check the text file and try again. 
                            Remember each line should be in the following format: NAME, EMAIL ADDRESS ");
                            rowsToAdd.Clear();
                    }
                    else // else add information to the view
                    {
                        this.Close();
                    }
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
