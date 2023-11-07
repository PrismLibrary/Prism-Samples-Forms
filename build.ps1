$projects = @(
    '01-HelloPrism', '02-ServiceRegistration', '03-PlatformSpecificServices', '04-Commands',
    '04-CompositeCommands', '05-EventAggregator', '06-PageDialogService', '07-DialogService',
    '08-TabbedNavigation', '09-MasterDetail', '10-Modules', '11-ModuleDependency', '12-ViewModelLocator',
    '13-ViewModelInitialization', '14-EventToCommandBehavior', '15-PageBehaviorFactory', '16-PageLifecycleAware',
    '17-XamlNavigation', '18-DeviceService', '19-NavigationMode', '20-ConfirmNavigation',
    'advanced-topics/ReactiveUI'
)

Write-Host "Building projects..."
foreach ($project in $projects) {
    Write-Host "Building $project - Android"
    msbuild.exe $project/src/PrismSample.Android/PrismSample.Android.csproj /r /p:SolutionDir=$project /p:Configuration=Debug /p:Platform=AnyCPU
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}
