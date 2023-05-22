﻿namespace Impacta.Produtos.WebAPI.Entidades
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public Produto()
        {

        }

        public Produto(Guid id, string nome, string descricao, decimal valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
        }
    }
}
