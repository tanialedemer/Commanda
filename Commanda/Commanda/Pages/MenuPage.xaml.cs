using Commanda.Models;
using Newtonsoft.Json;
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
	public partial class MenuPage : ContentPage
	{
        private List<Product> producto;
        public MenuPage ()
		{
			InitializeComponent ();
            this.LoadMenu();
        }
       
        private async void LoadMenu()
        {
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://181.123.10.51");
                string url = string.Format("/app/command/ProductAPI.php");
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No hay conexion", "Aceptar");
                return;
            }

            producto = JsonConvert.DeserializeObject<List<Product>>(result);
            lstMenu.ItemsSource = producto;
        }
    }
}