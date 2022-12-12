using XPTO.Core.DomainObjects.Exceptions;
using XPTO.Core.Utils;

namespace XPTO.Core.DomainObjects.ValueObjects
{
    public class Cnpj
    {
        public const int CNPJ_MAX_LENGTH = 14;
        public string Numero { get; set; }

        protected Cnpj()
        {
        }

        public Cnpj(string numero)
        {
            if (!Validar(numero)) throw new DomainException("CNPJ inválido.");
            Numero = numero;
        }

        public static bool Validar(string numero)
        {
            var cnpjNumeros = StringUtils.ApenasNumeros(numero);
            if (!AhTamnhoValido(cnpjNumeros)) return false;
            return !AhDigitosRepetidos(cnpjNumeros) && AhDigitosValidos(cnpjNumeros);
        }

        private static bool AhDigitosValidos(string valor)
        {
            var numero = valor.Substring(0, CNPJ_MAX_LENGTH - 2);

            var digitoVerificador = new DigitoVerificador(numero)
                .Multiplicador(2, 9)
                .Substituir("0", 10, 11);
            var primeiroDigito = digitoVerificador.CalcularDigito();
            digitoVerificador.AdicionarDigito(primeiroDigito);
            var segundoDigito = digitoVerificador.CalcularDigito();

            return string.Concat(primeiroDigito, segundoDigito) == valor.Substring(CNPJ_MAX_LENGTH - 2, 2);
        }

        private static bool AhDigitosRepetidos(string valor)
        {
            string[] numerosInvalidos =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return numerosInvalidos.Contains(valor);
        }

        private static bool AhTamnhoValido(string valor)
        {
            return valor.Length == CNPJ_MAX_LENGTH;
        }
    }

    public class DigitoVerificador
    {
        private string _numero;
        private const int Modulo = 11;
        private readonly List<int> _multiplicadores = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _substituicoes = new Dictionary<int, string>();
        private bool _complementarDoModulo = true;

        public DigitoVerificador(string numero)
        {
            _numero = numero;
        }

        public DigitoVerificador Multiplicador(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            _multiplicadores.Clear();
            for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
                _multiplicadores.Add(i);

            return this;
        }

        public DigitoVerificador Substituir(string substituto, params int[] digitos)
        {
            foreach (var i in digitos)
            {
                _substituicoes[i] = substituto;
            }
            return this;
        }

        public void AdicionarDigito(string digito)
        {
            _numero = string.Concat(_numero, digito);
        }

        public string CalcularDigito()
        {
            return !(_numero.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var soma = 0;
            for (int i = _numero.Length - 1, m = 0; i >= 0; i--)
            {
                var produto = (int)char.GetNumericValue(_numero[i]) * _multiplicadores[m];
                soma += produto;

                if (++m >= _multiplicadores.Count) m = 0;
            }

            var mod = (soma % Modulo);
            var resultado = _complementarDoModulo ? Modulo - mod : mod;

            return _substituicoes.ContainsKey(resultado) ? _substituicoes[resultado] : resultado.ToString();
        }
    }   
    
}
