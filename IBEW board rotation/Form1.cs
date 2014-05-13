using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


// Indexing http://msdn.microsoft.com/en-us/library/2549tw02.aspx
// Cleaning up strings http://msdn.microsoft.com/en-us/library/844skk0h%28v=vs.110%29.aspx
// List Sorting http://msdn.microsoft.com/en-us/library/b0zbh7b6%28v=vs.110%29.aspx
// List instead of Arrays http://www.dotnetperls.com/list
// Open File Dialog http://www.dotnetperls.com/openfiledialog
// DataSet Joining Tables http://msdn.microsoft.com/en-US/library/ay82azad%28v=vs.80%29.aspx

namespace IBEW_board_rotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender,EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.  http://msdn.microsoft.com/en-us/library/844skk0h%28v=vs.110%29.aspx
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters,  
            // we should return Empty. 
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Rotate board; Are you sure?", "Rotate Board", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                MessageBox.Show("Board Rotated Successfully", "Board Rotated", MessageBoxButtons.OK);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exiting the application will not save the prograss.\nAre you sure you want to Exit?", "Exit Program", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void importHolidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string all_text = File.ReadAllText(file);
                    String[] text = File.ReadAllText(file).Split('\n');
                    size = text.Length;   


// DataSet Creation
                    DataSet unionMembersDataSet = new DataSet("unionMembersDataSet");
                    DataTable masterListTable = unionMembersDataSet.Tables.Add("masterListTable");
                    int count_row = 0;
                    foreach (string row in text)
                    {
                        string[] data = row.Split(',');
                        // you want first row for header columns
                        if (count_row == 0)
                        {
                            foreach (string header in data)
                            {
                                // First row split for header and columns.
                                //MessageBox.Show(header);
                                unionMembersDataSet.Tables[0].Columns.Add(header);
                            }
                        }
                        else
                        {
                            //unionMembers.Tables[0].Columns.Add(data);
                        }
                        count_row++;
                        //unionMembers.Tables[0].Rows.Add
                    }
                    MessageBox.Show("Following text: " + text[0] + "\nSize:" + count_row);
                    List<string> myList = all_text.Split(',').ToList();
                    listBox1.DataSource = myList;


                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.

            //Create data source :)
            

            // Load csv to file
            //String[] all_txt = File.ReadAllText(file).Split('\n');
            

        }

    }
}
