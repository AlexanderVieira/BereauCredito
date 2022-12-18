using XPTO.Core.DomainObjects.Exceptions;

namespace XPTO.Core.DomainObjects.ValueObjects
{
    public class Senha
    {
        private const string PATTERN = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
        public string Valor { get; private set; }

        public Senha(string valor)
        {
            if (!Validar(valor)) throw new DomainException("Login ou senha inválido.");
            Valor = valor;
        }

        public static bool Validar(string valor)
        {
            return Validacao.ValidarSeDiferente(PATTERN, valor);
        }
       
    }
}
