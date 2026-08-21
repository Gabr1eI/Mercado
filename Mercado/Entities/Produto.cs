using Mercado.Common.Base;
using Mercado.Common.Exceptions;

namespace Mercado.Entities;

public class Produto : Entity{

    public string Descricao { get; protected set; }
    public float PrecoUnitario { get; protected set; }
    public int QuantidadeEmEstoque { get; protected set; }

    public Produto() : base(){}

    public Produto(string descricao, float preco, int quantidade) {
        Guard.GuiIDNulo(this.id, nameof(this.id));
        Guard.StringVazioNulo(descricao, nameof(descricao));
        Guard.ValorInvalido(preco, nameof(preco));
        Guard.ValorInvalido(QuantidadeEmEstoque, nameof(QuantidadeEmEstoque));

        this.Descricao = descricao;
        this.PrecoUnitario = preco;
        this.QuantidadeEmEstoque = quantidade;
    }

    public void AlteraDescricao(string novaDescricao) {
        Guard.StringVazioNulo(novaDescricao, nameof(novaDescricao));

        if (this.Descricao.Equals(novaDescricao.Trim())) {
            return;
        }

        this.Descricao = novaDescricao;
    }

    public void AlteraPreco(float novoPreco) {
        Guard.ValorInvalido(novoPreco, nameof(novoPreco));

        if (this.PrecoUnitario == novoPreco) {
            return;
        }

        this.PrecoUnitario = novoPreco;
    }

    public void diminuiEstoque(int qtd) {
        Guard.ValorInvalido(qtd, nameof(qtd));

        DomainExceptions.Quando((this.QuantidadeEmEstoque - qtd < 0), "Estoque negativo");

        this.QuantidadeEmEstoque -= qtd;
    }
}
