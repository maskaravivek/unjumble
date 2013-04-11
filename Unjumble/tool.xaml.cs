using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using Microsoft.Phone.Tasks;

namespace Unjumble
{
    public partial class tool : PhoneApplicationPage
    {
        public tool()
        {
            InitializeComponent();
        }
        List<string> word = new List<string>();

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            prog.Visibility = System.Windows.Visibility.Visible;
            String c = tt.Text;
            
            String filename;
            int temp = 0;

            for (int k = 0; k < c.Length; k++)
            {
                filename = "words\\" + c.Substring(k, 1) + ".txt";
                var resourceStream = Application.GetResourceStream(new Uri(filename, UriKind.RelativeOrAbsolute));
                if (resourceStream != null)
                {
                    using (var reader = new StreamReader(resourceStream.Stream))
                    {
                        string line;
                        String tes;
                        int m = 0;
                        do
                        {
                            line = reader.ReadLine();
                            tes = line;
                            if (string.IsNullOrEmpty(line))
                                continue;
                            else
                            {
                                temp = 0;

                                //for (int i = 0; i < line.Length; i++)
                                //{
                                for (int j = 0; j < c.Length; j++)
                                {
                                    m = 0;
                                    if (tes.Contains(c.ElementAt(j)))
                                    {
                                        temp++;
                                        int ind = tes.IndexOf(c.ElementAt(j));
                                        tes = tes.Substring(0, ind) + "*" + tes.Substring(ind + 1);
                                    }
                                }
                                //}
                                if (temp == line.Length && line.Length>=3)
                                {
                                    if (chk1.IsChecked == true)
                                    {
                                        if (line.Length == c.Length)
                                        {if(!word.Contains(line))
                                            word.Add(line);
                                        }
                                    }
                                    else if (leng.IsChecked == true)
                                    {
                                        if (line.Length == Convert.ToInt32(box.Text))
                                            if (!word.Contains(line))
                                            word.Add(line);
                                    }
                                    else
                                        if (!word.Contains(line))
                                            word.Add(line);
                                }
                            }
                        } while (line != null);

                    }
                }
            }
            prog.Visibility = System.Windows.Visibility.Collapsed;
            if (word.Count == 0)
                MessageBox.Show("No possible word from the collection");
            else
            list1.ItemsSource = word;
            count.Text = ""+word.Count;

        }

        private void chk1_Checked(object sender, RoutedEventArgs e)
        {
            leng.IsEnabled = false;
            box.IsEnabled = false;
        }

        private void leng_Checked(object sender, RoutedEventArgs e)
        {
            chk1.IsEnabled = false;
            box.IsEnabled = true;
        }

        private void chk1_Unchecked(object sender, RoutedEventArgs e)
        {
            leng.IsEnabled = true;
            box.IsEnabled = false;
        }

        private void leng_Unchecked(object sender, RoutedEventArgs e)
        {
            chk1.IsEnabled = true;
            box.IsEnabled = false;
        }

        

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock click = (TextBlock)sender;
            SearchTask searchTask = new SearchTask();

            searchTask.SearchQuery = click.Text;

            searchTask.Show();
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            String message="Have a look at Unjumble app i am using. It lets me search for all words possible from specified letters";
            if (!tt.Text.Equals(""))
                message = "Try out Unjumble and see what words can be made using the letters "+tt.Text;
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = "Unjumble";
            shareLinkTask.LinkUri = new Uri("http://devilsnarewp7.com", UriKind.Absolute);//change the link address
            shareLinkTask.Message = message;

            shareLinkTask.Show();
        }

        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            String message = "Try out Unjumble on windows phone and see what words can be made from specified letters ";
            if (!tt.Text.Equals(""))
            {
                message = "Try out unjumble on windows phone and see what words can be made using the letters "+tt.Text;
                if (!count.Text.Equals(""))
                    message = "Try out unjumble on windows phone and see what words can be made using the letters " + tt.Text+". I found out that "+count.Text+ " words are possible.";
            }
            SmsComposeTask sms = new SmsComposeTask();
            sms.Body = message;
            sms.Show();

        }

        private void ApplicationBarMenuItem_Click_3(object sender, EventArgs e)
        {
            String mes = "";
            EmailComposeTask email = new EmailComposeTask();
            String message = "Try out Unjumble on windows phone and see what words can be made from specified letters ";
            if (!tt.Text.Equals(""))
            {
                message = "Try out unjumble on windows phone and see what words can be made using the letters " + tt.Text;
                if (!count.Text.Equals(""))
                {
                    message = "Try out unjumble on windows phone and see what words can be made using the letters " + tt.Text + ". I found out that " + count.Text + " words are possible.";
                    for (int i = 0; i < word.Count; i++)
                        mes += word.ElementAt(i) + ", ";
                    mes.Substring(0, mes.Length - 2);
                    message += "\nWords possible are " + mes;
                }
            }
            email.Body = message;
            email.Subject = "Unjumble!!";
            email.Show();
            

        }

        
    }
}