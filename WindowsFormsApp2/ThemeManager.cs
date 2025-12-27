using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class ThemeManager
    {
        // M軿 s嫕g (Light Theme)
        public static class LightTheme
        {
            public static readonly Color BackColor = Color.White;
            public static readonly Color ForeColor = Color.Black;
            public static readonly Color FormBackColor = Color.White;
            public static readonly Color FormForeColor = Color.Black;
            public static readonly Color GroupBoxBackColor = Color.WhiteSmoke;
            public static readonly Color GroupBoxForeColor = Color.Black;
            public static readonly Color ButtonBackColor = Color.LightGray;
            public static readonly Color ButtonForeColor = Color.Black;
            public static readonly Color TextBoxBackColor = Color.White;
            public static readonly Color TextBoxForeColor = Color.Black;
            public static readonly Color LabelForeColor = Color.Black;
        }

        // M軿 t?i (Dark Theme)
        public static class DarkTheme
        {
            public static readonly Color BackColor = Color.FromArgb(33, 36, 52);
            public static readonly Color ForeColor = Color.FromArgb(220, 223, 235);
            public static readonly Color FormBackColor = Color.FromArgb(33, 36, 52);
            public static readonly Color FormForeColor = Color.FromArgb(220, 223, 235);
            public static readonly Color GroupBoxBackColor = Color.FromArgb(45, 49, 72);
            public static readonly Color GroupBoxForeColor = Color.FromArgb(220, 223, 235);
            public static readonly Color ButtonBackColor = Color.FromArgb(45, 49, 72);
            public static readonly Color ButtonForeColor = Color.FromArgb(220, 223, 235);
            public static readonly Color TextBoxBackColor = Color.FromArgb(45, 49, 72);
            public static readonly Color TextBoxForeColor = Color.FromArgb(220, 223, 235);
            public static readonly Color LabelForeColor = Color.FromArgb(220, 223, 235);
        }

        // 聯 d?ng theme s嫕g
        public static void ApplyLightTheme(Form form)
        {
            form.BackColor = LightTheme.FormBackColor;
            form.ForeColor = LightTheme.FormForeColor;

            foreach (Control control in GetAllControls(form))
            {
                ApplyLightThemeToControl(control);
            }
        }

        // 聯 d?ng theme t?i
        public static void ApplyDarkTheme(Form form)
        {
            form.BackColor = DarkTheme.FormBackColor;
            form.ForeColor = DarkTheme.FormForeColor;

            foreach (Control control in GetAllControls(form))
            {
                ApplyDarkThemeToControl(control);
            }
        }

        // 聯 d?ng theme s嫕g cho t?ng control
        private static void ApplyLightThemeToControl(Control control)
        {
            if (control is GroupBox groupBox)
            {
                groupBox.BackColor = LightTheme.GroupBoxBackColor;
                groupBox.ForeColor = LightTheme.GroupBoxForeColor;
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = LightTheme.TextBoxBackColor;
                textBox.ForeColor = LightTheme.TextBoxForeColor;
            }
            else if (control is Label label)
            {
                label.BackColor = LightTheme.BackColor;
                label.ForeColor = LightTheme.LabelForeColor;
            }
            else if (control is Button button)
            {
                button.BackColor = LightTheme.ButtonBackColor;
                button.ForeColor = LightTheme.ButtonForeColor;
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = LightTheme.TextBoxBackColor;
                comboBox.ForeColor = LightTheme.TextBoxForeColor;
            }
            else
            {
                control.BackColor = LightTheme.BackColor;
                control.ForeColor = LightTheme.ForeColor;
            }

            // 聯 d?ng cho c塶 control con
            foreach (Control childControl in control.Controls)
            {
                ApplyLightThemeToControl(childControl);
            }
        }

        // 聯 d?ng theme t?i cho t?ng control
        private static void ApplyDarkThemeToControl(Control control)
        {
            if (control is GroupBox groupBox)
            {
                groupBox.BackColor = DarkTheme.GroupBoxBackColor;
                groupBox.ForeColor = DarkTheme.GroupBoxForeColor;
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = DarkTheme.TextBoxBackColor;
                textBox.ForeColor = DarkTheme.TextBoxForeColor;
            }
            else if (control is Label label)
            {
                label.BackColor = DarkTheme.BackColor;
                label.ForeColor = DarkTheme.LabelForeColor;
            }
            else if (control is Button button)
            {
                button.BackColor = DarkTheme.ButtonBackColor;
                button.ForeColor = DarkTheme.ButtonForeColor;
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = DarkTheme.TextBoxBackColor;
                comboBox.ForeColor = DarkTheme.TextBoxForeColor;
            }
            else
            {
                control.BackColor = DarkTheme.BackColor;
                control.ForeColor = DarkTheme.ForeColor;
            }

            // 聯 d?ng cho c塶 control con
            foreach (Control childControl in control.Controls)
            {
                ApplyDarkThemeToControl(childControl);
            }
        }

        // L?y t?t c? c塶 control (k? c? con)
        private static System.Collections.Generic.List<Control> GetAllControls(Control container)
        {
            var controls = new System.Collections.Generic.List<Control>();

            foreach (Control control in container.Controls)
            {
                controls.Add(control);
                controls.AddRange(GetAllControls(control));
            }

            return controls;
        }
    }
}
