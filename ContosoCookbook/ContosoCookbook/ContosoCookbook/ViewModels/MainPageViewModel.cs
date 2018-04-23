using ContosoCookbook.Business;
using ContosoCookbook.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace ContosoCookbook.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService { get; }
        private IRecipeService _recipeService { get; }

        public MainPageViewModel(INavigationService navigationService, IRecipeService recipeService)
        {
            _navigationService = navigationService;
            _recipeService = recipeService;
            RecipeSelectedCommand = new DelegateCommand<Recipe>(RecipeSelected);
        }

        public DelegateCommand<Recipe> RecipeSelectedCommand { get; }

        private ObservableCollection<RecipeGroup> _recipeGroups;
        public ObservableCollection<RecipeGroup> RecipeGroups
        {
            get => _recipeGroups;
            set => SetProperty(ref _recipeGroups, value);
        }

        private async void RecipeSelected(Recipe recipe)
        {
            var p = new NavigationParameters
            {
                { "recipe", recipe }
            };

            await _navigationService.NavigateAsync("RecipePage", p);
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            if (RecipeGroups == null)
                RecipeGroups = new ObservableCollection<RecipeGroup>(await _recipeService.GetRecipeGroups());
        }
    }
}