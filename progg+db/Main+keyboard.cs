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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void keyboardBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.keyboardBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.keyboardTableAdapter.Fill(this.myDBDataSet.Keyboard);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.ModelCharacteristics". При необходимости она может быть перемещена или удалена.
            this.modelCharacteristicsTableAdapter.Fill(this.myDBDataSet.ModelCharacteristics);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.myDBDataSet.Type);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.ConnectionInterface". При необходимости она может быть перемещена или удалена.
            this.connectionInterfaceTableAdapter.Fill(this.myDBDataSet.ConnectionInterface);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Producer". При необходимости она может быть перемещена или удалена.
            this.producerTableAdapter.Fill(this.myDBDataSet.Producer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Keyboard". При необходимости она может быть перемещена или удалена.
            this.keyboardTableAdapter.Fill(this.myDBDataSet.Keyboard);
            TurnOff(this);

            FillComboBox(myDBDataSet.Keyboard, myDBDataSet.Producer, comboBox7, 1);
            FillComboBox(myDBDataSet.Keyboard, myDBDataSet.Type, comboBox8, 3);
            FillComboBox(myDBDataSet.Keyboard, myDBDataSet.ConnectionInterface, comboBox9, 4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModChar f = new ModChar();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Char f = new Char();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConnInter f = new ConnInter();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Type f = new Type();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Prod f = new Prod();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Brand f = new Brand();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Country f = new Country();
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            keyboardBindingSource.MoveNext();
            DataRow dr = this.myDBDataSet.Keyboard.Rows[keyboardBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            keyboardBindingSource.MovePrevious();
            DataRow dr = this.myDBDataSet.Keyboard.Rows[keyboardBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            keyboardBindingSource.MoveLast();
            DataRow dr = this.myDBDataSet.Keyboard.Rows[keyboardBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            keyboardBindingSource.MoveFirst();
            DataRow dr = this.myDBDataSet.Keyboard.Rows[keyboardBindingSource.Position];
            textBox1.Text = dr["Code"].ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataRow dr = myDBDataSet.Tables["Keyboard"].NewRow();
            dr[0] = textBox9.Text;
            dr[1] = comboBox4.SelectedValue;
            dr[2] = textBox2.Text;
            dr[3] = comboBox6.SelectedValue;
            dr[4] = comboBox3.SelectedValue;
            dr[5] = textBox18.Text;
            dr[6] = textBox17.Text;
            dr[7] = textBox14.Text;
            dr[8] = textBox13.Text;
            dr[9] = textBox5.Text;
            myDBDataSet.Tables["Keyboard"].Rows.Add(dr);
            //this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            //this.keyboardTableAdapter.Fill(this.myDBDataSet.Keyboard);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.keyboardBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.keyboardTableAdapter.Fill(this.myDBDataSet.Keyboard);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            keyboardBindingSource.RemoveAt(keyboardBindingSource.Position);
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);
            this.keyboardTableAdapter.Fill(this.myDBDataSet.Keyboard);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SearchF f = new SearchF();
            f.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FilterForm f = new FilterForm();
            f.Show();
        }

        /*switch (RefTable)
{
    case "Keyboard":
        {

        }
        break;
    case "ModChar":
        {

        }
        break;
    default:
        break;
}*/ //, string RefTable
        //============================================================================
        private void Open(string TableName)
        {
            AddInfo f = new AddInfo();
            DataRow dr = myDBDataSet.Keyboard.Rows[keyboardBindingSource.Position];


            switch (TableName)
            {
                /*case "Brand":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.Brand;
                    }
                    break;*/
                case "Producer":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.Producer;
                    }
                    break;
               /* case "ModelCharacteristics":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.ModelCharacteristics;
                    }
                    break;
                case "Charactetistic":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.Charactetistic;
                    }
                    break;*/
                case "Type":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.Type;
                    }
                    break;
                /*case "Country":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.Country;
                    }
                    break;*/
                case "ConnectionInterface":
                    {
                        f.dataGridView1.DataSource = myDBDataSet.ConnectionInterface;
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

        private void button17_Click(object sender, EventArgs e)
        {/*
            AddInfo f = new AddInfo();
            DataRow dr = myDBDataSet.Keyboard.Rows[keyboardBindingSource.Position];
            f.dataGridView1.DataSource = myDBDataSet.Producer;
            int r;
            for (r = 0; r < f.dataGridView1.Rows.Count; r++)
            {
                if (f.dataGridView1.Rows[r].Cells[0].Value.ToString() == dr["Producer"].ToString())
                {
                    break;
                }
            }
            f.dataGridView1.CurrentCell = f.dataGridView1[0, r];
            if (f.ShowDialog() == DialogResult.OK) 
            {
                int code = Convert.ToInt32(f.dataGridView1.CurrentRow.Cells[0].Value);
                dr["Producer"] = code;
            }*/
            Open("Producer");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Open("Type");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Open("ConnectionInterface");
        }
        //============================================================================
        public static string Logged = "Unlogged";//Unlogged

        public void TurnOff(Form form)
        {
            foreach (Control component in form.Controls)
            {
                if (component.Tag != null && (component.Tag.ToString() == "1" || component.Tag.ToString() == "2"))
                {
                    component.Enabled = false;
                }
            }
        }

        public void TurnOn(Form form)
        {
            foreach (Control component in form.Controls)
            {
                if (component.Tag != null && (component.Tag.ToString() == "1" || component.Tag.ToString() == "2"))
                {
                    component.Enabled = true;
                }
            }
        }

        public void Upd(Form form, MenuStrip menuStrip)
        {
            TurnOff(form);
            if (Logged == "Admin")
            {
                menuStrip.Items[0].Visible = false;
                menuStrip.Items[1].Visible = true;
                TurnOn(form);
            }
            else if (Logged == "User")
            {
                menuStrip.Items[0].Visible = false;
                menuStrip.Items[1].Visible = true;
                foreach (Control component in form.Controls)
                {
                    if (component.Tag != null && component.Tag.ToString() == "2")
                    {
                        component.Enabled = true;
                    }
                }
            }
            else
            {
                menuStrip.Items[0].Visible = true;
                menuStrip.Items[1].Visible = false;
            }
        }

        public void loginToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login f = new Login();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.Yes)
            {
                Logged = "Admin";
                Upd(this, menuStrip1);
                //TurnOn(this);
                
                loginToolStripMenuItem.Visible = false;
                exitToolStripMenuItem.Visible = true;
            }
            else if (f.DialogResult == DialogResult.No)
            {
                Logged = "User";
                Upd(this, menuStrip1);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginToolStripMenuItem.Visible = true;
            exitToolStripMenuItem.Visible = false;
            Logged = "Unlogged";
            TurnOff(this);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Upd(this, menuStrip1);
        }
        //============================================================================
        public void FillComboBox(DataTable MainTable, DataTable SubTable, ComboBox comboBox, int SubTablePos)
        {
            DataRow dr_main = MainTable.Rows[0];
            comboBox.Items.Clear();
            for (int i = 0; i < SubTable.Rows.Count; i++)
            {
                comboBox.Items.Add(SubTable.Rows[i][1]);
            }
            DataRow[] dr_sub = SubTable.Select("Code=" + dr_main[SubTablePos].ToString());
            comboBox.SelectedIndex = comboBox.FindString(dr_sub[0][1].ToString());
        }

        public void PosChanged(DataTable MainTable, BindingSource MainTableBS, DataTable SubTable, ComboBox comboBox, int SubTablePos)
        {
            if (MainTableBS.Position != -1)
            {
                DataRow dr_main = MainTable.Rows[MainTableBS.Position];
                DataRow[] dr_sub = SubTable.Select("Code=" + dr_main[SubTablePos].ToString());
                comboBox.SelectedIndex = comboBox.FindString(dr_sub[0][1].ToString());
            }
        }

        public void SelIndexChanged(DataTable MainTable, BindingSource MainTableBS, DataTable SubTable, ComboBox comboBox, int SubTablePos)
        {
            DataRow dr_main = MainTable.Rows[MainTableBS.Position];
            DataRow[] dr_sub = SubTable.Select("Name='" + comboBox.Text + "'");
            dr_main[SubTablePos] = dr_sub[0][0].ToString();
        }
        //============================================================================
        private void keyboardBindingSource_PositionChanged(object sender, EventArgs e)
        {
            PosChanged(myDBDataSet.Keyboard, keyboardBindingSource, myDBDataSet.Producer, comboBox7, 1);
            PosChanged(myDBDataSet.Keyboard, keyboardBindingSource, myDBDataSet.Type, comboBox8, 3);
            PosChanged(myDBDataSet.Keyboard, keyboardBindingSource, myDBDataSet.ConnectionInterface, comboBox9, 4);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelIndexChanged(myDBDataSet.Keyboard, keyboardBindingSource, myDBDataSet.Producer, comboBox7, 1);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelIndexChanged(myDBDataSet.Keyboard, keyboardBindingSource, myDBDataSet.Type, comboBox8, 3);
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelIndexChanged(myDBDataSet.Keyboard, keyboardBindingSource, myDBDataSet.ConnectionInterface, comboBox9, 4);
        }
    }
}
