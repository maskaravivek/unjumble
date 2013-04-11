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
    public partial class history : PhoneApplicationPage
    {
        public class Entities
        {
            public string name { get; set; }
            public string detail { get; set; }
            public string score { get; set; }
            public string theme { get; set; }
        }
        public history()
        {
            InitializeComponent();
        }
        public IList<scoreHistory> GetScores()
        {
            IList<scoreHistory> scoreList = null;
            using (UnjumbleDataContext context = new UnjumbleDataContext(UnjumbleDataContext.DBConnectionString))
            {
                IQueryable<scoreHistory> que = from c in context.scHist select c;
                scoreList = que.ToList();
            }

            return scoreList;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            String na=NavigationContext.QueryString["name"];
            IList<scoreHistory> even = this.GetScores();
            list1.Items.Clear();
            foreach (scoreHistory ec in even)
            {
                if (ec.cat.Equals(na))
                {
                    Entities n = new Entities();
                    n.name = ec.name;
                    n.detail = "Level " + ec.level + " in " + na;
                    n.score = "" + ec.record;
                    n.theme = "/cat//" + na + ".png";
                    list1.Items.Add(n);
                }
            }
        }
    }
}