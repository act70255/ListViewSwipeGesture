using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Components
{
    public class ImageButton:Image
    {
        public event EventHandler Clicked;
        protected void OnClick(EventArgs e)
        {
            if (Clicked != null)
                Clicked(this, e);
        }

        public ImageButton()
        {
            VerticalOptions = LayoutOptions.Fill;
            HorizontalOptions = LayoutOptions.Fill;
            this.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    OnClick(null);
                })
            });
        }
    }
}
