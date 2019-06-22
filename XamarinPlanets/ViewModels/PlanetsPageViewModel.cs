using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XamarinPlanets.Models;

namespace XamarinPlanets.ViewModels
{
    public class PlanetsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Planet> Planets { get; set; }

        public PlanetsPageViewModel()
        {
            Planets = new ObservableCollection<Planet>()
            {
                new Planet() {Name = "Mercury", Description = "1st planet", ImageUrl = "https://amp.insider.com/images/5556438cecad041129e9a60c-1334-999.jpg"},
                new Planet() {Name = "Venus", Description = "2nd planet", ImageUrl = "https://planetary.s3.amazonaws.com/assets/images/2-venus/20180113_uvi_20160517_201715_365_l2b_v10_PseudoRGB.jpg"},
                new Planet() {Name = "Earth", Description = "3rd planet", ImageUrl = "https://www.gstatic.com/earth/social/00_generic_facebook-001.jpg"},
                new Planet() {Name = "Mars", Description = "4th planet", ImageUrl = "https://media.mnn.com/assets/images/2018/07/MarsTrueColorOSIRISRosettaSpacecraft2007.jpg.1000x0_q80_crop-smart.jpg"},
                new Planet() {Name = "Jupiter", Description = "5th planet", ImageUrl = "https://media.mnn.com/assets/images/2016/06/jupiter-nasa.jpg.638x0_q80_crop-smart.jpg"},
                new Planet() {Name = "Saturn", Description = "6th planet", ImageUrl = "https://solarsystem.nasa.gov/system/news_items/main_images/12983_7504_PIA21046_1280.jpg"},
                new Planet() {Name = "Neptun", Description = "7th planet", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/06/Neptune.jpg/300px-Neptune.jpg"},
                new Planet() {Name = "Pluto", Description = "8th planet", ImageUrl = "https://solarsystem.nasa.gov/system/resources/detail_files/933_BIG_P_COLOR_2_TRUE_COLOR1_1980.jpg"}
            };
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (_searchTerm != value)
                {
                    _searchTerm = value;
                    Filter(_searchTerm);
                }
            }
        }

        public string SearchPlaceholder { get { return "Enter planet name to filter"; } }

        private Command<object> _searchCommand;

        public Command<object> SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<object>(Filter));
            }
        }

        private void Filter(object searchTerm)
        {
            string searchFor = searchTerm as string;
            if (!string.IsNullOrEmpty(searchFor))
            {
                var planets = Planets.Where(p => p.Name.Contains(searchFor));
                Planets = new ObservableCollection<Planet>(planets);
                OnPropertyChanged("Planets");
            }
        }

        protected virtual void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
