using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Unjumble
{
    public partial class Categories : PhoneApplicationPage
    {
        public class HubTileData
        {
            public string Title { get; set; }
            public string Message { get; set; }
            public string Image { get;set;}
          

        }
        public Categories()
        {
            InitializeComponent();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            String[] cat = { "Mixed","Hollywood","Lifestyle","Music","People","Places","Kids","Dictionary","Movies","Halloween","Cricket","Tennis"};
            String[] cat_desc = { "Everything is mixed here","Actors, Characters, Movies","Celebrities, Brands & Fashion","Astists, Albums, Singles & more","Celebrities & Personalities", "Countries, Cities & more","Back to childhood!","Classic dictionary words","Movie names","Halloween Movies, Customs etc","Cricket Players", "Players, Terms and more"};
            for (int i = 0; i < 12; i++)
            {
                HubTileData iHubTileData = new HubTileData();
                iHubTileData.Title = cat[i];
                iHubTileData.Message = cat_desc[i];
                iHubTileData.Image = (string)"/cat//" + cat[i] + ".png";
                list2.Items.Add(iHubTileData);
            }
        }

        private void HubTile_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            HubTile click = (HubTile)sender;

            NavigationService.Navigate(new Uri("/game.xaml?name="+click.Title,UriKind.Relative));
        }
    }
}