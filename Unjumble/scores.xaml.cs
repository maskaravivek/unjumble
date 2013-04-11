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
    public partial class scores : PhoneApplicationPage
    {
        public class Entities
        {
            public string name { get; set; }
            public string detail { get; set; }
            public string score { get; set; }
            public string theme { get; set; }
        }
       
        public scores()
        {
            InitializeComponent();
        }
        public IList<Scores> GetScores()
        {
            IList<Scores> scoreList = null;
            using (UnjumbleDataContext context = new UnjumbleDataContext(UnjumbleDataContext.DBConnectionString))
            {
                IQueryable<Scores> que = from c in context.Records select c ;
                scoreList = que.ToList();
            }

            return scoreList;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            IList<Scores> even = this.GetScores();
            list1.Items.Clear();
            foreach (Scores ec in even)
            {
                Entities n = new Entities();
                n.name = ec.holder_name;
                n.detail="Level "+ec.level+" in "+ec.cat_name;
                n.score =""+ec.record;
                n.theme = "/cat//"+ec.cat_name+".png";
                list1.Items.Add(n);
            }
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock click = (TextBlock)sender;
            MessageBoxResult res = MessageBox.Show("Do you want to view the score history for this category","Unjumble",MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new Uri("/history.xaml?name="+click.Text,UriKind.Relative));
            }
        }
    }
}