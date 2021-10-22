using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_Recomendacion
{
    public partial class frmWelcome : Form
    {
        private string name;
        private int id;
        private string profileImgPath = Path.Combine(Environment.CurrentDirectory,"imgProfiles");

        public frmWelcome()
        {
            InitializeComponent();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            loadImgProfiles();
        }

        private void loadImgProfiles()
        {
            pbProfile1.ImageLocation = Path.Combine(profileImgPath, "profile" + 1 + ".png");
            pbProfile2.ImageLocation = Path.Combine(profileImgPath, "profile" + 2+ ".png");
            pbProfile3.ImageLocation = Path.Combine(profileImgPath, "profile" + 3 + ".png");

        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProfile1_Click(object sender, EventArgs e)
        {
            setNewProfile(1, btnProfile1.Text);   
        }

        private void btnProfile2_Click(object sender, EventArgs e)
        {
            setNewProfile(2, btnProfile2.Text);
        }

        private void btnProfile3_Click(object sender, EventArgs e)
        {
            setNewProfile(3, btnProfile3.Text);
        }
        
        private void setNewProfile(int ID, string NAME)
        {
            this.Hide();
            frmSelect frmSelect = new frmSelect(ID, NAME);
            frmSelect.Show();
        }
    }
}
