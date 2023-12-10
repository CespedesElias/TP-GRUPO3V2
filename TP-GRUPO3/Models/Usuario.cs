using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Drawing;

namespace TP_GRUPO3.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Nombre")]
        public String nombre { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Apellido")]
        public String apellido { get; set; }

       
        [Required, DataType(DataType.EmailAddress), Display(Name = "Email")]
        public String email { get; set; }

        [Required, MaxLength(8), MinLength(8), Display(Name = "DNI")]
        public String dni { get; set; }


        [Required, MaxLength(11), MinLength(8), Display(Name = "Teléfono")]
        public String telefono { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Dirección")]
        public String direccion { get; set; }

        public String nombreApellido { get { return nombre + " " + apellido; } }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Elija un usuario para el inicio de sesion")]
        public string Username { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }

    }
}
