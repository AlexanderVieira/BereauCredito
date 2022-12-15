namespace XPTO.Core.DomainObjects.ValueObjects
{
    public class Nome
    {
        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }
        public string NomeCompleto { get; private set; }

        public Nome(string primeiroNome, string sobreNome)
        {   
            Validacao.ValidarSeNuloVazio(primeiroNome, "O campo primeiro nome deve ser informado.");
            Validacao.ValidarSeNuloVazio(sobreNome, "O campo sobrenome deve ser informado.");
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;
            NomeCompleto = $"{PrimeiroNome} {SobreNome}";
        }
    }
}
