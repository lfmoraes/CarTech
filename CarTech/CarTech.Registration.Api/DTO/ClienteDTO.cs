﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CarTech.Registration.Api.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }

        public int NumeroCompras { get; set; }
        public decimal TotalConsumido { get; set; }
        public DateTime? DataUltimaCompra { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool InscritoNewsletter { get; set; }
    }
}
