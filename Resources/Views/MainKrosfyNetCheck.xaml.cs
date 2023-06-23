using MauiApp_Krosfy_Netcheck.Resources.ViewModel;

namespace MauiApp_Krosfy_Netcheck.Resources.Views;

public partial class MainKrosfyNetCheck : ContentPage
{
    private BaseViewModel ViewModel = new BaseViewModel(); //AUN NO ESTA EN USO
    private readonly Animation _animacionRotacion;
    private readonly Animation _animacionBrillar;
    public MainKrosfyNetCheck()
	{
		InitializeComponent();

        _animacionRotacion = new Animation(x => ImgCentral.Rotation = x, 0, 360, Easing.Linear);
        _animacionBrillar = new Animation(x => BordeBtnAnalizar.Opacity = x, 1, 0.3, Easing.BounceIn);

        ViewModel.PropertyChanged += ViewModel_PropertyChanged; //SIN USO
    }

    //SIN USO
    private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ViewModel.Activo))
        {
            if (ViewModel.Activo)
            {
                _animacionRotacion.Commit(this, "Rotar", 16, 1000, Easing.Linear,
                    (v, c) => ImgCentral.Rotation = 0, () => true);
            }
            else
            {
                this.AbortAnimation("Rotar");
            }
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        ImgCentral.IsEnabled = true;
        BtnAnalizar.IsEnabled = true;

        _animacionRotacion.Commit(this, "Rotar", 16, 5000, Easing.Linear,
                    null, () => true);

        _animacionBrillar.Commit(this, "Brillar", 16, 2000, Easing.Linear,
                    null, () => true);
    }

    private async void BtnAnalizar_Clicked(object sender, EventArgs e)
    {
        ImgCentral.IsEnabled = false;
        BtnAnalizar.IsEnabled = false;
        BordeBtnAnalizar.Opacity = 1;
        this.AbortAnimation("Brillar");

        var _cambioDeVentana = Shell.Current.GoToAsync(nameof(ContentKrosfyNetCheck), false);

        await Task.WhenAny(_cambioDeVentana);

        /*if (_cambioDeVentana.IsCompleted)
        {
            ImgCentral.IsEnabled = true;
            BtnAnalizar.IsEnabled = true;
        }*/
    }
}