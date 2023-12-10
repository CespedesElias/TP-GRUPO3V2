using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TP_GRUPO3.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }


        [Required, DataType(DataType.Text), Display(Name = "Nombre")]
        public string nombre { get; set; }




        [Required, DataType(DataType.Text), Display(Name = "Color")]
        public String color { get; set; }

        public String nombreColor { get {return nombre + " " + color;} }
    

        [Required, Range(1, 500000, ErrorMessage = "Ingrese un precio mayor a $0 y menor a $500.000"),  Display(Name = "Precio unitario")]
        public double precio { get; set; }

        
        [Required, Range(1, 10, ErrorMessage = "Ingrese una cantidad correcta (entre 1 y 10)"), Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Display (Name = "Talle")]
        public Talle talle { get; set; }


        [Display (Name = "Valor total")]
        public String valor { get{ return "$" + cantidad * precio; } }
    }
}
