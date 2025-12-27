using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Setting : Form
    {
        private bool isDarkTheme = true;

        public Setting()
        {
            InitializeComponent();
            
            radioButtonsang.CheckedChanged += RadioButtonsang_CheckedChanged;
            radioButtontoi.CheckedChanged += RadioButtontoi_CheckedChanged;

            radioButtontoi.Checked = true;
        }

        // Cập nhật tất cả text trên form
        public void UpdateLanguage()
        {
            this.Text = LanguageManager.GetTranslation("Setting_Title");
            groupBox1.Text = LanguageManager.GetTranslation("Setting_StoreInfo");
            groupBox2.Text = LanguageManager.GetTranslation("Setting_SystemConfig");
            
            label1.Text = LanguageManager.GetTranslation("Setting_StoreNameLabel");
            label2.Text = LanguageManager.GetTranslation("Setting_AddressLabel");
            label3.Text = LanguageManager.GetTranslation("Setting_EmailLabel");
            
            radioButtonsang.Text = LanguageManager.GetTranslation("Setting_LightTheme");
            radioButtontoi.Text = LanguageManager.GetTranslation("Setting_DarkTheme");

            // Cập nhật các form khác
            foreach (Form form in Application.OpenForms)
            {
                if (form is TrangChu trangChuForm)
                {
                    trangChuForm.UpdateLanguage();
                }
            }
        }

        private void RadioButtonsang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonsang.Checked && isDarkTheme)
            {
                isDarkTheme = false;
                ThemeManager.ApplyLightTheme(this);
                
                foreach (Form form in Application.OpenForms)
                {
                    if (form != this)
                    {
                        ThemeManager.ApplyLightTheme(form);
                    }
                }
            }
        }

        private void RadioButtontoi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtontoi.Checked && !isDarkTheme)
            {
                isDarkTheme = true;
                ThemeManager.ApplyDarkTheme(this);
                
                foreach (Form form in Application.OpenForms)
                {
                    if (form != this)
                    {
                        ThemeManager.ApplyDarkTheme(form);
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
