using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Unjumble
{
    public partial class Welcome : PhoneApplicationPage
    {
        
        public Welcome()
        {
            InitializeComponent();
            String[] cat = { "Mixed", "Hollywood", "Lifestyle", "Music", "People", "Places", "Kids", "Dictionary", "Movies", "Halloween", "Cricket", "Tennis" };
            using (UnjumbleDataContext context = new UnjumbleDataContext(UnjumbleDataContext.DBConnectionString))
            {

                if (!context.DatabaseExists())
                {
                    // create database if it does not exist
                    context.CreateDatabase();
                    for (int i = 0; i < 12; i++)
                    {
                        AddScore("Annoymous",0,cat[i]);
                    }
                    
                }
            }
            
            
        }
        private void AddScore(String name, int scr,String theme)
        {
            try
            {
                using (UnjumbleDataContext cont = new UnjumbleDataContext(UnjumbleDataContext.DBConnectionString))
                {
                    Scores sc = new Scores();

                    sc.holder_name = name;
                    sc.cat_name = theme;
                    sc.level = 1;
                    sc.record = scr;
                    cont.Records.InsertOnSubmit(sc);
                    cont.SubmitChanges();
                }
            }
            catch
            {
                MessageBox.Show("Some error occured");
            }
        }
        private void HubTile_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Categories.xaml",UriKind.Relative));
        }

        private void HubTile_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/scores.xaml", UriKind.Relative));
        }
    }
    public class UnjumbleDataContext : DataContext
    {
        public static string DBConnectionString = "Data Source=isostore:/Unjumble.sdf";
        public UnjumbleDataContext(string connectionString)
            : base(connectionString)
        { }
        
        public Table<Scores> Records
        {
            get
            {
                return this.GetTable<Scores>();
            }
        }
        public Table<scoreHistory> scHist
        {
            get
            {
                return this.GetTable<scoreHistory>();
            }
        }

    }
    
    [Table]
    public class Scores
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int serial
        {
            get;
            set;
        }
        [Column]
        public string holder_name
        {
            get;
            set;
        }
        [Column]
        public string cat_name
        {
            get;
            set;
        }
        [Column]
        public int level
        {
            get;
            set;
        }
        [Column]
        public int record
        {
            get;
            set;
        }
    }
    [Table]
    public class scoreHistory
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int serial
        {
            get;
            set;
        }
        [Column]
        public string cat
        {
            get;
            set;
        }
        [Column]
        public string name
        {
            get;
            set;
        }
        public int level
        {
            get;
            set;
        }
        [Column]
        public int record
        {
            get;
            set;
        }
    }
   
}