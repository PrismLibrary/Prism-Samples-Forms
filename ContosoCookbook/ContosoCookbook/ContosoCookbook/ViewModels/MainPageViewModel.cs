using ContosoCookbook.Business;
using ContosoCookbook.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace ContosoCookbook.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;
        IRecipeService _recipeService;

        DelegateCommand<Recipe> _recipeSelectedCommand;
        public DelegateCommand<Recipe> RecipeSelectedCommand => _recipeSelectedCommand != null ? _recipeSelectedCommand : (_recipeSelectedCommand = new DelegateCommand<Recipe>(RecipeSelected));

        private ObservableCollection<RecipeGroup> _recipeGroups;
        public ObservableCollection<RecipeGroup> RecipeGroups
        {
            get { return _recipeGroups; }
            set { SetProperty(ref _recipeGroups, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IRecipeService recipeService)
        {
            _navigationService = navigationService;
            _recipeService = recipeService;
        }

        private async void RecipeSelected(Recipe recipe)
        {
            var p = new NavigationParameters();
            p.Add("recipe", recipe);

            await _navigationService.NavigateAsync("RecipePage", p);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (RecipeGroups == null)
                RecipeGroups = new ObservableCollection<RecipeGroup>(await _recipeService.GetRecipeGroups());
        }
    }
}