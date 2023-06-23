using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_Krosfy_Netcheck.Resources.ViewModel
{
    //EN PRUEBA NO SE HA UTILIZADO AUN EN NINGUNA PARTE DEL CODIGO
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool _activo;
        public bool _inactivo => !_activo;

        public BaseViewModel()
        {
            /*RefreshCommand = new AsyncRelayCommand(async () =>
            {
                _activo = true;
                await Task.Delay(5000);
                _activo = false;
            });*/
        }

        public bool Activo
        {
            get => _activo;
            set
            {
                if (_activo == value) return;
                _activo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_inactivo));
            }
        }
        //public AsyncRelayCommand RefreshCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string NombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
    }
}
