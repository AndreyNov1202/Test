using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sample.Controller;
using Label = System.Windows.Forms.Label;

namespace Sample
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;


        Query controller;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            controller = new Query(ConnectionString.ConnStr);
            dataGridView1.DataSource = controller.UpdatePersonKBB();
            label1.Hide();

        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.Black;
                    currentButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    panelTitleBar.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.BackColor = Color.SkyBlue;
                    previousBtn.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            label1.Hide();
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;


        }

        private void CloseChildForm(Form childForm, object btnSender)
        {
            if (activeForm != childForm)
            {
                activeForm.Close();
            }
            lblTitle.Text = activeForm.Text;
            label1.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdatePersonKBB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // controller.Add(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Delete(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSV(), sender);
            dataGridView1.DataSource = controller.UpdatePersonKBB();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSV(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSV(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSV(), sender);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CloseChildForm(new Forms.FormSV(), sender);


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = false;

                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    if (dataGridView1[c, i].Value.ToString() == textBox1.Text)
                    {
                        dataGridView1.Rows[i].Visible = true;
                        break;
                    }
                }
            }

            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    dataGridView1.Rows[i].Selected = false;
            //    for (int j = 0; j < dataGridView1.ColumnCount; j++)
            //        if (dataGridView1.Rows[i].Cells[j].Value != null)
            //            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
            //            {
            //                dataGridView1.Rows[i].Selected = true;
            //                break;
            //            }
            //}
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdatePersonKBB();
            textBox1.Clear();
        }

        private void pictureBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = false;

                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    if (dataGridView1[c, i].Value.ToString() == textBox1.Text)
                    {
                        dataGridView1.Rows[i].Visible = true;
                        break;
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) pictureBox2_Click( sender, e);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работы выполнил курсант 123 учебной группы рядовой НОвосёлов А.В.");
        }
    }
}
