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
        public RegisterCustomer()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
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
            btnCreateAccount.Visibility = Visibility.Visible;
        }


        private void CallRestApi(object data, string resource)
        {
            var client = new RestClient("http://localhost:58183/api");
            var request = new RestSharp.RestRequest(resource, RestSharp.Method.POST)
            { RequestFormat = RestSharp.DataFormat.Json }
                .AddJsonBody(data);
            try
            {
                var response = client.Execute(request);
                MessageBox.Show("Success !!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw ex;
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var command = new CreateAccountCommand() { CustomerNationalCode = txtNationalCode.Text };
            CallRestApi(command, "/Account/");

        }
    }
}
