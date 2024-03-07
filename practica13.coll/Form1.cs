using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica13.coll
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        HashSet<BookShelf> Books = new HashSet<BookShelf>();
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.AutoResizeColumns();
        }
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Nazvanie";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn1;
        }
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Autor";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn2;
        }
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Ganre";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn3;
        }
        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {                     
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Grade";
                dataGridViewColumn4.ValueType = typeof(int);
                dataGridViewColumn4.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn4;
        }
        private void addBook(string nazv, string autor, string ganre, int grade)
        {
            BookShelf book = new BookShelf();
            book.Set(nazv, autor, ganre, grade);
            Books.Add(book);
            showListInGrid();
        }
        private void deleteBook(BookShelf item)
        {
            Books.Remove(item);
            showListInGrid();
        }
        private void RemoveBook(BookShelf item,string nazv, string autor, string ganre, int grade)
        {
            Books.Remove(item);
            BookShelf book = new BookShelf();
            book.Set(nazv, autor, ganre, grade);
            Books.Add(book);
            showListInGrid();
        }
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (BookShelf book in Books)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = book.getNazv();
                cell2.ValueType = typeof(string);
                cell2.Value = book.getAvtor();
                cell3.ValueType = typeof(string);
                cell3.Value = book.getGanre();
                cell4.ValueType = typeof(int);
                cell4.Value = book.getGrade();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (BookShelf book in Books)
            {
                if (book.getNazv() == textBox1.Text )
                { count++; }
            }
            if (textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && count == 0)
            {
                addBook(textBox1.Text, textBox2.Text, textBox3.Text,Convert.ToInt32(numericUpDown1.Text));
            }else { MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void сортироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rez = MessageBox.Show("Are you sure?", "Sort", MessageBoxButtons.YesNo);
            if (rez == DialogResult.Yes)
            {
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int elementIndex = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult rez = MessageBox.Show("Are you sure?", "redact", MessageBoxButtons.YesNo);
            if (rez == DialogResult.Yes) 
            {
                if (textBox1.Text != "" && textBox2.Text != "") RemoveBook((BookShelf)dataGridView1[dataGridView1.SelectedCells[0].ColumnIndex, dataGridView1.SelectedCells[0].RowIndex].Value,textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(numericUpDown1.Text));
                else MessageBox.Show("ВВедите данные, пожалйста","error",MessageBoxButtons.YesNo);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private int Find(string Name)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                BookShelf book = Books.ElementAt(i);
                if (book.getNazv() == Name) return i;
            }
            return -1;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int elementIndex = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult rez = MessageBox.Show("Are you sure?", "delete", MessageBoxButtons.YesNo);
            if (rez == DialogResult.Yes) deleteBook(Books.ElementAt(Find(Name)));
        }
    }
   
}
