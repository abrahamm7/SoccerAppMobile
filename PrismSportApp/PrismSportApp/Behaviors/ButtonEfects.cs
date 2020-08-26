using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrismSportApp.Behaviors
{
    public class ButtonEfects: TriggerAction<Button>
    {
        protected override async void Invoke(Button sender)
        {

            await sender.FadeTo(0, 2000, Easing.CubicIn);

            await sender.FadeTo(1, 2000, Easing.CubicOut);

        }

    }
}
