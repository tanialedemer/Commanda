using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Commanda.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();

            enterButton.Clicked += enterButton_Clicked;

            

        }

        private async void enterButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un usuario", "Aceptar");
                userEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un password", "Aceptar");
                passwordEntry.Focus();
                return;
            }

            waitActivityIndicator.IsRunning = true;
            enterButton.IsEnabled = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://181.123.10.51");
            string url = string.Format("/app/command/UserAPI.php?user={0}&pass={1}", userEntry.Text, passwordEntry.Text);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;
            enterButton.IsEnabled = true;
            waitActivityIndicator.IsRunning = false;

            if (string.IsNullOrEmpty(result) || result == "null")
            {

                await DisplayAlert("Error", "Usuario o Password incorrectos!", "Aceptar");
                passwordEntry.Text = string.Empty;
                passwordEntry.Focus();
                return;

            }

            await Navigation.PushAsync( new MesaPage() );
        }
    }
}