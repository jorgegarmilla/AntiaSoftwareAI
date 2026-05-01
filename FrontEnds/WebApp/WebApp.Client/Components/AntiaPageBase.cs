using Blazor.WhyDidYouRender.Components;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using WebApp.Client.Layout;
using WebApp.Client.ModelView;

namespace WebApp.Client.Components
{
    [Layout(typeof(MainLayout))]
    //[Layout(typeof(LeftMenuLayout))]
    public class AntiaComponentBase : TrackedComponentBase
    {
      
        protected override void OnInitialized()
        {
            base.OnInitialized();
            // Lógica compartida
        }

        [CascadingParameter]
        public AntiaTheme AntiaTheme { get; set; }

        [CascadingParameter]
        public string UserName { get; set; }

        private CultureInfo AntiaCultureInfo = CultureInfo.GetCultureInfo("es-ES");

    }
}
