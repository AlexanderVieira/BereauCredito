using System.Diagnostics;
using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;

namespace XPTO.Crosscutting.Bereaus
{
    public class SpcFacade : ISpcFacade
    {      
        public Task ConsultarSpc(Consulta consulta)
        {
            //_logger.LogInformation("Realizando consulta no SPC...");
            Debug.WriteLine("SPC: Realizando consulta no SPC...");
            return Task.CompletedTask;
        }
    }
}
