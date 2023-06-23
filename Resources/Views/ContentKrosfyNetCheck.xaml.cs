using MauiApp_Krosfy_Netcheck.Resources.Model;
using System.Net.NetworkInformation;

namespace MauiApp_Krosfy_Netcheck.Resources.Views;

public partial class ContentKrosfyNetCheck : ContentPage
{
    private Adaptador _adaptadorActivo;
    private readonly Animation _animacionSacudirPadre;
    private readonly Animation _animacionSacudir1;
    private readonly Animation _animacionSacudir2;
    private readonly Animation _animacionSacudir3;
    public ContentKrosfyNetCheck()
	{
		InitializeComponent();

        _animacionSacudirPadre = new Animation();
        _animacionSacudir1 = new Animation(x => ImgCheck.Rotation = x, 0, 30, Easing.Linear);
        _animacionSacudir2 = new Animation(x => ImgCheck.Rotation = x, 30, -20, Easing.Linear);
        _animacionSacudir3 = new Animation(x => ImgCheck.Rotation = x, -20, 0, Easing.Linear);

        _animacionSacudirPadre.Add(0, 0.33, _animacionSacudir1);
        _animacionSacudirPadre.Add(0.33, 0.66, _animacionSacudir2);
        _animacionSacudirPadre.Add(0.66, 1, _animacionSacudir3);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var _networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        //_adaptadorActivo = Funciones.ObtenerInterfacesActivas(_networkInterfaces);

        _adaptadorActivo = Funciones.ObtenerInterfazActiva(_networkInterfaces);

        GridSuperior.BindingContext = _adaptadorActivo;

        GridDesplegable.BindingContext = _adaptadorActivo;

        _animacionSacudirPadre.Commit(this, "Sacudir", 16, 1000, Easing.Linear,
                    null, () => false);

        //await ImgCheck.ScaleTo(1.25, 2500, Easing.Linear);
        //ImgCheck.FadeTo(1, 1000, Easing.Linear);
        //await ImgCheck.ScaleTo(1, 1200, Easing.Linear);

        //BindableLayout.SetItemsSource(GridSuperior, _adaptadorActivo);
    }

    private void BtnRegresar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private async void BtnMostrasMas_Clicked(object sender, EventArgs e)
    {
        if (!GridDesplegable.IsVisible)
        {
            GridDesplegable.Opacity = 1;
            VerticalDesplegable1.Opacity = 0;
            VerticalDesplegable2.Opacity = 0;
            VerticalDesplegable3.Opacity = 0;
            VerticalDesplegable4.Opacity = 0;
            VerticalDesplegable5.Opacity = 0;

            GridDesplegable.IsVisible = true;

            await VerticalDesplegable1.FadeTo(1, 200, Easing.Linear);
            await VerticalDesplegable2.FadeTo(1, 200, Easing.Linear);
            await VerticalDesplegable3.FadeTo(1, 200, Easing.Linear);
            await VerticalDesplegable4.FadeTo(1, 200, Easing.Linear);
            await VerticalDesplegable5.FadeTo(1, 200, Easing.Linear);
        }
        else
        {
            await GridDesplegable.FadeTo(0, 200, Easing.Linear);
            GridDesplegable.IsVisible = false;
        }
    }
}