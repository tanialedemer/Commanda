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

        public partial class MesaPage : ContentPage
        {
            private List<Mesa> mesas;

            public MesaPage()
            {
                InitializeComponent();
                lstMesas.ItemTemplate = new DataTemplate(typeof(Cells.MesaCell));
                this.LoadMesas();
            }

            private async void LoadMesas()
            {
                string result;
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://181.123.10.51");
                    string url = string.Format("/app/command/mesa.php");
                    var response = await client.GetAsync(url);
                    result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "No hay conexion", "Aceptar");
                    return;
                }

                mesas = JsonConvert.DeserializeObject<List<Mesa>>(result);
                lstMesas.ItemsSource = mesas;
            }

                 async void ItemTapped (object sender, ItemTappedEventArgs e)
                {
                    var mesa = e.Item as Mesa;


                     await Navigation.PushAsync(new PedidoPage() { Title = "Mesa Nro."+mesa.num_mesa });
                }

        }

    }