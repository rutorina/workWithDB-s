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
    public partial class Char : Form
    {
        public Char()
        {
            InitializeComponent();
        }

        private void charactetisticBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.charactetisticBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);

        }

        Form1 form1 = new Form1();

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Charactetistic". При необходимости она может быть перемещена или удалена.
            this.charactetisticTableAdapter.Fill(this.myDBDataSet.Charactetistic);

            form1.TurnOff(this);
            form1.Upd(this, menuStrip1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            charactetisticBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.Charactetistic.Rows[charactetisticBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            charactetisticBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.Charactetistic.Rows[charactetisticBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            charactetisticBindingSource.MoveLast();
            DataRow dr = this.myDBDataSet.Charactetistic.Rows[charactetisticBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            charactetisticBindingSource.MoveFirst();
            DataRow dr = this.myDBDataSet.Charactetistic.Rows[charactetisticBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr = myDBDataSet.Tables["Charactetistic"].NewRow();
            dr[0] = textBox5.Text;
            dr[1] = textBox7.Text;
            dr[2] = textBox8.Text;
            dr[3] = textBox6.Text;
            myDBDataSet.Tables["Charactetistic"].Rows.Add(dr);
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.charactetisticTableAdapter.Fill(this.myDBDataSet.Charactetistic);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.charactetisticBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.charactetisticTableAdapter.Fill(this.myDBDataSet.Charactetistic);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            charactetisticBindingSource.RemoveAt(charactetisticBindingSource.Position);
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.charactetisticTableAdapter.Fill(this.myDBDataSet.Charactetistic);
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

        private void Char_Activated(object sender, EventArgs e)
        {
            form1.Upd(this, menuStrip1);
        }
    }
}
