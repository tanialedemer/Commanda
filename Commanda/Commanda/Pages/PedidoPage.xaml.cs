using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Commanda.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PedidoPage : ContentPage
	{
        private int id_mesa;

        public PedidoPage ()
		{
			InitializeComponent ();
		}

        public PedidoPage(int id_mesa)
        {
            this.id_mesa = id_mesa;
        }
    }
}