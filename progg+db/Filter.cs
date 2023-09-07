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
    public partial class FilterForm : Form
    {
        public FilterForm()
        {
            InitializeComponent();
        }

        private void keyboardBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.keyboardBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDBDataSet);

        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.ConnectionInterface". При необходимости она может быть перемещена или удалена.
            this.connectionInterfaceTableAdapter.Fill(this.myDBDataSet.ConnectionInterface);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.myDBDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.myDBDataSet.Type);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Producer". При необходимости она может быть перемещена или удалена.
            this.producerTableAdapter.Fill(this.myDBDataSet.Producer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.ModelCharacteristics". При необходимости она может быть перемещена или удалена.
            this.modelCharacteristicsTableAdapter.Fill(this.myDBDataSet.ModelCharacteristics);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDBDataSet.Keyboard". При необходимости она может быть перемещена или удалена.
            this.keyboardTableAdapter.Fill(this.myDBDataSet.Keyboard);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(2, false);
            checkedListBox1_SelectedIndexChanged(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkedListBox1.SetItemChecked(2, false);
            checkedListBox1_SelectedIndexChanged(sender, e);
            if (char.IsNumber(e.KeyChar) ||
                        (!string.IsNullOrEmpty(textBox1.Text) && e.KeyChar == ',') || e.KeyChar == 08)
            {
                return;
            }
            e.Handled = true;            
        }

        private bool And(string NewFilterText)
        {
            if (keyboardBindingSource.Filter != "")
            {
                keyboardBindingSource.Filter += " And " + NewFilterText;
                return true;
            }
            return false;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyboardBindingSource.Filter = "";
            if (checkedListBox1.GetItemChecked(0))
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    keyboardBindingSource.Filter += "Producer = " + comboBox2.SelectedValue.ToString();
                }
                else
                {
                    checkedListBox1.SetItemChecked(0, false);
                    MessageBox.Show("Please, select parameters");
                }
            }
            
            if (checkedListBox1.GetItemChecked(1))
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    if (!And("Type = " + comboBox3.SelectedValue.ToString()))
                        keyboardBindingSource.Filter += "Type = " + comboBox3.SelectedValue.ToString();
                }
                else
                {
                    checkedListBox1.SetItemChecked(1, false);
                    MessageBox.Show("Please, select parameters");
                }
            }
            
            if (checkedListBox1.GetItemChecked(2))
            {
                if (comboBox1.SelectedIndex != -1 && textBox1.Text != "")
                {
                    if(!And("Code " + comboBox1.Text + textBox1.Text))
                        keyboardBindingSource.Filter = "Code " + comboBox1.Text + textBox1.Text;
                }
                else
                {
                    checkedListBox1.SetItemChecked(2, false);
                    MessageBox.Show("Please, select parameters");
                }
            }
            
            if (checkedListBox1.GetItemChecked(3))
            {
                if (comboBox5.SelectedIndex != -1)
                {
                    if (!And("ConnectionInterface = " + comboBox5.SelectedValue.ToString()))
                        keyboardBindingSource.Filter += "ConnectionInterface = " + comboBox5.SelectedValue.ToString();
                }
                else
                {
                    checkedListBox1.SetItemChecked(3, false);
                    MessageBox.Show("Please, select parameters");
                }
            }
        }
       
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(0, false);
            checkedListBox1_SelectedIndexChanged(sender, e);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(1, false);
            checkedListBox1_SelectedIndexChanged(sender, e);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(3, false);
            checkedListBox1_SelectedIndexChanged(sender, e);
        }
    }
}
