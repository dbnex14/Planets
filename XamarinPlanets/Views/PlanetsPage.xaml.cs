using System.ComponentModel;
using System.Threading.Tasks;
using Refit;
using Xamarin.Forms;
using XamarinPlanets.Models;
using XamarinPlanets.Services;
using XamarinPlanets.ViewModels;

namespace XamarinPlanets.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class PlanetsPage : ContentPage
    {
        private readonly PlanetsPageViewModel _planetsViewModel;

        public PlanetsPage()
        {
            InitializeComponent();
            _planetsViewModel = new PlanetsPageViewModel();
            BindingContext = _planetsViewModel;
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Planet tappedPlannet = e.Item as Planet;
            DisplayAlert(tappedPlannet.Name, $"You tapped on {tappedPlannet.Name}", "OK");
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _planetsViewModel.SearchTerm = e.NewTextValue;
        }

        private async Task CallApiAsync()
        {
            var apiResponse = RestService.For<IPlanetApi>("https://api.le-systeme-solaire.net");
            var planets = await apiResponse.GetPlanets();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await CallApiAsync();
        }
    }
}
