using System;
using System.Threading.Tasks;
using Prism.Services.Dialogs;

namespace PrismSample
{
    public static class DialogExtensions
    {
        public static Task<IDialogResult> ShowDialogAsync(this IDialogService dialogService,
            string name)
        {
            var tcs = new TaskCompletionSource<IDialogResult>();

            try
            {
                dialogService.ShowDialog(name, (result) => {
                    tcs.SetResult(result);
                });
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
            return tcs.Task;
        }

        public static Task<IDialogResult> ShowDialogAsync(this IDialogService dialogService,
            string name,
            IDialogParameters parameters)
        {
            var tcs = new TaskCompletionSource<IDialogResult>();

            try
            {
                dialogService.ShowDialog(name, parameters, (result) => {
                    if (result.Exception != null)
                    {
                        tcs.SetException(result.Exception);
                        return;
                    }
                    tcs.SetResult(result);
                });
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
            return tcs.Task;
        }
        
        public static Task<T> ShowDialogAsync<T>(this IDialogService dialogService,
            string name)
        {
            var tcs = new TaskCompletionSource<T>();

            try
            {
                dialogService.ShowDialog(name, (result) =>
                {
                    if (result.Exception != null)
                    {
                        tcs.SetException(result.Exception);
                        return;
                    }
                    tcs.SetResult(result.Parameters.GetValue<T>(typeof(T).Name));
                });
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
            return tcs.Task;
        }
    }
}
