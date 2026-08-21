using System.Text.RegularExpressions;

namespace Mercado.Common.Exceptions;

internal static class Guard {

    public static void GuiIDNulo(Guid id, String nomeParametro) {
        if (id == Guid.Empty) {
            throw new DomainExceptions($"O parâmetro {nomeParametro} não pode ter ID vazio.");
        }
    }

    public static void StringVazioNulo(String? valor, String nomeParametro) {
        if (valor == null || valor.IsWhiteSpace()) {
            throw new DomainExceptions($"O/A {nomeParametro} não pode ser vazio ou nulo.");
        }
    }

    public static void ValorInvalido(int valor, String nomeParametro) {
        if (valor < 0) {
            throw new DomainExceptions($"O/A {nomeParametro} não pode ser negativo/a");
        }
    }

    public static void ValorInvalido(float valor, String nomeParametro) {
        if (valor < 0) {
            throw new DomainExceptions($"O/A {nomeParametro} não pode ser negativo/a");
        }

        if (valor == 0) {
            throw new DomainExceptions($"O/A {nomeParametro} não pode ser igual à zero");
        }
    }

    public static void ValorNulo<ObjetoGenerico>(ObjetoGenerico obj, string mensagem) {
        if (obj == null) {
            throw new DomainExceptions(mensagem);
        }
    }

    public static void Valida<ExcecaoGenerica>(bool teste, string mensagem) where ExcecaoGenerica : Exception {
        if (teste) {
            throw (ExcecaoGenerica)Activator.CreateInstance(typeof(ExcecaoGenerica), mensagem)!;
        }
    }

    public static void ValidaSenhaInvalida(string senha) {
        if (Regex.IsMatch(senha, "^[\\{\\}\\[\\]\\=\\+\\-\\;\\#\\'\\\"]$")) {
            throw new DomainExceptions("Senha possui caracteres inválidos.");
        }

        if (senha.Length <= 5) {
            throw new DomainExceptions("A senha precisa possuir pelo menos 6 caracteres.");
        }
    }
}
