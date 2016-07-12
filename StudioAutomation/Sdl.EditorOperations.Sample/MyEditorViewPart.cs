using System;
using System.Linq;
using System.Windows.Forms;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Sdl.EditorOperations.Sample
{
    [ViewPart(
        Id = "MyEditorViewPart", 
        Name = "My Editor View Part", 
        Description = "Integrationg a view part inside the editor view"        
        )]
    [ViewPartLayout(typeof(EditorController), Dock = DockType.Bottom)]
    class MyEditorViewPart : AbstractViewPartController
    {
        protected override Control GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {                        
        }
       
        private static readonly Lazy<MyEditorViewPartControl> _control = new Lazy<MyEditorViewPartControl>(() => new MyEditorViewPartControl());       
    }
}
