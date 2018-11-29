using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Commanda.Cells
{
    public class MesaCell : ViewCell
    {
        public MesaCell()
        {

            var mesaLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 20

            };

            mesaLabel.SetBinding(Label.TextProperty, new Binding("num_mesa"));

     

            View = new StackLayout
            {
                Children = { mesaLabel },
                Orientation = StackOrientation.Horizontal
    };

}
    }
}


