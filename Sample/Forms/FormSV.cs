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


namespace Sample.Forms
{
    public partial class FormSV : Form
    {

        Query controller;
        public FormSV()
        {
            InitializeComponent();
         
            
            controller = new Query(ConnectionString.ConnStr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateOVC();
            OVC Check = new OVC();
            Check.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = controller.UpdateKBB();
            KBB Check = new KBB();
            Check.Show();
            
        }

        private void FormSV_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdatePersonKBB();
        }
    }
}
