using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation;
using System.Diagnostics;

namespace Sdl.StudioInitializer.Sample
{
    public static class StudioTracking
    {
        private static Stopwatch _tracker;

        public static void Start()
        {
            _tracker = Stopwatch.StartNew();
        }

        public static TimeSpan Elapsed
        {
            get { return _tracker.Elapsed; }
        }

        public static void Stop()
        {
            _tracker.Stop();
            _tracker = null;
        }
    }
}
