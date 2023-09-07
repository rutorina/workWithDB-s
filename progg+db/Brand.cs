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
    public partial class Brand : Form
    {
        public Brand()
        {
            InitializeComponent();
        }

        private void brandBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.brandBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);

        }

        Form1 form1 = new Form1();

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Brand". При необходимости она может быть перемещена или удалена.
            this.brandTableAdapter.Fill(this.myDBDataSet.Brand);

            form1.TurnOff(this);
            form1.Upd(this, menuStrip1);

            form1.FillComboBox(myDBDataSet.Brand, myDBDataSet.Country, comboBox3, 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brandBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.Brand.Rows[brandBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            brandBindingSource.MovePrevious();
            DataRow dr = this.myDBDataSet.Brand.Rows[brandBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            brandBindingSource.MoveLast();
            DataRow dr = this.myDBDataSet.Brand.Rows[brandBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            brandBindingSource.MoveFirst();
            DataRow dr = this.myDBDataSet.Brand.Rows[brandBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr = myDBDataSet.Tables["Brand"].NewRow();
            dr[0] = textBox4.Text;
            dr[1] = textBox6.Text;
            dr[2] = comboBox2.SelectedValue;
            dr[3] = textBox5.Text;
            myDBDataSet.Tables["Brand"].Rows.Add(dr);
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.brandTableAdapter.Fill(this.myDBDataSet.Brand);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.brandBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.brandTableAdapter.Fill(this.myDBDataSet.Brand);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            brandBindingSource.RemoveAt(brandBindingSource.Position);
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.brandTableAdapter.Fill(this.myDBDataSet.Brand);
        }

        private void Open()
        {
            AddInfo f = new AddInfo();
            DataRow dr = myDBDataSet.Brand.Rows[brandBindingSource.Position];
            f.dataGridView1.DataSource = myDBDataSet.Country;
            int r;
            for (r = 0; r < f.dataGridView1.Rows.Count; r++)
            {
                if (f.dataGridView1.Rows[r].Cells[0].Value.ToString() == dr["Country"].ToString())
                {
                    break;
                }
            }
            f.dataGridView1.CurrentCell = f.dataGridView1[0, r];
            if (f.ShowDialog() == DialogResult.OK)
            {
                int code = Convert.ToInt32(f.dataGridView1.CurrentRow.Cells[0].Value);
                dr["Country"] = code;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Open();
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

        private void Brand_Activated(object sender, EventArgs e)
        {
            form1.Upd(this, menuStrip1);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            form1.SelIndexChanged(myDBDataSet.Brand, brandBindingSource, myDBDataSet.Country, comboBox3, 2);
        }

        private void brandBindingSource_PositionChanged(object sender, EventArgs e)
        {
            form1.PosChanged(myDBDataSet.Brand, brandBindingSource, myDBDataSet.Country, comboBox3, 2);
        }
    }
}
