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
    public partial class Prod : Form
    {
        public Prod()
        {
            InitializeComponent();
        }

        private void producerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.producerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);

        }

        Form1 form1 = new Form1();

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Brand". При необходимости она может быть перемещена или удалена.
            this.brandTableAdapter.Fill(this.myDBDataSet.Brand);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Producer". При необходимости она может быть перемещена или удалена.
            this.producerTableAdapter.Fill(this.myDBDataSet.Producer);

            form1.TurnOff(this);
            form1.Upd(this, menuStrip1);

            form1.FillComboBox(myDBDataSet.Producer, myDBDataSet.Country, comboBox5, 3);
            form1.FillComboBox(myDBDataSet.Producer, myDBDataSet.Brand, comboBox6, 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            producerBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.Producer.Rows[producerBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            producerBindingSource.MovePrevious();
            DataRow dr = this.myDBDataSet.Producer.Rows[producerBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            producerBindingSource.MoveLast();
            DataRow dr = this.myDBDataSet.Producer.Rows[producerBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            producerBindingSource.MoveFirst();
            DataRow dr = this.myDBDataSet.Producer.Rows[producerBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr = myDBDataSet.Tables["Producer"].NewRow();
            dr[0] = textBox4.Text;
            dr[1] = textBox6.Text;
            dr[2] = comboBox4.SelectedValue;
            dr[3] = comboBox3.SelectedValue;
            dr[4] = textBox5.Text;
            myDBDataSet.Tables["Producer"].Rows.Add(dr);
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.producerTableAdapter.Fill(this.myDBDataSet.Producer);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.producerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.producerTableAdapter.Fill(this.myDBDataSet.Producer);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            producerBindingSource.RemoveAt(producerBindingSource.Position);
            //DataRow dr = this.myDBDataSet.Producer.Rows[producerBindingSource.Position];
            //textBox1.Text = dr["Code"].ToString();
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.producerTableAdapter.Fill(this.myDBDataSet.Producer);
        }

        private void Open(string TableName)
        {
            AddInfo f = new AddInfo();
            DataRow dr = myDBDataSet.Producer.Rows[producerBindingSource.Position];


            switch (TableName)
            {
                case "Brand":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.Brand;
                    }
                    break;
                case "Country":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.Country;
                    }
                    break;
                default:
                    break;
            }
            int r;
            for (r = 0; r < f.dataGridView1.Rows.Count; r++)
            {
                if (f.dataGridView1.Rows[r].Cells[0].Value.ToString() == dr[TableName].ToString())
                {
                    break;
                }
            }
            f.dataGridView1.CurrentCell = f.dataGridView1[0, r];
            if (f.ShowDialog() == DialogResult.OK)
            {
                int code = Convert.ToInt32(f.dataGridView1.CurrentRow.Cells[0].Value);
                dr[TableName] = code;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Open("Country");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Open("Brand");
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

        private void Prod_Activated(object sender, EventArgs e)
        {
            form1.Upd(this, menuStrip1);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            form1.SelIndexChanged(myDBDataSet.Producer, producerBindingSource, myDBDataSet.Country, comboBox5, 3);
        }

        private void producerBindingSource_PositionChanged(object sender, EventArgs e)
        {
            form1.PosChanged(myDBDataSet.Producer, producerBindingSource, myDBDataSet.Country, comboBox5, 3);
            form1.PosChanged(myDBDataSet.Producer, producerBindingSource, myDBDataSet.Brand, comboBox6, 2);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            form1.SelIndexChanged(myDBDataSet.Producer, producerBindingSource, myDBDataSet.Brand, comboBox6, 2);
        }

    }
}
