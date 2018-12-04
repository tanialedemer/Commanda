using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Commanda.Cells
{
    public class MenuCell : ViewCell
    {
        public MenuCell()
        {
            var menuLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 20

            };

            menuLabel.SetBinding(Label.TextProperty, new Binding("descripcion"));



            View = new StackLayout
            {
                Children = { menuLabel },
                Orientation = StackOrientation.Horizontal
            };
        }
    }
}
