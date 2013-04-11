using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Net;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Linq;
using System.Windows;

namespace Unjumble
{
    public partial class featured : PhoneApplicationPage
    {
        public class Data
        {
            public string round { get; set; }
            public string news { get; set; }
        }
        public featured()
        {
            InitializeComponent();
            int i = 0;
            Data n = new Data();
            WebClient client = new WebClient();
            client.OpenReadCompleted += (sender, e) =>
            {
                try
                {
                    if (e.Error != null)
                        return;
                    Stream str = e.Result;
                    XDocument loadedData = XDocument.Load(str);
                    foreach (var item in loadedData.Descendants("entry"))
                    {
                        n.round = (string)item.Element("title").Value;
                        n.news = (string)item.Element("summary").Value;
                        list1.Items.Add(n);
                    };
                    progress.Visibility = System.Windows.Visibility.Collapsed;
                    if (i == 0)
                        MessageBox.Show("Results are yet not avaliable for this event");
                }
                catch
                {
                    MessageBox.Show("Results not avaliable at this moment");
                }
            };

            client.OpenReadAsync(new Uri("http://oxforddictionaries.com/wordoftheday/wotdrss.xml", UriKind.Absolute));

        }

        

    }
}