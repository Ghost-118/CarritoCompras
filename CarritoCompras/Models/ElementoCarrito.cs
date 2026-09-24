namespace CarritoCompras.Models
{
    public class ElementoCarrito
    {
        public Producto Producto { get; set; } = new Producto();
        public int Cantidad { get; set; }
        public decimal Subtotal => Producto.Precio * Cantidad;
    }
}