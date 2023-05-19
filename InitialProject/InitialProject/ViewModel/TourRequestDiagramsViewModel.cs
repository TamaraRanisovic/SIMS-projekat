using InitialProject.Commands;
using InitialProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class TourRequestDiagramsViewModel : BindableBase
    {
        public ICommand NavigateToDiagrams { get; set; }

        public TourRequestDiagramsViewModel()
        {
            NavigateToDiagrams = new DelegateCommand(ShowDiagram);
        }

        public void ShowDiagram(object diagram)
        {
            TouristViewModel touristViewModel = TouristViewModel.Instance;

            switch ((string)diagram)
            {
                case "language":
                    TourRequestDiagramsByLanguageView diagramsByLanguage = new TourRequestDiagramsByLanguageView();
                    touristViewModel.NavService.Navigate(diagramsByLanguage);
                    break;
                case "location":
                    TourRequestDiagramsByLocationView diagramsByLocation = new TourRequestDiagramsByLocationView();
                    touristViewModel.NavService.Navigate(diagramsByLocation);
                    break;
            }
        }
    }
}
