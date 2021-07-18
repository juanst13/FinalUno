using FinalUno.Components;
using FinalUno.Helpers;
using FinalUno.Models;
using FinalUno.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalUno
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static MainPage _instance;

        public MainPage()
        {
            InitializeComponent();
            _instance = this;
        }

        public TokenResponse tokenResponse { get; set; }

        public static MainPage GetInstance()
        {
            return _instance;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            tokenResponse = (TokenResponse)e.Parameter;
            LoadVoteAsync();
            WelcomeTextBlock.Text = $"Bienvenid@: {tokenResponse.User.Name}";
  
        }

        private async void LoadVoteAsync()
        {
            Loader loader = new Loader("Por favor espere...");
            loader.Show();
            Response response = await ApiService.GetListAsync<QuestionResponse>("Questions", tokenResponse.Token);
            loader.Close();

            if (!response.IsSuccess)
            {
                MessageDialog dialog = new MessageDialog(response.Message, "Error");
                await dialog.ShowAsync();
                return;
            }

            QuestionResponse questionResponse = (QuestionResponse)response.Result;
            QuestionTextBlock.Text = $"{questionResponse.Description}";
            Option1TextBlock.Text = $"{questionResponse.Options[0]}";
            Option2TextBlock.Text = $"{questionResponse.Options[1]}";
            Option3TextBlock.Text = $"{questionResponse.Options[2]}";
            Option4TextBlock.Text = $"{questionResponse.Options[3]}";

        }

        private async void AButton_Click(object sender, RoutedEventArgs e)
        {
            Response response = await ApiService.PostAsync("Questions", new QuestionRequest
            {
                QuestionId = 1,
                OptionId = 1
            }, tokenResponse.Token);

            if (!response.IsSuccess)
            {
                MessageDialog dialog = new MessageDialog(response.Message, "Error");
                if (response.Message == "Usuario ya votó.")
                {
                    Frame.Navigate(typeof(VotedPage), tokenResponse);
                }
                await dialog.ShowAsync();
                return;
            }

                MessageDialog messageDialog;
                messageDialog = new MessageDialog("Su voto ha sido registrado con éxito.", "Ok");
                Frame.Navigate(typeof(VotedPage), tokenResponse);
        }

        private async void BButton_Click(object sender, RoutedEventArgs e)
        {
            Response response = await ApiService.PostAsync("Questions", new QuestionRequest
            {
                QuestionId = 1,
                OptionId = 2
            }, tokenResponse.Token);

            if (!response.IsSuccess)
            {
                MessageDialog dialog = new MessageDialog(response.Message, "Error");
                await dialog.ShowAsync();
                return;
            }

            MessageDialog messageDialog;
            messageDialog = new MessageDialog("Su voto ha sido registrado con éxito.", "Ok");
            Frame.Navigate(typeof(VotedPage), tokenResponse);
        }

        private async void CButton_Click(object sender, RoutedEventArgs e)
        {
            Response response = await ApiService.PostAsync("Questions", new QuestionRequest
            {
                QuestionId = 1,
                OptionId = 3
            }, tokenResponse.Token);

            if (!response.IsSuccess)
            {
                MessageDialog dialog = new MessageDialog(response.Message, "Error");
                await dialog.ShowAsync();
                return;
            }

            MessageDialog messageDialog;
            messageDialog = new MessageDialog("Su voto ha sido registrado con éxito.", "Ok");
            Frame.Navigate(typeof(VotedPage), tokenResponse);
        }

        private async void DButton_Click(object sender, RoutedEventArgs e)
        {
            Response response = await ApiService.PostAsync("Questions", new QuestionRequest
            {
                QuestionId = 1,
                OptionId = 4
            }, tokenResponse.Token);

            if (!response.IsSuccess)
            {
                MessageDialog dialog = new MessageDialog(response.Message, "Error");
                await dialog.ShowAsync();
                return;
            }

            MessageDialog messageDialog;
            messageDialog = new MessageDialog("Su voto ha sido registrado con éxito.", "Ok");
            Frame.Navigate(typeof(VotedPage), tokenResponse);
        }


    }
}
