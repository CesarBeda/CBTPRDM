using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuAppLogistica.Models;

namespace MeuAppLogistica.Services
{
    public class MockTrackingService
    {
        // Simula um banco de dados com alguns pacotes
        private readonly Dictionary<string, Package> _packages;

        public MockTrackingService()
        {
            _packages = new Dictionary<string, Package>
            {
                { "BR123456", new Package
                    {
                        TrackingId = "BR123456",
                        Status = "Em trânsito",
                        ShipDate = new DateTime(2025, 10, 25),
                        EstimatedDelivery = new DateTime(2025, 11, 02),
                        History = new List<TrackingEvent>
                        {
                            new TrackingEvent { Timestamp = new DateTime(2025, 10, 26, 14, 30, 00), Location = "Centro de Distribuição, SP", Description = "Objeto postado." },
                            new TrackingEvent { Timestamp = new DateTime(2025, 10, 27, 09, 15, 00), Location = "Unidade de Tratamento, SP", Description = "Em trânsito para a unidade local." }
                        }
                    }
                },
                { "BR654321", new Package
                    {
                        TrackingId = "BR654321",
                        Status = "Entregue",
                        ShipDate = new DateTime(2025, 10, 20),
                        EstimatedDelivery = new DateTime(2025, 10, 25),
                        History = new List<TrackingEvent>
                        {
                            new TrackingEvent { Timestamp = new DateTime(2025, 10, 20, 10, 00, 00), Location = "Centro de Distribuição, RJ", Description = "Objeto postado." },
                            new TrackingEvent { Timestamp = new DateTime(2025, 10, 22, 11, 00, 00), Location = "Unidade Local, RJ", Description = "Saiu para entrega." },
                            new TrackingEvent { Timestamp = new DateTime(2025, 10, 22, 15, 45, 00), Location = "Casa do Cliente, RJ", Description = "Objeto entregue ao destinatário." }
                        }
                    }
                }
            };
        }

        // Simula uma chamada de API/Banco de Dados (assíncrona)
        public Task<Package> GetPackageDetailsAsync(string trackingId)
        {
            if (string.IsNullOrWhiteSpace(trackingId))
            {
                return Task.FromResult<Package>(null);
            }

            _packages.TryGetValue(trackingId.ToUpper(), out var package);
            return Task.FromResult(package); // Retorna o pacote se encontrado, ou null se não
        }
    }
}
