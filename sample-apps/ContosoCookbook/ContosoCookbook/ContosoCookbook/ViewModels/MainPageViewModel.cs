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
            RecipeSelectedCommand = new DelegateCommand<Recipe>(RecipeSelected, _ => !IsBusy).ObservesProperty(() => IsBusy);
        }

        public DelegateCommand<Recipe> RecipeSelectedCommand { get; }

        private ObservableCollection<RecipeGroup> _recipeGroups;
        public ObservableCollection<RecipeGroup> RecipeGroups
        {
            get => _recipeGroups;
            set => SetProperty(ref _recipeGroups, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private async void RecipeSelected(Recipe recipe)
        {
            IsBusy = true;
            var p = new NavigationParameters
            {
                { "recipe", recipe }
            };

            await _navigationService.NavigateAsync("RecipePage", p);
            IsBusy = false;
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            if (RecipeGroups == null)
                RecipeGroups = new ObservableCollection<RecipeGroup>(await _recipeService.GetRecipeGroups());
        }
    }
}