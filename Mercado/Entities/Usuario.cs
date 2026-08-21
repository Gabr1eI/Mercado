using Mercado.Common.Base;
using Mercado.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Mercado.Entities;

internal class Usuario : Entity {

    public string User { get; protected set; }
    public string Senha { get; protected set; }

    public Usuario() : base() { }

    public Usuario(string usuario, string senha) {
        Guard.GuiIDNulo(this.id, nameof(this.id));
        Guard.StringVazioNulo(usuario, nameof(usuario));
        Guard.StringVazioNulo(senha, nameof(senha));

        // Testa se o usuário já esta cadastrado

        senha = senha.Trim();
        Guard.ValidaSenhaInvalida(senha);

        PasswordHasher<Usuario> hasher = new PasswordHasher<Usuario>();

        this.User = usuario;
        this.Senha = hasher.HashPassword(this, senha);
    }

    public void AlterarSenha(string usuario, string senha) {
        Guard.StringVazioNulo(usuario, nameof(usuario));
        Guard.StringVazioNulo(senha, nameof(senha));

        if(this.User != usuario) {
            // Não pode alterar a senha de outro usuario
            return;
        }

        senha = senha.Trim();
        Guard.ValidaSenhaInvalida(senha);

        PasswordHasher<Usuario> hasher = new PasswordHasher<Usuario>();

        this.Senha = hasher.HashPassword(this, senha);
    }

    public bool RealizaLogin(string usuario, string senha) {
        Guard.StringVazioNulo(usuario, nameof(usuario));
        Guard.StringVazioNulo(senha, nameof(senha));

        if (this.User != usuario) {
            return false;
        }

        senha = senha.Trim();
        Guard.ValidaSenhaInvalida(senha);

        PasswordHasher<Usuario> hasher = new PasswordHasher<Usuario>();
        string hash = hasher.HashPassword(this, this.Senha);

        if (hasher.VerifyHashedPassword(this, hash, senha) != PasswordVerificationResult.Failed){
            return true;
        } else {
            return false;
        }
    }
}
