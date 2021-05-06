using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestListViewPersistence.Persistence;

namespace TestListViewPersistence
{
    public partial class frmMain : Form
    {
        List<Person> _people = null;
        public frmMain()
        {
            InitializeComponent();

            //setup list view column headers
            lvMain.View = View.Details;
            var firstNameHeader = new ColumnHeader()
            {
                Text = "First Name",
                Name = "firstName",
             
            };
            var lastNameHeader = new ColumnHeader()
            {
                Text = "Last Name",
                Name = "lastName",
            };

            lvMain.Columns.Add(firstNameHeader);
            lvMain.Columns.Add(lastNameHeader);            

            LoadPeople();
        }

        private void LoadPeople()
        {
            lvMain.Items.Clear();
            //load people from Json
            _people = Person.LoadFromJson();
            foreach(var person in _people)
            {
                
                ListViewItem personRow = new ListViewItem(new string[] { person.FirstName, person.LastName });

                lvMain.Items.Add(personRow);
            }
            lvMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);            
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this should save
            Person.SaveList(_people);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPeople();
        }
    }
}
