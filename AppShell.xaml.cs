using MauiApp_Krosfy_Netcheck.Resources.Views;

namespace MauiApp_Krosfy_Netcheck;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainKrosfyNetCheck), typeof(MainKrosfyNetCheck));
        Routing.RegisterRoute(nameof(ContentKrosfyNetCheck), typeof(ContentKrosfyNetCheck));
    }
}
