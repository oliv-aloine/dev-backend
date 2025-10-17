using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend.Models;

[Table("Usuarios")]
public class Usuario
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Nome obrigatório.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Senha obrigatória.")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
    
    public Perfil Perfil { get; set; }
}

public enum Perfil
{
    Admin,
    User
}