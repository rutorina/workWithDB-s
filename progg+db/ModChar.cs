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
    public partial class ModChar : Form
    {
        public ModChar()
        {
            InitializeComponent();
        }

        private void modelCharacteristicsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.modelCharacteristicsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);

        }

        Form1 form1 = new Form1();

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Charactetistic". При необходимости она может быть перемещена или удалена.
            this.charactetisticTableAdapter.Fill(this.myDBDataSet.Charactetistic);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.ModelCharacteristics". При необходимости она может быть перемещена или удалена.
            this.modelCharacteristicsTableAdapter.Fill(this.myDBDataSet.ModelCharacteristics);

            form1.TurnOff(this);
            form1.Upd(this, menuStrip1);

            form1.FillComboBox(myDBDataSet.ModelCharacteristics, myDBDataSet.Charactetistic, comboBox3, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            modelCharacteristicsBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.ModelCharacteristics.Rows[modelCharacteristicsBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modelCharacteristicsBindingSource.MovePrevious();
            DataRow dr = this.myDBDataSet.ModelCharacteristics.Rows[modelCharacteristicsBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            modelCharacteristicsBindingSource.MoveLast();
            DataRow dr = this.myDBDataSet.ModelCharacteristics.Rows[modelCharacteristicsBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            modelCharacteristicsBindingSource.MoveFirst();
            DataRow dr = this.myDBDataSet.ModelCharacteristics.Rows[modelCharacteristicsBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr = myDBDataSet.Tables["ModelCharacteristics"].NewRow();
            dr[0] = textBox2.Text;
            dr[1] = comboBox2.SelectedValue;
            dr[2] = textBox4.Text;
            myDBDataSet.Tables["ModelCharacteristics"].Rows.Add(dr);
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.modelCharacteristicsTableAdapter.Fill(this.myDBDataSet.ModelCharacteristics);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.modelCharacteristicsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.modelCharacteristicsTableAdapter.Fill(this.myDBDataSet.ModelCharacteristics);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            modelCharacteristicsBindingSource.RemoveAt(modelCharacteristicsBindingSource.Position);
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.modelCharacteristicsTableAdapter.Fill(this.myDBDataSet.ModelCharacteristics);
        }

        private void Open()
        {
            AddInfo f = new AddInfo();
            DataRow dr = myDBDataSet.ModelCharacteristics.Rows[modelCharacteristicsBindingSource.Position];
            f.dataGridView1.DataSource = myDBDataSet.Charactetistic;
            int r;
            for (r = 0; r < f.dataGridView1.Rows.Count; r++)
            {
                if (f.dataGridView1.Rows[r].Cells[0].Value.ToString() == dr["Characteristic"].ToString())
                {
                    break;
                }
            }
            f.dataGridView1.CurrentCell = f.dataGridView1[0, r];
            if (f.ShowDialog() == DialogResult.OK)
            {
                int code = Convert.ToInt32(f.dataGridView1.CurrentRow.Cells[0].Value);
                dr["Charactetistic"] = code;
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

        private void ModChar_Activated(object sender, EventArgs e)
        {
            form1.Upd(this, menuStrip1);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            form1.SelIndexChanged(myDBDataSet.ModelCharacteristics, modelCharacteristicsBindingSource, myDBDataSet.Charactetistic, comboBox3, 1);
        }

        private void modelCharacteristicsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            form1.PosChanged(myDBDataSet.ModelCharacteristics, modelCharacteristicsBindingSource, myDBDataSet.Charactetistic, comboBox3, 1);
        }
    }
}
