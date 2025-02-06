using Sample.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Sample.Forms
{
    public partial class OVC : Form
    {

        private Random random;
        private int tempIndex;
        private Form activeForm;
        Query controller;
        public OVC()
        {
             
            InitializeComponent();
            random = new Random();
            controller = new Query(ConnectionString.ConnStr);
            dataGridView1.DataSource = controller.UpdateOVC();
        
       
        }

        private void OVC_Load(object sender, EventArgs e)
        {

        }
        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox4, "Название РЭС по значениям поиска");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateOVC();

            double? frequency = null;
            double? range = null;
            double? impulse = null;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                frequency = null;
            else frequency = Convert.ToDouble(textBox1.Text);


            if (string.IsNullOrWhiteSpace(textBox2.Text))
                range = null;
            else range = Convert.ToDouble(textBox2.Text);


            if (string.IsNullOrWhiteSpace(textBox3.Text))
                impulse = null;
            else impulse = Convert.ToDouble(textBox3.Text);


            var table = GetTable(dataGridView1);
            IEnumerable<DataRow> dataRows = table.AsEnumerable();

            if (frequency != null)
            {
                dataRows = table.AsEnumerable()
                    .Skip(2)
                    .Where(x =>
                    {
                        double min4;
                        double max5;

                        double.TryParse(x[4].ToString(), out min4);
                        double.TryParse(x[5].ToString(), out max5);


                        double min6;
                        double max7;

                        double.TryParse(x[6].ToString(), out min6);
                        double.TryParse(x[7].ToString(), out max7);


                        double min8;
                        double max9;

                        double.TryParse(x[8].ToString(), out min8);
                        double.TryParse(x[9].ToString(), out max9);
                        //1
                        if (frequency != null &&
                           range != null &&
                           impulse != null)
                        {
                            return frequency > min4 && frequency < max5
                            && range > min6 && range < max7
                            && impulse > min8 && impulse < max9;
                        }
                        //2
                        else if (frequency != null && range != null && impulse == null)
                        {
                            return frequency > min4 && frequency < max5
                            && range > min6 && range < max7;
                        }
                        //3
                        else if (frequency != null && range == null && impulse != null)
                        {
                            return frequency > min4 && frequency < max5
                            && impulse > min8 && impulse < max9;
                        }
                        //4
                        else if (frequency == null && range != null && impulse != null)
                        {
                            return range > min6 && range < max7
                            && impulse > min8 && impulse < max9;
                        }
                        //5
                        else if (frequency != null && range == null && impulse == null)
                        {
                            return frequency > min4 && frequency < max5;
                        }
                        //6
                        else if (frequency == null && range != null && impulse == null)
                        {
                            return range > min6 && range < max7;
                        }
                        //7
                        else if (frequency == null && range == null && impulse != null)
                        {
                            return impulse > min8 && impulse < max9;
                        }
                        else
                            return true;
                    });
            }

            dataGridView1.DataSource = dataRows.CopyToDataTable();
        }

        private DataTable GetTable(DataGridView grid)
        {
            DataTable dataTable = new DataTable();
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                dataTable.Columns.Add(dataGridView1.Columns[i].HeaderText);
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                DataRow newRow = dataTable.NewRow();
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    object cell = row.Cells[j].Value;
                    newRow[j] = cell == null ? DBNull.Value : cell;
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }
    }
}

    

