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
    public partial class KBB : Form
    {
        
        private Random random;
        private int tempIndex;
        private Form activeForm;
        Query controller;
        public KBB()
        {
            InitializeComponent();
            random = new Random();
            controller = new Query(ConnectionString.ConnStr);
            dataGridView1.DataSource = controller.UpdatePersonKBB();
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
             for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = false;

                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {


                    
                    


                    if (dataGridView1[4, i].Value.ToString() != textBox1.Text)
                    {
                        int a;
                            a = Convert.ToInt32(textBox1.Text);
                        do
                        {   
                            
                            a= a+100;  
                            dataGridView1.Rows[i].Visible = true;
                           break;
                            
                        }
                        while (dataGridView1[4, i].Value.ToString() != textBox1.Text);
                        
                       
                        





                           
                        
                    }
                }
            }
        }
    }
}
