using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using System.Threading.Tasks;

namespace Mobile.Assets
{
    public sealed class AsyncTimer : CancellationTokenSource
    {
        public AsyncTimer(Func<Task> callback, int millisecondsDueTime, int millisecondsPeriod)
        {
            Task.Run(async () =>
            {
                await Task.Delay(millisecondsDueTime, Token);
                while (!IsCancellationRequested)
                {
                    await callback();
                    if (!IsCancellationRequested)
                        await Task.Delay(millisecondsPeriod, Token).ConfigureAwait(false);
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Cancel();

            base.Dispose(disposing);
        }
    }
}