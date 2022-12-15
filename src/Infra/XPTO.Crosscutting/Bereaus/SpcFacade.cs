using Microsoft.Extensions.Logging;
using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;

namespace XPTO.Crosscutting.Bereaus
{
    public class SpcFacade : ISpcFacade
    {
        //private readonly ILogger<SpcFacade> _logger;

        //public SpcFacade(ILogger<SpcFacade> logger)
        //{
        //    _logger = logger;
        //}

        public Task ConsultarSpc(Consulta consulta)
        {
            //_logger.LogInformation("Realizando consulta no SPC...");
            return Task.CompletedTask;
        }
    }
}
