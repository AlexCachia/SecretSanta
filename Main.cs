using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;

namespace Christmas
{ 
    public partial class Main : Form
    {
        private ValidationClass VC = new ValidationClass();
        private DataGridViewComboBoxColumn IncludeComboboxColumn;
        private DataGridViewComboBoxColumn ExcludeComboboxColumn;
        private int key = 1;
        private bool FirstRun = true;
        public string EmailAddress = "";
        public int DomainID = -1; 
        public string Password = "";

        public Main()
        {
            InitializeComponent();

            //Create datagridview
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].ValueType = typeof(int);
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Email Address";
            dataGridView1.Rows[0].Cells[1].Value = "Add name here";
            dataGridView1.Rows[0].Cells[2].Value = "Add email address here";

            IncludeComboboxColumn = new DataGridViewComboBoxColumn();
            IncludeComboboxColumn.HeaderText = "IDs to Include";
            IncludeComboboxColumn.Name = "Include";
            IncludeComboboxColumn.ValueType = typeof(string);
            IncludeComboboxColumn.ValueMember = "Value";
            dataGridView1.Columns.Insert(3, IncludeComboboxColumn);

            DataGridViewButtonColumn ExcludeBtn = new DataGridViewButtonColumn();
            ExcludeBtn.Text = "-->";
            ExcludeBtn.Name = "Exclude";
            ExcludeBtn.UseColumnTextForButtonValue = true;
            ExcludeBtn.ValueType = typeof(string);
            dataGridView1.Columns.Insert(4, ExcludeBtn);
            dataGridView1.Rows[0].Cells[4].Value = "-->";

            DataGridViewButtonColumn IncludeBtn = new DataGridViewButtonColumn();
            IncludeBtn.Text = "<--";
            IncludeBtn.Name = "Include";
            IncludeBtn.UseColumnTextForButtonValue = true;
            IncludeBtn.ValueType = typeof(string);
            dataGridView1.Columns.Insert(5,IncludeBtn);
            dataGridView1.Rows[0].Cells[5].Value = "<--";

            ExcludeComboboxColumn = new DataGridViewComboBoxColumn();
            ExcludeComboboxColumn.HeaderText = "IDs to Exclude";
            ExcludeComboboxColumn.Name = "Exclude";
            ExcludeComboboxColumn.ValueType = typeof(string);
            ExcludeComboboxColumn.ValueMember = "Value";
            dataGridView1.Columns.Insert(6, ExcludeComboboxColumn);

            CreateIncludeDataSourceForCell();
            CreateExcludeDataSourceForCell();
        }

