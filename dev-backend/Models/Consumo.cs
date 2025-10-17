using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend.Models;

[Table("Consumos")]
public class Consumo
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Descrição obrigatório .")]
    [Display(Name="Descrição")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "Data obrigatório.")]
    public DateTime Data { get; set; }
    
    [Required(ErrorMessage = "Valor obrigatório.")]
    public decimal Valor { get; set; }
    
    [Required(ErrorMessage = "Quilometragem obrigatório.")]
    public int Km { get; set; }
    
    [Display(Name="Tipo de Combustível")]
    public TipoCombustivel Tipo{ get; set; }
    
    [Display(Name="Veículo")]
    [Required(ErrorMessage = "Veículo obrigatório.")]
    public int VeiculoId { get; set; }

    [ForeignKey("VeiculoId")]
    public Veiculo? Veiculo { get; set; }
}

public enum TipoCombustivel
{
    Gasolina,
    Etanol
}