using APIProducto.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIProducto.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
      private  ProductosContext _context;

        public ProductosController(ProductosContext context)
        {
            _context = context; 
            //_productos = new List<Producto>() 
            //{
            //new Producto { Id = 1, Nombre = "Patatas", Precio = 10.00 },
            //new Producto { Id = 2, Nombre = "Tomates", Precio = 12.00 },
            //new Producto { Id = 3, Nombre = "Pepinos", Precio = 10.00 }
            //};
        }
        [HttpGet]
        public ActionResult <List<Producto>> Get()
        {
            var productos=_context.Productos.ToList();
            return productos;
        }


        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
           var producto = _context.Productos.Find(id);
        if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public ActionResult<Producto> Post(Producto producto)
        { 
            //INSERT
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{Id}")]
        public ActionResult<Producto> Put(int id, Producto producto)
        {
            //UPDATE
            var index = _context.Productos.Find(id);
            if(index == null)
            {
                return NotFound(); 
            }

            index.Nombre = producto.Nombre;
            index.Precio=producto.Precio;

            _context.SaveChanges();
            
            return CreatedAtAction(nameof(Get), new { id = index.Id }, index);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //REMOVE
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            _context.SaveChanges();

            return NoContent();
          }



    }
}
