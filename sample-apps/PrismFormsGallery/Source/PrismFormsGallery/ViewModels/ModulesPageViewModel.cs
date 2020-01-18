using MvvmHelpers;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace PrismFormsGallery.ViewModels
{
    public class ModulesPageViewModel : BaseViewModel
    {
        private readonly IModuleManager _moduleManager;
        private readonly IModuleCatalog _moduleCatalog;

        public ModulesPageViewModel(IModuleManager moduleManager, IModuleCatalog moduleCatalog)
        {
            Title = "Modules";
            _moduleManager = moduleManager;
            _moduleCatalog = moduleCatalog;
            LoadModules();
            LoadCommand = new DelegateCommand<IModuleInfo>(OnLoadTapped);
        }

        private IEnumerable<IModuleInfo> _modules;
        public IEnumerable<IModuleInfo> Modules { get => _modules; private set { SetProperty(ref _modules, value); } }

        private void OnLoadTapped(IModuleInfo moduleInfo)
        {
            if (moduleInfo == null)
                return;

            IsBusy = true;
            _moduleManager.LoadModule(moduleInfo.ModuleName);
            LoadModules();
            IsBusy = false;
        }

        void LoadModules()
        {
            Modules = _moduleCatalog.Modules.OrderBy(_ => _.ModuleName);
        }

        public DelegateCommand<IModuleInfo> LoadCommand { get; }
    }
}
