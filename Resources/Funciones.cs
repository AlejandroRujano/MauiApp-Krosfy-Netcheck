using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MauiApp_Krosfy_Netcheck.Resources.Model;

namespace MauiApp_Krosfy_Netcheck.Resources
{
    public static class Funciones
    {
        /*private static bool _cambioDeVentana = false;
        public static bool CambioDeVentana{ get { return _cambioDeVentana; } set { _cambioDeVentana = value; } }*/
        public static Adaptador ObtenerInterfazActiva(NetworkInterface[] Interfaces)
        {
            Adaptador _adaptador;

            IPAddress[] _direccionesIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            IPAddress _direccionIPv4 = _direccionesIP.First(x => !x.IsIPv6LinkLocal);

            foreach (NetworkInterface Interfaz in Interfaces
                .Where(InterfazDeRed => InterfazDeRed.OperationalStatus == OperationalStatus.Up
                && InterfazDeRed.NetworkInterfaceType != NetworkInterfaceType.Loopback))
            {
                foreach (UnicastIPAddressInformation IpInfo in Interfaz.GetIPProperties().UnicastAddresses
                    .Where(x => !x.Address.IsIPv6LinkLocal && x.Address.AddressFamily == _direccionIPv4.AddressFamily))
                {
                    return _adaptador = new Adaptador(Interfaz);
                }
            }

            return null;
        }
        public static List<Adaptador> ObtenerInterfacesActivas(NetworkInterface[] Interfaces)
        {
            List<Adaptador> _listaDeAdaptadores = new List<Adaptador>();

            foreach (NetworkInterface Interfaz in Interfaces
                .Where(InterfazDeRed => InterfazDeRed.OperationalStatus == OperationalStatus.Up
                && InterfazDeRed.NetworkInterfaceType != NetworkInterfaceType.Loopback))
            {
                _listaDeAdaptadores.Add(new Adaptador(Interfaz));
            }

            return _listaDeAdaptadores;
        }
        public static List<Adaptador> ObtenerIntefaces(NetworkInterface[] Interfaces)
        {
            List<Adaptador> _listaDeAdaptadores = new List<Adaptador>();

            foreach (NetworkInterface Interfaz in Interfaces)
            {
                _listaDeAdaptadores.Add(new Adaptador(Interfaz));
            }

            return _listaDeAdaptadores;
        }
    }
}
