using CAN.Task2SQL.Model;
using CAN.Task2SQL.View;
using System;
using System.Data.Entity;
using System.Windows;

namespace CAN.Task2SQL
{
    public partial class MainWindow : Window
    {
        private RegistrationEntities db = new RegistrationEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void BtnLogin_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                Role userModel = await db.Roles.FirstOrDefaultAsync(d => d.Role1 == TbLogin.Text);
                if (userModel != null)
                {
                    switch (userModel.RoleID)
                    {
                        case 1:
                            new AdminWindow().ShowDialog();
                            break;
                        case 2:
                            new DevWindow().ShowDialog();
                            break;
                        case 3:
                            new UserWindow().ShowDialog();
                            break;
                    }
                }
                else
                {
                    new ErrorWindow().ShowDialog();
                }
            }
            catch (Exception)
            {

                new ErrorWindow().ShowDialog();
            }
        }

        private void BtnAdminInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "admin";
            PbPassword.Password = "11111";
        }

        private void BtnDevInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "dev";
            PbPassword.Password = "22222";
        }

        private void BtnUserInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "user";
            PbPassword.Password = "33333";
        }

        private void BtnClearInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = string.Empty;
            PbPassword.Password = string.Empty;
        }
    }
}
