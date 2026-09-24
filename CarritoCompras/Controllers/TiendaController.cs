using Microsoft.AspNetCore.Mvc;
using CarritoCompras.Models;

namespace CarritoCompras.Controllers
{
    public class TiendaController : Controller
    {
        // Catálogo simulado de productos de ropa
        private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Playera Oversize Negra", Precio = 299.00m, ImagenUrl = "https://images.unsplash.com/photo-1521572267360-ee0c2909d518?w=300" },
            new Producto { Id = 2, Nombre = "Pantalón Jean Slim Fit", Precio = 699.00m, ImagenUrl = "https://images.unsplash.com/photo-1541099649105-f69ad21f3246?w=500" },
            new Producto { Id = 3, Nombre = "Sudadera con Capucha", Precio = 549.00m, ImagenUrl = "https://images.unsplash.com/photo-1556905055-8f358a7a47b2?w=300" },
            new Producto { Id = 4, Nombre = "Set Ropa Interior Boxer (3 Pack)", Precio = 349.00m, ImagenUrl = "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?w=300" }
        };

        private static List<ElementoCarrito> carrito = new List<ElementoCarrito>();

        // Ver Catálogo
        public IActionResult Index()
        {
            return View(productos);
        }

        // Agregar al Carrito
        [HttpPost]
        public IActionResult AgregarAlCarrito(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                var item = carrito.FirstOrDefault(c => c.Producto.Id == id);
                if (item != null)
                {
                    item.Cantidad++;
                }
                else
                {
                    carrito.Add(new ElementoCarrito { Producto = producto, Cantidad = 1 });
                }
            }
            return RedirectToAction("Carrito");
        }

        // Incrementar Cantidad
        [HttpPost]
        public IActionResult AumentarCantidad(int id)
        {
            var item = carrito.FirstOrDefault(c => c.Producto.Id == id);
            if (item != null) item.Cantidad++;
            return RedirectToAction("Carrito");
        }

        // Disminuir Cantidad
        [HttpPost]
        public IActionResult DisminuirCantidad(int id)
        {
            var item = carrito.FirstOrDefault(c => c.Producto.Id == id);
            if (item != null)
            {
                item.Cantidad--;
                if (item.Cantidad <= 0) carrito.Remove(item);
            }
            return RedirectToAction("Carrito");
        }

        // Eliminar Producto
        [HttpPost]
        public IActionResult EliminarDelCarrito(int id)
        {
            var item = carrito.FirstOrDefault(c => c.Producto.Id == id);
            if (item != null) carrito.Remove(item);
            return RedirectToAction("Carrito");
        }

        // Ver Carrito
        public IActionResult Carrito()
        {
            return View(carrito);
        }
    }
}