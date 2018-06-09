using System;
using System.Windows.Forms;

namespace Ex05.Damka
{
    internal class UI
    {
        internal void Run()
        {
            FormLogin formLogin = new FormLogin();
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                MainForm mainForm = new MainForm();
                mainForm.StartPosition = FormStartPosition.CenterScreen;
                mainForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                mainForm.ShowDialog();
            }
            
        }
    }
}