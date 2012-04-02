using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using PhoneApp1.ServiceReference2;
using Microsoft.Xna.Framework.Audio;
using System.Collections.ObjectModel;

namespace PhoneApp1
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        string AppId = "UserYourAppId";

        public PanoramaPage1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameworkDispatcher.Update();
                var objTranslator = new ServiceReference2.LanguageServiceClient();
                objTranslator.GetLanguagesForSpeakCompleted +=
                  new EventHandler<GetLanguagesForSpeakCompletedEventArgs>(
                  translator_GetLanguagesForSpeakCompleted);
                objTranslator.GetLanguagesForSpeakAsync(AppId, objTranslator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void translator_GetLanguagesForSpeakCompleted(object sender, GetLanguagesForSpeakCompletedEventArgs e)
        {
            var objTranslator = e.UserState as ServiceReference2.LanguageServiceClient;
            objTranslator.GetLanguageNamesCompleted += new EventHandler<GetLanguageNamesCompletedEventArgs>(translator_GetLanguageNamesCompleted);
            objTranslator.GetLanguageNamesAsync(AppId, "en", e.Result, e.Result);
        }

        void translator_GetLanguageNamesCompleted(object sender, GetLanguageNamesCompletedEventArgs e)
        {
            var codes = e.UserState as ObservableCollection<string>;
            var names = e.Result;
            var languagesData = (from code in codes
                                 let cindex = codes.IndexOf(code)
                                 from name in names
                                 let nindex = names.IndexOf(name)
                                 where cindex == nindex
                                 select new TranslatorLanguage()
                                 {
                                     Name = name,
                                     Code = code
                                 }).ToArray();
            this.Dispatcher.BeginInvoke(() =>
            {
                this.ListLanguages.ItemsSource = languagesData;
            });
        }

        private void btnSpeak_Click(object sender, RoutedEventArgs e)
        {

            if (!AppId.Contains("UserYourAppId"))
            {
                var languageCode = "en";
                var language = this.ListLanguages.SelectedItem as TranslatorLanguage;
                if (language != null)
                {
                    languageCode = language.Code;
                }
                var objTranslator = new ServiceReference2.LanguageServiceClient();
                objTranslator.SpeakCompleted += translator_SpeakCompleted;
                objTranslator.SpeakAsync(AppId, this.TextToSpeachText.Text, languageCode, "audio/wav");

                panoSpeech.DefaultItem = panoSpeech.Items[(int)2];
            }
            else
            {
                MessageBox.Show("Please Add your AppId");
            }



        }

        void translator_SpeakCompleted(object sender, ServiceReference2.SpeakCompletedEventArgs e)
        {
            var client = new WebClient();
            client.OpenReadCompleted += ((s, args) =>
            {
                SoundEffect se = SoundEffect.FromStream(args.Result);
                se.Play();
            });
            client.OpenReadAsync(new Uri(e.Result));

        }
    }
}