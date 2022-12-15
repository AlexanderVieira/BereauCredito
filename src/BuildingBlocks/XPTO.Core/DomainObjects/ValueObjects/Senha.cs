namespace XPTO.Core.DomainObjects.ValueObjects
{
    public class Senha
    {
        public string Valor { get; private set; }

        public Senha(string valor)
        {            
            Validacao.ValidarSeNuloVazio(valor, "A senha deve ser informada.");
            Valor = valor;
        }
    }
}
