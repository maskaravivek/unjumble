using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.IO;
using System.IO.IsolatedStorage;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Windows.Threading;

namespace Unjumble
{
    public partial class game : PhoneApplicationPage
    {
        public class Data
        {
            public string let { get; set; }
        }
        private DispatcherTimer dispatcherTimer;
        int skips, lifes, score,level,hints,ques,right_ans,stars=1,tokens,temp;
        int remainingSeconds;
        String[] wor_lev = new String[10];
        List<string> wor=new List<string>();
        String file,s;
        String theme = "";
       
        public game()
        {
            InitializeComponent();
            
            level = 1;

            right_ans = 0;
            ques = 0;
            hints = 2;
            skips = 2;
            lifes = 3;
            score = 0;
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.EndTime = DateTime.MinValue;
            base.OnNavigatedFrom(e);
        }
        private DateTime EndTime { get; set; }
        private void tokensData()
        {
            int token = score / 100;
            tokens = temp + token;
            token_disp.Text = "" + tokens;
        }
        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var remaining = this.EndTime - DateTime.Now;
            remainingSeconds = (int)remaining.TotalSeconds;
            this.timeSpan.Value = TimeSpan.FromSeconds(remainingSeconds);

            if (remaining.TotalSeconds <= 0)
            {
                this.dispatcherTimer.Stop();
            }
        }
        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)//used for skips
        {
           
            hint.Text = String.Empty;
            if (skips ==2)
            {
                skips=1;
                BitmapImage bitmap = new BitmapImage(new Uri("/Images/used_skip.png", UriKind.Relative));
                skip2.Source = bitmap;
                player();
                answer.Text = s;
                ans.Text = String.Empty;
            }
            else if (skips == 1)
            {
                skips = 0;
                BitmapImage bitmap = new BitmapImage(new Uri("/Images/used_skip.png", UriKind.Relative));
                skip1.Source = bitmap;
                player();
                answer.Text = s;
                ans.Text = String.Empty;
            }

            else if (skips == 0)
                MessageBox.Show("No more skips allowed");

        }
        private String jumble(String word)
        {
            String[] w = word.Split(' ');
            String[] jum=new String[w.Length];
            String jumb="";
            for (int i = 0; i < w.Length; i++)
            {
                jum[i] = "";
                w[i] = w[i].ToLower();
                char[] c = w[i].ToCharArray();
                char ch;
                int ran1, ran2;
                Random r = new Random();
                for (int j = 0; j < w[i].Length; j++)
                {
                    ran1 = r.Next(0, w[i].Length - 1);
                    ran2 = r.Next(0, w[i].Length - 1);
                    ch = c[ran2];
                    //something 3-e 5-h ch=h 
                    c[ran2] = c[ran1];
                    c[ran1] = ch;
                }
                for (int k = 0; k < w[i].Length; k++)
                    jum[i] += c[k];
                if (jum[i].Equals(w[i]))
                    i--;
            }
            for (int i = 0; i < w.Length; i++)
                jumb += jum[i] + " ";
            jumb = jumb.Substring(0,jumb.Length-1);
                return jumb;
        }
        
        private void stackWork(String us)
        {
            list1.Items.Clear();
            char[] ch=us.ToCharArray();
            IEnumerable<char> vvk = ch.Distinct<char>();
            char[] characters = vvk.ToArray<char>();
            for (int i = 0; i < characters.Length; i++)
            {

                list1.Items.Add(""+characters[i]);
            }
            
        }
        private void player()
        {
            ans.Text = String.Empty;
            tokensData();
                hints = 2;
                String use;
                s = wor_lev[ques];
                use = jumble(wor_lev[ques]);
                question.Text = use;
                stackWork(use);
                answer.Text = s;
                if (ques < 9)
                    ques++;
                else if (ques == 9)
                {
                    ques = 0;
                    level++;
                    listGen(theme);
                    stars/=2;
                    if(stars==0)
                        stars=1;
                   
                    MessageBox.Show("Progress to Level " + level);
                    lvl.Text = "" + level;
                }
                this.EndTime = DateTime.MinValue;
                this.timeSpan.Value = TimeSpan.FromSeconds(30);
                if (this.dispatcherTimer == null)
                {
                    this.dispatcherTimer = new DispatcherTimer();
                    this.dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
                    this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                }

                if (this.EndTime == DateTime.MinValue)
                {
                    this.EndTime = DateTime.Now + (TimeSpan)this.timeSpan.Value;
                }

                this.dispatcherTimer.Start();
        }
        private void listGen(String file)
        { 
            String lin;
            int len;
            var resourceStream = Application.GetResourceStream(new Uri("theme\\places.txt", UriKind.RelativeOrAbsolute));
            if (resourceStream != null)
            {
                using (var reader = new StreamReader(resourceStream.Stream))
                {
                    int m = 0;
                        do
                        {
                           lin=reader.ReadLine();
                           if (lin == null)
                               continue;
                            len=lin.Length;
                          
                           if (level <= 3)
                           {
                               if (len <=12)
                               {
                                   m++;
                                   wor.Add(lin);
                               }
                           }
                           else if (level <= 6)
                           {
                               if (len>=6 && len<=8)
                                   wor.Add(lin);
                           }
                           else if (level <= 9)
                           {
                               if (len>8 && len<=10)
                                   wor.Add(lin);
                           }
                           else if (level >= 9)
                           {
                               if (len > 10)
                                   wor.Add(lin);
                           }
                        }
                        while(lin!=null);
                        Random r = new Random();
                        int man;
                        if (m > 10)
                            for (int i = 0; i < 10; i++)
                            {
                                man = r.Next(m - 1);
                                wor_lev[i] = wor.ElementAt(man);
                            }
                        else
                            for (int i = 0; i < 10; i++)
                                wor_lev[i] = "maskara";

                    }}
        }
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            hint.Text = String.Empty;
            if (meth(s, ans.Text)==true)
            {
                score += sc(level,hints);
                user_score.Text = ""+score;
                right_ans++;
                player();
                
            }
            else
            {
                if (lifes == 3)
                {
                    lifes = 2;
                    BitmapImage bitmap = new BitmapImage(new Uri("/Images/dead.png", UriKind.Relative));
                    life3.Source = bitmap;
                    player();
                    
                }
                else if (lifes == 2)
                {
                    lifes = 1;
                    BitmapImage bitmap = new BitmapImage(new Uri("/Images/dead.png", UriKind.Relative));
                    life2.Source = bitmap;
                    player();
                    
                }
                else if (lifes == 1)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri("/Images/dead.png", UriKind.Relative));
                    life1.Source = bitmap;
                    canv.Visibility = System.Windows.Visibility.Visible;
                    txt1.Text = ""+score;
                    
                }
            }

        }
        private void gameover()
        {
            UpdateScore(name.Text,Convert.ToInt32(user_score.Text));
            AddScoreHistory(name.Text, Convert.ToInt32(user_score.Text));
            tokens += (score / 100);
            IsolatedStorageFile myspace = IsolatedStorageFile.GetUserStoreForApplication();
            using (var isoFileStream = new IsolatedStorageFileStream("token.txt", FileMode.OpenOrCreate, myspace))
            {
                using (var isoFileWriter = new StreamWriter(isoFileStream))
                {
                    isoFileWriter.WriteLine(""+tokens);
                }
            }
            
        }
        private int sc(int level, int hints)
        {
            int scr=0;
            if (remainingSeconds > 0)
            {
                stars++;
                scr = (level * (2 + remainingSeconds)) + ques - (2 - hints);
            }
            else
                scr = (level * 2) + ques - (2 - hints);
            return scr;
        }// score calculated and updated
        private bool meth(String word,String input)
        {
            bool res=false;
            if (s.ToLower().Equals(input))
                res = true;
            return res;
        }//checks if the answer is true or false
        private void Image_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (hints == 2)
            {
                //hint_tag.Visibility = System.Windows.Visibility.Visible;
                hint.Text = "THe word starts with: " + s.ElementAt(0);
                hints=1;
            }
            else if (hints == 1)
            {
                hints = 0;
                hint.Text="The word starts with: "+s.ElementAt(0)+" and ends with: "+s.ElementAt(s.Length-1);
            }
            else if (hints == 0)
            {
                MessageBox.Show("No more hints available for this word!");
            }
        }//hints action when the hint image is tapped
        private void AddScoreHistory(String name, int scr)
        {
            try
            {
                using (UnjumbleDataContext cont = new UnjumbleDataContext(UnjumbleDataContext.DBConnectionString))
                {
                    scoreHistory sc = new scoreHistory();

                    sc.cat = theme;
                    sc.name = name;
                    sc.level = level;
                    sc.record = scr;
                    cont.scHist.InsertOnSubmit(sc);
                    cont.SubmitChanges();
                }
            }
            catch { }
        } 
        
        //score added to the database
        private void UpdateScore(String name, int scr)
        {
            try
            {
                using (UnjumbleDataContext cont = new UnjumbleDataContext(UnjumbleDataContext.DBConnectionString))
                {
                    IQueryable<Scores> entityQuery = from c in cont.Records where c.cat_name ==theme  select c;
                    Scores sc = entityQuery.FirstOrDefault();
                    int score = sc.record;
                    if (score < scr)
                    {
                        sc.holder_name = name;
                        sc.level = level;
                        sc.record = scr;
                        
                    }
                    
                    
                    cont.SubmitChanges();

                }
            }
            catch
            {
                MessageBox.Show("Some error occured");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gameover();
            canv.Visibility = System.Windows.Visibility.Collapsed;
            NavigationService.Navigate(new Uri("/Welcome.xaml",UriKind.Relative));
        }//score updated and navigated to welcome page
        private void ans_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if(ans.Text.Length>0)
            ans.Text = ans.Text.Substring(0, ans.Text.Length - 1);
        }// removes one character from the answer if the user wants to erase
        private void LayoutRoot_Loaded_1(object sender, RoutedEventArgs e)
        {
            String message = NavigationContext.QueryString["name"];
            title.Text = message;
            level = 1;
            lvl.Text = ""+level;
            theme = message;
            listGen(theme);
            player();
            int str;
            IsolatedStorageFile myspace = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                using (var isoFileStream = new IsolatedStorageFileStream("token.txt", FileMode.Open, myspace))
                {
                    using (var isoFileReader = new StreamReader(isoFileStream))
                    {
                        str = Convert.ToInt32(isoFileReader.ReadToEnd());
                    }
                }

            }
            catch
            {
                str = 0;
            }
            tokens = str;
            temp = str;
            token_disp.Text = "" + tokens;
        }

        private void Button_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Button button = (Button)sender;
            ans.Text += button.Content;
        }
    }
   
}