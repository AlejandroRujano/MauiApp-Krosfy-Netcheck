using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_Krosfy_Netcheck.Resources.Model
{
    //INTERFAZ DE RED
    public class Adaptador
    {
        private string _id;
        private string _nombre;
        private string _descripcion;
        private long _velocidadBits;
        private double _velocidadMbps;
        private IPAddress _ipv4;
        private UnicastIPAddressInformationCollection _coleccionIP; // Configuracion, Datos de la IP
        public Adaptador(NetworkInterface Interfaz)
        {
            _id = Interfaz.Id;
            _nombre = Interfaz.Name;
            _descripcion = Interfaz.Description;
            _velocidadBits = Interfaz.Speed;
            _velocidadMbps = Math.Round(_velocidadBits / 1000000.0, 2);
            _coleccionIP = Interfaz.GetIPProperties().UnicastAddresses;
            _ipv4 = _coleccionIP.First(x => !x.Address.IsIPv6LinkLocal).Address;
        }
        public string Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _nombre; } set { _nombre = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public long VelocidadBits { get { return _velocidadBits; } set { _velocidadBits = value; } }
        public double VelocidadMbps { get { return _velocidadMbps; } set { _velocidadMbps = value; } }
        public IPAddress IPv4 { get { return _ipv4; } }
        public UnicastIPAddressInformationCollection CollecionIP { get { return _coleccionIP; } set { _coleccionIP = value; } }
    }
}
