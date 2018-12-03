using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Commanda.Cells
{
    public class CategoriaCell : ViewCell
    {
        public CategoriaCell()
        {
            var categoriaLabel = new Label
        {
            HorizontalTextAlignment = TextAlignment.Start,
            FontSize = 20

        };

        categoriaLabel.SetBinding(Label.TextProperty, new Binding("categoria"));

     

            View = new StackLayout
            {
                Children = { categoriaLabel},
                Orientation = StackOrientation.Horizontal
            };
}
    }
}
