﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Commanda.Models;

namespace Commanda.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PedidoPage : ContentPage
	{
        private List<CategoryResponse> categorias;
        private int id_mesa;

        public PedidoPage ()
		{
			InitializeComponent ();
            lstCategorias.ItemTemplate = new DataTemplate(typeof(Cells.CategoriaCell));
            this.LoadCategorias();
        }

        public PedidoPage(int id_mesa)
        {
            this.id_mesa = id_mesa;
        }

        private async void LoadCategorias()
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

            categorias = JsonConvert.DeserializeObject<List<CategoryResponse>>(result);
            lstCategorias.ItemsSource = categorias;
        }


    }
}
