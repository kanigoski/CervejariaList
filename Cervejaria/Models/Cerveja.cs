using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cervejaria.Models
{
    public class Cerveja
    {
        public Cerveja()
        {

        }

        public Cerveja (int id, string marca, string estilo, double preco)
        {
            this.Id = id;
            this.Marca = marca;
            this.Estilo = estilo;
            this.Preco = preco;
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(20 , MinimumLength = 3 , ErrorMessage = "Deve ter entre 3 e 20 caracteres")]
        public string Estilo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Preço")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Preco { get; set; }

    }
}