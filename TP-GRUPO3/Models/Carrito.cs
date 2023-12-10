using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_GRUPO3.Models
{
    public class Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        //public List<Producto> productos { get; set; }


        [Display(Name = "Producto")]
        public int productoid { get; set; }

        [Display(Name = "Producto")]
        public Producto producto { get; set; }


        [Display(Name = "Usuario")]
        public int usuarioid { get; set; }

        [Display(Name = "Usuario")]
     public Usuario usuario { get; set; }

        /* public void quitarProducto(int idProducto) { }
         public void vaciarCarrito() { }
         public void agregarProducto(int idProducto) { }
         public void buscarProducto(int idProducto) { }
     */
    }
}
