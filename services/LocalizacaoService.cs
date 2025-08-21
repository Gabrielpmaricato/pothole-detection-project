using System;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.ApplicationModel;
using NLog;

namespace TrepidaApp.Services
{
    public class LocalizacaoService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public async Task<(double Latitude, double Longitude)> CapturarLocalizacaoAsync()
        {
            Logger.Info("Iniciando captura de localização.");

            try
            {
                if (!await VerificarPermissaoAsync())
                {
                    Logger.Warn("Permissão de localização não concedida.");
                    throw new Exception("Permissão de localização negada.");
                }

                var localizacao = await Geolocation.GetLastKnownLocationAsync();

                if (localizacao == null)
                {
                    Logger.Info("Última localização não encontrada. Solicitando nova localização.");
                    localizacao = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromSeconds(10)
                    });
                }

                if (localizacao != null)
                {
                    Logger.Info($"Localização capturada: Latitude={localizacao.Latitude}, Longitude={localizacao.Longitude}");
                    return (localizacao.Latitude, localizacao.Longitude);
                }

                Logger.Error("Localização não pôde ser obtida.");
                throw new Exception("Não foi possível obter a localização.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erro ao capturar localização.");
                throw;
            }
        }

        public async Task<bool> VerificarPermissaoAsync()
        {
            Logger.Info("Verificando permissão de localização.");

            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (status != PermissionStatus.Granted)
                {
                    Logger.Warn("Permissão não concedida. Solicitando ao usuário.");
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                var concedida = status == PermissionStatus.Granted;
                Logger.Info($"Permissão de localização {(concedida ? "concedida" : "negada")}.");
                return concedida;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Erro ao verificar permissão de localização.");
                throw;
            }
        }
    }
}
