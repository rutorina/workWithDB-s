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
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();
        }

        private void typeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.typeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);

        }

        Form1 form1 = new Form1();

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.myDBDataSet.Type);

            form1.TurnOff(this);
            form1.Upd(this, menuStrip1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //to the next record and show value into the sinple control
            typeBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.Type.Rows[typeBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            typeBindingSource.MovePrevious();
            DataRow dr = this.myDBDataSet.Type.Rows[typeBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr = myDBDataSet.Tables["Type"].NewRow();
            dr[0] = textBox6.Text;
            dr[1] = textBox5.Text;
            dr[2] = textBox4.Text;
            myDBDataSet.Tables["Type"].Rows.Add(dr);
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.typeTableAdapter.Fill(this.myDBDataSet.Type);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            typeBindingSource.MoveLast();
            DataRow dr = this.myDBDataSet.Type.Rows[typeBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            typeBindingSource.MoveFirst();
            DataRow dr = this.myDBDataSet.Type.Rows[typeBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.typeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.typeTableAdapter.Fill(this.myDBDataSet.Type);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            typeBindingSource.RemoveAt(typeBindingSource.Position);
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.typeTableAdapter.Fill(this.myDBDataSet.Type);
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

        private void Type_Activated(object sender, EventArgs e)
        {
            form1.Upd(this, menuStrip1);
        }
    }
}