        //Data Grid Methods
        private void AddNewRow(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!FirstRun)
            {
                int SecondToLastRowIndex = dataGridView1.Rows.Count - 2;

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = "-->";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = "<--";
                dataGridView1.Rows[SecondToLastRowIndex].Cells[0].Value = key;

                //Add new key to each list of ids to include
                for (int i = 0; i < SecondToLastRowIndex; i++)
                {
                    DataGridViewComboBoxCell IncludeCell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[3];
                    List<string> DataSource = IncludeCell.Items.OfType<string>().ToList();
                    DataSource.Add(key.ToString());
                    IncludeCell.DataSource = null;
                    IncludeCell.Items.AddRange(DataSource);
                    IncludeCell.DataSource = DataSource;
                }
                CreateIncludeDataSourceForCell();
                CreateExcludeDataSourceForCell();
                key++;
            }
            else
            {
                FirstRun = false;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = 0;
            }
        }

        private void CreateIncludeDataSourceForCell()
        {
            List<string> InclusionList = new List<string>();
            int MaxRow = dataGridView1.Rows.Count - 1;
            if (MaxRow > 0)
                MaxRow = MaxRow - 1;

            DataGridViewComboBoxCell IncludeCell = (DataGridViewComboBoxCell)dataGridView1.Rows[MaxRow].Cells[3];

            InclusionList.Add("");
            for (int i = 0; i < MaxRow; i++)
            {
                InclusionList.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }
            if (IncludeCell.DataSource != null)
            {
                IncludeCell.DataSource = null;
            }
            IncludeCell.Items.AddRange(InclusionList);
            IncludeCell.DataSource = InclusionList;
        }

        private void CreateExcludeDataSourceForCell()
        {
            List<string> ExclusionList = new List<string>();
            int MaxRow = dataGridView1.Rows.Count - 1;
            if (MaxRow > 0)
                MaxRow = MaxRow - 1;
            DataGridViewComboBoxCell ExcludeCell = (DataGridViewComboBoxCell)dataGridView1.Rows[MaxRow].Cells[6];

            ExclusionList.Add("");
            if (ExcludeCell.DataSource != null)
            {
                ExcludeCell.DataSource = null;
            }

            ExcludeCell.Items.AddRange(ExclusionList);
            ExcludeCell.DataSource = ExclusionList;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> InclusionList = new List<string>();
            List<string> ExclusionList = new List<string>();

            if (dataGridView1.SelectedCells[0].ColumnIndex == 4) // exclude button
            {
                DataGridViewComboBoxCell IncludedCell = (DataGridViewComboBoxCell)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3];
                DataGridViewComboBoxCell ExcludedCell = (DataGridViewComboBoxCell)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[6];

                if (IncludedCell.Value != null)
                {
                    if (!String.IsNullOrWhiteSpace(IncludedCell.Value.ToString()))
                    {
                        //add to exclusion list
                        ExclusionList = ExcludedCell.Items.OfType<string>().ToList();
                        ExclusionList.Add(IncludedCell.Value.ToString());
                        ExcludedCell.DataSource = null;
                        ExcludedCell.Items.AddRange(ExclusionList);
                        ExcludedCell.DataSource = ExclusionList;

                        //remove from inclusion list
                        InclusionList = IncludedCell.Items.OfType<string>().ToList();
                        InclusionList.Remove(IncludedCell.Value.ToString());
                        IncludedCell.DataSource = null;
                        IncludedCell.Items.AddRange(InclusionList);
                        IncludedCell.DataSource = InclusionList;
                        IncludedCell.Value = "";
                    }    
                }
            }

            else if (dataGridView1.SelectedCells[0].ColumnIndex == 5) // include button
            {
                DataGridViewComboBoxCell IncludedCell = (DataGridViewComboBoxCell)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3];
                DataGridViewComboBoxCell ExcludedCell = (DataGridViewComboBoxCell)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[6];

                if (ExcludedCell.Value != null)
                {
                    //add to inclusion list 
                    InclusionList = IncludedCell.Items.OfType<string>().ToList();
                    InclusionList.Add(ExcludedCell.Value.ToString());
                    IncludedCell.DataSource = null;
                    IncludedCell.Items.AddRange(InclusionList);
                    IncludedCell.DataSource = InclusionList;

                    //remove from exclusion list
                    ExclusionList = ExcludedCell.Items.OfType<string>().ToList();
                    ExclusionList.Remove(ExcludedCell.Value.ToString());
                    ExcludedCell.Value = "";
                    ExcludedCell.DataSource = null;
                    ExcludedCell.Items.AddRange(ExclusionList);
                    ExcludedCell.DataSource = ExclusionList;
                } 
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells[0].RowIndex == 0)
            {
                if (dataGridView1.SelectedCells[0].ColumnIndex == 1 && dataGridView1.Rows[0].Cells[1].Value.ToString() == "Add name here")
                    dataGridView1.Rows[0].Cells[1].Value = "";
                if (dataGridView1.SelectedCells[0].ColumnIndex == 2 && dataGridView1.Rows[0].Cells[2].Value.ToString() == "Add email address here")
                    dataGridView1.Rows[0].Cells[2].Value = "";
                dataGridView1.RefreshEdit();
            }
        }

        private void RemoveFirstRowText()
        {
            dataGridView1.Rows[0].Cells[1].Value = "";
            dataGridView1.Rows[0].Cells[2].Value = "";
            dataGridView1.Rows[0].Cells[0].Value = "";
            dataGridView1.RefreshEdit();
        }

        //Buttons
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if ((dataGridView1.Rows.Count != dataGridView1.CurrentCell.RowIndex + 1))
                {
                    string id = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    //Search for id in exception column
                    for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count - 1; rowIndex++)
                    {
                        if (dataGridView1.Rows[rowIndex].Cells[3].Value != null)
                        {
                            string exceptions = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                            int indexOfID = exceptions.IndexOf(id);
                            if (indexOfID != -1)
                            {
                                dataGridView1.Rows[rowIndex].Cells[3].Value = exceptions.Remove(indexOfID); //Remove ID
                            }
                        }  
                    }
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                }   
                else
                    MessageBox.Show("The last row of the grid cannot be deleted however it will not be included in the generation process.");
            }
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            OptionsForm OF = new OptionsForm(key);
            OF.ShowDialog();
            if (OF.rowsToAdd.Count > 0)
            {
                List<string[]> RowsToAdd = OF.rowsToAdd;
                if (dataGridView1.Rows.Count == 1)
                {
                    RemoveFirstRowText();
                }
                foreach (string[] row in RowsToAdd)
                {
                        dataGridView1.Rows.Add(row);
                }
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (IsInputValid())
            {
                //Create Data Tables
                DataTable PeopleTable = new DataTable();
                PeopleTable.Columns.Add("ID", typeof(int));
                PeopleTable.Columns.Add("Name", typeof(string));
                PeopleTable.Columns.Add("Email", typeof(string));

                DataTable ExclusionTable = new DataTable();
                ExclusionTable.Columns.Add("ID", typeof(int));
                ExclusionTable.Columns.Add("ExcludedID", typeof(int));

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    PeopleTable.Rows.Add(new Object[] {
                            dataGridView1.Rows[i].Cells[0].Value,
                            dataGridView1.Rows[i].Cells[1].Value,
                            dataGridView1.Rows[i].Cells[2].Value});

                    foreach (object ID in ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[6]).Items)
                    {
                        int IsInteger;
                        if (Int32.TryParse(ID.ToString(), out IsInteger))
                        {
                            ExclusionTable.Rows.Add(new Object[] {
                                dataGridView1.Rows[i].Cells[0].Value,
                                Int32.Parse(ID.ToString()) });
                        }    
                    }
                }
                
                LoginForm LF = new LoginForm(PeopleTable, ExclusionTable, this.Location.X, this.Location.Y, EmailAddress, DomainID, Password);
                this.Hide();
                LF.ShowDialog();
                EmailAddress = LF.EmailAddress;
                DomainID = LF.DomainID;
                Password = LF.Password;
                this.Location = new Point(LF.Location.X, LF.Location.Y);
                this.Show();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Validation
        private bool IsInputValid()
        {
            bool IsValid = true;
            if (dataGridView1.Rows.Count < 3)
            {
                MessageBox.Show("At least two rows must be completed before you can continue");
                return false;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[1].ErrorText = "";
                dataGridView1.Rows[i].Cells[2].ErrorText = "";
                if (IsEmpty(dataGridView1.Rows[i].Cells[1].Value))
                {
                    dataGridView1.Rows[i].Cells[1].ErrorText = "Name cannot be blank";
                    IsValid = false;
                }

                if (IsEmpty(dataGridView1.Rows[i].Cells[2].Value))
                {
                    dataGridView1.Rows[i].Cells[2].ErrorText = "Email address cannot be blank";
                    IsValid = false;
                }
                else
                {
                    if (!VC.IsEmailAddressValid(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    {
                        dataGridView1.Rows[i].Cells[2].ErrorText = "Email address must be valid.";
                        IsValid = false;
                    }
                }
            }
            return IsValid;
        }
 
        private bool IsEmpty(object value)
        {
            return (value == null);
        }  
    }
}
