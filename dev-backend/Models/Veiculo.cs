using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend.Models;

[Table("Veiculos")]
public class Veiculo
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Placa obrigatório.")]
    public string Placa { get; set; }

    [Required(ErrorMessage = "Ano de Fabricação obrigatório.")]
    [Display(Name="Ano de Fabricação")]
    public int AnoFabricacao { get; set; }
    
    [Required(ErrorMessage = "Ano do Modelo obrigatório.")]
    [Display(Name="Ano do Modelo")]
    public int AnoModelo { get; set; }
}