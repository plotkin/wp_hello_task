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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace WindowsPhoneTasks
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Constructor

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Launchers

        private void btnPhoneCall_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask task = new PhoneCallTask();
            task.PhoneNumber = "1234567890";
            task.DisplayName = "Vangos Pterneas";
            task.Show();
        }

        private void btnComposeSms_Click(object sender, RoutedEventArgs e)
        {
            SmsComposeTask task = new SmsComposeTask();
            task.To = "1234567890";
            task.Body = "This is a sample SMS message.";
            task.Show();
        }

        private void btnComposeEmail_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask();
            task.To = "test@test.com";
            task.Cc = "test2@test.com";
            task.Subject = "Testing...";
            task.Body = "This is a sample e-mail message.";
            task.Show();
        }

        private void btnLaunchWebBrowser_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "http://www.google.com";
            task.Show();
        }

        private void btnLaunchSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchTask task = new SearchTask();
            task.SearchQuery = "Test Testerovich";
            task.Show();
        }

        private void btnLaunchMediaPlayer_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayerLauncher task = new MediaPlayerLauncher();
            task.Media = new Uri("http://ecn.channel9.msdn.com/o9/ch9/4807/574807/ISWPE05SLToolKitForWP_ch9.wmv");
            task.Show();
        }

        #endregion

        #region Choosers

        private void btnTakePhoto_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureTask task = new CameraCaptureTask();
            task.Completed += (s, evt) =>
            {
                if (evt.Error == null && evt.TaskResult == TaskResult.OK)
                {
                    BitmapImage bmpImage = new BitmapImage();
                    bmpImage.SetSource(evt.ChosenPhoto);
                    image.Source = bmpImage;
                }
            };
            task.Show();
        }

        private void btnSelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask task = new PhotoChooserTask();
            task.Completed += (s, evt) =>
            {
                if (evt.Error == null && evt.TaskResult == TaskResult.OK)
                {
                    BitmapImage bmpImage = new BitmapImage();
                    bmpImage.SetSource(evt.ChosenPhoto);
                    image.Source = bmpImage;
                }
            };
            task.Show();
        }

        private void btnSelectPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumberChooserTask task = new PhoneNumberChooserTask();
            task.Completed += (s, evt) =>
            {
                if (evt.Error == null && evt.TaskResult == TaskResult.OK)
                {
                    MessageBox.Show(evt.PhoneNumber + " phone number selected!");
                }
            };
            task.Show();
        }

        private void btnSelectEmailAddress_Click(object sender, RoutedEventArgs e)
        {
            EmailAddressChooserTask task = new EmailAddressChooserTask();
            task.Completed += (s, evt) =>
            {
                if (evt.Error == null && evt.TaskResult == TaskResult.OK)
                {
                    MessageBox.Show(evt.Email + " e-mail address selected!");
                }
            };
            task.Show();
        }

        private void btnSavePhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            SavePhoneNumberTask task = new SavePhoneNumberTask();
            task.PhoneNumber = "1234567890";
            task.Show();
        }

        private void btnSaveEmailAddress_Click(object sender, RoutedEventArgs e)
        {
            SaveEmailAddressTask task = new SaveEmailAddressTask();
            task.Email = "test@test.com";
            task.Show();
        }

        #endregion

        #region Combining Launchers and Choosers

        private void btnSms_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumberChooserTask contactsTask = new PhoneNumberChooserTask();
            contactsTask.Completed += (s, evt) =>
            {
                if (evt.Error == null && evt.TaskResult == TaskResult.OK)
                {
                    SmsComposeTask smsTask = new SmsComposeTask();
                    smsTask.Body = "Insert text from your application here.";
                    smsTask.To = evt.PhoneNumber;
                    smsTask.Show();
                }
            };
            contactsTask.Show();
        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            EmailAddressChooserTask contactsTask = new EmailAddressChooserTask();
            contactsTask.Completed += (s, evt) =>
            {
                if (evt.Error == null && evt.TaskResult == TaskResult.OK)
                {
                    EmailComposeTask emailTask = new EmailComposeTask();
                    emailTask.Body = "Insert text from your application here.";
                    emailTask.To = evt.Email;
                    emailTask.Show();
                }
            };
            contactsTask.Show();
        }

        #endregion

        private void BingMaps_OnClick(object sender, RoutedEventArgs e)
        {
            BingMapsTask bing = new BingMapsTask();
            bing.SearchTerm = "Moscow";
            bing.Show();
        }
    }
}