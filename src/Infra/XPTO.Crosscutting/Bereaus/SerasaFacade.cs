using System.Diagnostics;
using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;

namespace XPTO.Crosscutting.Bereaus
{
    public class SerasaFacade : ISerasaFacade
    {
        public Task ConsultarSerasa(Consulta consulta)
        {
            Debug.WriteLine("SERASA: Realizando consulta no SERASA...");
            return Task.CompletedTask;
        }
    }
}
