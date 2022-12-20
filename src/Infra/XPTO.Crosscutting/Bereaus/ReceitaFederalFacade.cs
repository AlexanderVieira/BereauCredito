using System.Diagnostics;
using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;

namespace XPTO.Crosscutting.Bereaus
{
    public class ReceitaFederalFacade : IReceitaFederalFacade
    {
        public Task ConsultarReceitaFederal(Consulta consulta)
        {
            Debug.WriteLine("RF: Realizando consulta na RECEITA FEDERAL...");
            return Task.CompletedTask;
        }
    }
}
