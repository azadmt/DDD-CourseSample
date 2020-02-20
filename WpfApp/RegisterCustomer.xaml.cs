using AccountManagement.Application.Contract;
using CustomerManagement.Application.Contract;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegisterCustomer : Window
    {
        private bool isLoggin;
        public RegisterCustomer()
        {
            InitializeComponent();
        }

        string securityToken;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoggin)
            {
                MessageBox.Show("Please  Login To System !!!");
                return;
            }
            var registerCustomer = new RegisterCustomerCommand();
            registerCustomer.FirstName = txtFirstName.Text;
            registerCustomer.LastName = txtLastName.Text;
            registerCustomer.NationalCode = txtNationalCode.Text;

            registerCustomer.HomeAddress_Province = txtHomeAddress_Province.Text;
            registerCustomer.HomeAddress_City = txtHomeAddress_City.Text;
            registerCustomer.HomeAddress_PostalCode = txtHomeAddress_PostalCode.Text;

            registerCustomer.WorkAddress_Province = txtWorkAddress_Province.Text;
            registerCustomer.WorkAddress_City = txtWorkAddress_City.Text;
            registerCustomer.WorkAddress_PostalCode = txtWorkAddress_PostalCode.Text;


            CallRestApi(registerCustomer, "/customer/");
            //btnCreateAccount.Visibility = Visibility.Visible;
        }


        private void CallRestApi(object data, string resource)
        {
            var client = new RestClient("http://localhost:58183/api");
            var request = new RestSharp.RestRequest(resource, RestSharp.Method.POST)
            { RequestFormat = RestSharp.DataFormat.Json }
                .AddJsonBody(data);
            request.AddHeader("Token", securityToken.Replace("\"", string.Empty));
            try
            {
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    MessageBox.Show("Success !!!");
                }
                else
                {
                    MessageBox.Show(response.Content);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw ex;
            }
        }

        private void Login()
        {
            var client = new RestClient("http://localhost:5000/api");
            var request = new RestSharp.RestRequest("/Security/", RestSharp.Method.POST)
            { RequestFormat = RestSharp.DataFormat.Json }
                .AddJsonBody(new { UserName = "admin", Password = "123" });
            try
            {
                var response = client.Execute(request);
                securityToken = response.Content;
                isLoggin = true;
                MessageBox.Show("Login Successfull....");
                btnLogin.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw ex;
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            //if (!isLoggin)
            //{
            //    MessageBox.Show("Please  Login To System !!!");
            //    return;
            //}
            //var command = new CreateAccountCommand() { OwnerId = txtNationalCode.Text };
            //CallRestApi(command, "/Account/");

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();

        }
    }
}
