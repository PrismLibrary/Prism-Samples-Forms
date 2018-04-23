using System;
using ContosoCookbook.Business;
using Prism.Navigation;

namespace ContosoCookbook.ViewModels
{
    public class RecipePageViewModel : ViewModelBase, INavigationAware
    {
        private Recipe _recipe;
        public Recipe Recipe
        {
            get => _recipe;
            set => SetProperty(ref _recipe, value);
        }

        public RecipePageViewModel()
        {

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("recipe"))
                Recipe = parameters.GetValue<Recipe>("recipe");
        }
    }
}