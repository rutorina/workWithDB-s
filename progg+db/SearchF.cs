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
    public partial class SearchF : Form
    {
        public SearchF()
        {
            InitializeComponent();
        }

        string Table = "";

        private void button1_Click(object sender, EventArgs e)
        {   
            dataGridView1.DataSource = keyboardBindingSource;
            this.keyboardTableAdapter.Fill(this.myDBDataSet.Keyboard);
            this.Validate();
            Table = "Keyboard";
        }

        private void SearchF_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.ModelCharacteristics". При необходимости она может быть перемещена или удалена.
            this.modelCharacteristicsTableAdapter.Fill(this.myDBDataSet.ModelCharacteristics);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Charactetistic". При необходимости она может быть перемещена или удалена.
            this.charactetisticTableAdapter.Fill(this.myDBDataSet.Charactetistic);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Brand". При необходимости она может быть перемещена или удалена.
            this.brandTableAdapter.Fill(this.myDBDataSet.Brand);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = brandBindingSource;
            this.brandTableAdapter.Fill(this.myDBDataSet.Brand);
            this.Validate();
            Table = "Brand";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = producerBindingSource;
            this.producerTableAdapter.Fill(this.myDBDataSet.Producer);
            this.Validate();
            Table = "Producer";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = countryBindingSource;
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);
            this.Validate();
            Table = "Country";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = typeBindingSource;
            this.typeTableAdapter.Fill(this.myDBDataSet.Type);
            this.Validate();
            Table = "Type";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connectionInterfaceBindingSource;
            this.connectionInterfaceTableAdapter.Fill(this.myDBDataSet.ConnectionInterface);
            this.Validate();
            Table = "ConnInt";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = charactetisticBindingSource;
            this.charactetisticTableAdapter.Fill(this.myDBDataSet.Charactetistic);
            this.Validate();
            Table = "Char";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = modelCharacteristicsBindingSource;
            this.modelCharacteristicsTableAdapter.Fill(this.myDBDataSet.ModelCharacteristics);
            this.Validate();
            Table = "ModChar";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            switch (Table)
            {
                case "Keyboard":
                    {
                        MyDBDataSet.KeyboardRow ResRow = myDBDataSet.Keyboard.FindByCode(textBox1.Text);
                        if (ResRow == null)
                        {
                            MessageBox.Show("No data");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + ResRow.Code + "\n" +
                                "Producer " + ResRow.Producer + "\n" +
                                "Model " + ResRow.Model + "\n" +
                                "Type " + ResRow.Type + "\n" +
                                "ConnectionInterface " + ResRow.ConnectionInterface + "\n" +
                                "Size " + ResRow.Size + "\n" +
                                "Language " + ResRow.Language + "\n" +
                                "Shape " + ResRow.Shape + "\n" +
                                "Status " + ResRow.Status + "\n" +
                                "Color " + ResRow.Color + "\n" +
                                "AdditionalFeatures " + ResRow.AdditionalFeatures;
                        }
                    }
                    break;
                case "Brand":
                    {
                        MyDBDataSet.BrandRow ResRow = myDBDataSet.Brand.FindByCode(textBox1.Text);
                        if (ResRow == null)
                        {
                            MessageBox.Show("No data");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + ResRow.Code + "\n" +
                                "Name " + ResRow.Name + "\n" +
                                "Country " + ResRow.Country + "\n" +
                                "Description " + ResRow.Description;
                        }
                    }
                    break;
                case "Producer":
                    {
                        MyDBDataSet.ProducerRow ResRow = myDBDataSet.Producer.FindByCode(textBox1.Text);
                        if (ResRow == null)
                        {
                            MessageBox.Show("No data");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + ResRow.Code + "\n" +
                                "Name " + ResRow.Name + "\n" +
                                "Brand " + ResRow.Brand + "\n" + 
                                "Country " + ResRow.Country + "\n" +
                                "Description " + ResRow.Description;
                        }
                    }
                    break;
                case "ModChar":
                    {
                        if (textBox1.Text != "" && textBox2.Text != "")
                        {
                            MyDBDataSet.ModelCharacteristicsRow ResRow = myDBDataSet.ModelCharacteristics.FindByCodeCharacteristic(textBox1.Text, Convert.ToByte(textBox2.Text));
                            if (ResRow == null)
                            {
                                MessageBox.Show("No data");
                            }
                            else
                            {
                                richTextBox1.Text = "Code " + ResRow.Code + "\n" +
                                    "Characteristic " + ResRow.Characteristic + "\n" +
                                    "Value " + ResRow.Value;
                            }
                        }
                    }
                    break;
                case "Char":
                    {
                        MyDBDataSet.CharactetisticRow ResRow = myDBDataSet.Charactetistic.FindByCode(Convert.ToByte(textBox1.Text));
                        if (ResRow == null)
                        {
                            MessageBox.Show("No data");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + ResRow.Code + "\n" +
                                "Characteristic " + ResRow.Name + "\n" +
                                "Units " + ResRow.Units + "\n" +
                                "Description " + ResRow.Description;
                        }
                    }
                    break;
                case "Type":
                    {
                        MyDBDataSet.TypeRow ResRow = myDBDataSet.Type.FindByCode(Convert.ToByte(textBox1.Text));
                        if (ResRow == null)
                        {
                            MessageBox.Show("No data");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + ResRow.Code + "\n" +
                                "Name " + ResRow.Name + "\n" +
                                "Description " + ResRow.Description;
                        }
                    }
                    break;
                case "Country":
                    {
                        MyDBDataSet.CountryRow ResRow = myDBDataSet.Country.FindByCode(Convert.ToByte(textBox1.Text));
                        if (ResRow == null)
                        {
                            MessageBox.Show("No data");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + ResRow.Code + "\n" +
                                "Name " + ResRow.Name + "\n" +
                                "Description " + ResRow.Description;
                        }
                    }
                    break;
                case "ConnInt":
                    {
                        MyDBDataSet.ConnectionInterfaceRow ResRow = myDBDataSet.ConnectionInterface.FindByCode(Convert.ToByte(textBox1.Text));
                        if (ResRow == null)
                        {
                            MessageBox.Show("No data");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + ResRow.Code + "\n" +
                                "Name " + ResRow.Name + "\n" +
                                "Description " + ResRow.Description;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            switch (Table)
            {
                case "Keyboard":
                    {
                        DataRow foundRow = myDBDataSet.Tables["Keyboard"].Rows.Find(s);
                        if (foundRow == null)
                        {
                            MessageBox.Show("A row with the primary key " + s + " could not be found");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + foundRow["Code"] + "\n" +
                                "Producer " + foundRow["Producer"] + "\n" +
                                "Model " + foundRow["Model"] + "\n" +
                                "Type " + foundRow["Type"] + "\n" + 
                                "ConnectionInterface " + foundRow["ConnectionInterface"] + "\n" +
                                "Size " + foundRow["Size"] + "\n" +
                                "Language " + foundRow["Language"] + "\n" +
                                "Shape " + foundRow["Shape"] + "\n" +
                                "Status " + foundRow["Status"] + "\n" +
                                "Color " + foundRow["Color"] + "\n" +
                                "AdditionalFeatures " + foundRow["AdditionalFeatures"];
                        }
                    }
                    break;
                case "Brand":
                    {
                        DataRow foundRow = myDBDataSet.Tables["Brand"].Rows.Find(s);
                        if (foundRow == null)
                        {
                            MessageBox.Show("A row with the primary key " + s + " could not be found");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + foundRow["Code"] + "\n" +
                                "Name " + foundRow["Name"] + "\n" +
                                "Country " + foundRow["Country"] + "\n" +
                                "Description " + foundRow["Description"];
                        }
                    }
                    break;
                case "Producer":
                    {
                        DataRow foundRow = myDBDataSet.Tables["Producer"].Rows.Find(s);
                        if (foundRow == null)
                        {
                            MessageBox.Show("A row with the primary key " + s + " could not be found");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + foundRow["Code"] + "\n" +
                                "Name " + foundRow["Name"] + "\n" +
                                "Brand " + foundRow["Brand"] + "\n" +
                                "Country " + foundRow["Country"] + "\n" +
                                "Description " + foundRow["Description"];
                        }
                    }
                    break;
                case "ModChar":                  
                    {
                        DataRow foundRow = myDBDataSet.Tables["ModelCharacteristics"].Rows.Find(s);
                        if (foundRow == null)
                        {
                            MessageBox.Show("A row with the primary key " + s + " could not be found");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + foundRow["Code"] + "\n" +
                                "Characteristic " + foundRow["Characteristic"] + "\n" +
                                "Value " + foundRow["Value"];
                        }
                    }
                    break;
                case "Char":
                    {
                        DataRow foundRow = myDBDataSet.Tables["Charactetistic"].Rows.Find(s);
                        if (foundRow == null)
                        {
                            MessageBox.Show("A row with the primary key " + s + " could not be found");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + foundRow["Code"] + "\n" +
                                "Characteristic " + foundRow["Name"] + "\n" +
                                "Units " + foundRow["Units"] + "\n" +
                                "Description " + foundRow["Description"];
                        }
                    }
                    break;
                case "Type":
                    {
                        DataRow foundRow = myDBDataSet.Tables["Type"].Rows.Find(s);
                        if (foundRow == null)
                        {
                            MessageBox.Show("A row with the primary key " + s + " could not be found");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + foundRow["Code"] + "\n" +
                                "Name " + foundRow["Name"] + "\n" +
                                "Description " + foundRow["Description"];
                        }
                    }
                    break;
                case "Coutry":
                    {
                        DataRow foundRow = myDBDataSet.Tables["Country"].Rows.Find(s);
                        if (foundRow == null)
                        {
                            MessageBox.Show("A row with the primary key " + s + " could not be found");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + foundRow["Code"] + "\n" +
                                "Name " + foundRow["Name"] + "\n" +
                                "Description " + foundRow["Description"];
                        }
                    }
                    break;
                case "ConnInt":
                    {
                        DataRow foundRow = myDBDataSet.Tables["ConnectionInterface"].Rows.Find(s);
                        if (foundRow == null)
                        {
                            MessageBox.Show("A row with the primary key " + s + " could not be found");
                        }
                        else
                        {
                            richTextBox1.Text = "Code " + foundRow["Code"] + "\n" +
                                "Name " + foundRow["Name"] + "\n" +
                                "Description " + foundRow["Description"];
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void Fill_DGV(DataRow[] foundRows)
        {
            if (foundRows.Count() > 0)
            {
                foreach (DataRow dataRow in foundRows)
                {
                    dataGridView2.Rows.Add(dataRow.ItemArray);
                }
            }
            else
            {
                MessageBox.Show("No data");
            }
        }
    
        private void button11_Click(object sender, EventArgs e)
        {
            DataRow[] foundRows;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                dataGridView2.Columns.Add(c.Name, c.HeaderText);
            }

            foundRows = myDBDataSet.Tables["Keyboard"].Select("Model like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
            string sdaf = "Model like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text;
            //DataRow[] res = бДDataSet.Tables["Cosmetic"].Select("Name like '" + textBox2.Text + "%' and Country =" + textBox3.Text);
            switch (Table)
            {
                case "Keyboard":
                    {
                        foundRows = myDBDataSet.Tables["Keyboard"].Select("Model Like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
                        Fill_DGV(foundRows);
                    }
                    break;
                case "Brand":
                    {
                        foundRows = myDBDataSet.Tables["Brand"].Select("Name Like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
                        Fill_DGV(foundRows);
                    }
                    break;
                case "Producer":
                    {
                        foundRows = myDBDataSet.Tables["Producer"].Select("Name Like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
                        Fill_DGV(foundRows);
                    }
                    break;
                case "ModChar":
                    {
                        foundRows = myDBDataSet.Tables["ModelCharacteristics"].Select("Characteristic Like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
                        Fill_DGV(foundRows);
                    }
                    break;
                case "Char":
                    {
                        foundRows = myDBDataSet.Tables["Charactetistic"].Select("Name Like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
                        Fill_DGV(foundRows);
                    }
                    break;
                case "Type":
                    {
                        foundRows = myDBDataSet.Tables["Type"].Select("Name Like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
                        Fill_DGV(foundRows);
                    }
                    break;
                case "Coutry":
                    {
                        foundRows = myDBDataSet.Tables["Coutry"].Select("Name Like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
                        Fill_DGV(foundRows);
                    }
                    break;
                case "ConnInt":
                    {
                        foundRows = myDBDataSet.Tables["ConnectionIntnerface"].Select("Name Like '" + textBox3.Text + "%' and Code " + comboBox1.Text + textBox4.Text);
                        Fill_DGV(foundRows);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
