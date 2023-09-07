using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progg_db
{
    public partial class Country : Form
    {
        public Country()
        {
            InitializeComponent();
        }

        private void countryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.countryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);

        }

        Form1 form1 = new Form1();

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);

            form1.TurnOff(this);
            form1.Upd(this, menuStrip1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            countryBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.Country.Rows[countryBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            countryBindingSource.MovePrevious();
            DataRow dr = this.myDBDataSet.Country.Rows[countryBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            countryBindingSource.MoveLast();
            DataRow dr = this.myDBDataSet.Country.Rows[countryBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            countryBindingSource.MoveFirst();
            DataRow dr = this.myDBDataSet.Country.Rows[countryBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr = myDBDataSet.Tables["Country"].NewRow();
            dr[0] = textBox5.Text;
            dr[1] = textBox4.Text;
            dr[2] = textBox6.Text;
            myDBDataSet.Tables["Country"].Rows.Add(dr);
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            countryBindingSource.RemoveAt(countryBindingSource.Position);
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.Yes)
            {
                Form1.Logged = "Admin";
                form1.TurnOn(this);
                loginToolStripMenuItem.Visible = false;
                exitToolStripMenuItem.Visible = true;
            }
            else if (f.DialogResult == DialogResult.No)
            {
                Form1.Logged = "User";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginToolStripMenuItem.Visible = true;
            exitToolStripMenuItem.Visible = false;
            Form1.Logged = "Unlogged";
            form1.TurnOff(this);
        }

        private void Country_Activated(object sender, EventArgs e)
        {
            form1.Upd(this, menuStrip1);
        }
    }
}
