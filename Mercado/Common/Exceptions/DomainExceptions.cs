namespace Mercado.Common.Exceptions;

public class DomainExceptions : Exception{

    public DomainExceptions(string mensagem) : base(mensagem) {}

    public static void Quando(bool teste, string mensagem) {
        if (teste) {
            throw new DomainExceptions(mensagem);
        }
    }
}
