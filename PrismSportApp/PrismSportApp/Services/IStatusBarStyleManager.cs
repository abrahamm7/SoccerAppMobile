using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Services
{
    public interface IStatusBarStyleManager
    {
        void SetColoredStatusBar(string hexColor);
        void SetWhiteStatusBar();
    }
}
