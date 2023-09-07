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
    public partial class ConnInter : Form
    {
        public ConnInter()
        {
            InitializeComponent();
        }

        private void connectionInterfaceBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.connectionInterfaceBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);

        }

        Form1 form1 = new Form1();

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.ConnectionInterface". При необходимости она может быть перемещена или удалена.
            this.connectionInterfaceTableAdapter.Fill(this.myDBDataSet.ConnectionInterface);

            form1.TurnOff(this);
            form1.Upd(this, menuStrip1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectionInterfaceBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.ConnectionInterface.Rows[connectionInterfaceBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connectionInterfaceBindingSource.MovePrevious();
            DataRow dr = this.myDBDataSet.ConnectionInterface.Rows[connectionInterfaceBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connectionInterfaceBindingSource.MoveLast();
            DataRow dr = this.myDBDataSet.ConnectionInterface.Rows[connectionInterfaceBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connectionInterfaceBindingSource.MoveFirst();
            DataRow dr = this.myDBDataSet.ConnectionInterface.Rows[connectionInterfaceBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr = myDBDataSet.Tables["ConnectionInterface"].NewRow();
            dr[0] = textBox5.Text;
            dr[1] = textBox6.Text;
            dr[2] = textBox4.Text;
            myDBDataSet.Tables["ConnectionInterface"].Rows.Add(dr);
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.connectionInterfaceTableAdapter.Fill(this.myDBDataSet.ConnectionInterface);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.connectionInterfaceBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.connectionInterfaceTableAdapter.Fill(this.myDBDataSet.ConnectionInterface);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            connectionInterfaceBindingSource.RemoveAt(connectionInterfaceBindingSource.Position);
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.connectionInterfaceTableAdapter.Fill(this.myDBDataSet.ConnectionInterface);
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

        private void ConnInter_Activated(object sender, EventArgs e)
        {
            form1.Upd(this, menuStrip1);
        }
    }
}
