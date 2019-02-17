using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TriggerTheBomb
{
    public partial class MainPage : ContentPage
    {
        static string bomb = new Random()
            .Next(1, 4)
            .ToString();
        int scores = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == bomb)
            {
                await DisplayAlert("Bomb Exploded", "Game Over", "Retry");
                bomb = new Random()
                            .Next(1, 4)
                            .ToString();
                scores = 0;
            }
            else
            {
                scores++;
                await DisplayAlert("Bomb Defused!", "Scores: " + scores, "Continue");
                bomb = new Random()
                            .Next(1, 4)
                            .ToString();

            }
        }
    }
}
