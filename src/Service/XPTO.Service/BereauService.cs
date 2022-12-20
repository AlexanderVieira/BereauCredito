using XPTO.Crosscutting.Bereaus;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Service;

namespace XPTO.Domain.Service
{
    public class BereauService : IBereauService
    {        
        public BereauService()
        {   
        }

        public Task Consultar(Consulta consulta)
        {    
            return Task.CompletedTask;
        }
    }    
}
