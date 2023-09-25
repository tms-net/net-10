using Lesson_33_Commerce.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Lesson_33_Commerce.Controllers
{
    // CRUD / REST
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CommerceContext _context;

        public ProductsController(CommerceContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        // HTTP RESPONSE -> JSON(Product)
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // _productDict.TryGetValue(id, out var prod) - O(1) Dictionary

            // _categoryDict.TryGetValue(prod.CategoryId, out var category) - O(1) Dictionary

            if (_context.Products == null)
            {
                return NotFound();
            }

            // var product = await _context.Products.FindAsync(id);

            // var tags = await _context.ProductTags.Where(t => t.ProductId == id);

            // Linq to Objects - Delegate in lambda
            var prodList = new List<Product>().First(p => p.Id == id);

            // Linq to SQL - Expression in lambda
            var product = _context.Products.Include(b => b.Tags).First(p => p.Id == id);

            var tags = product.Tags;

            // 1. Lazy Load -> new query to get related data
            // 2. NULL / EMPTY -> do nothig, developer requests data
            // 3. JOIN -> Include()

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Models.Contracts.Product product)
        {
            //if (id != product.Id)
            //{
            //    return BadRequest();
            //}

            // _context.Entry(product).State = EntityState.Modified;

            var prod = await _context.Products.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Size = product.Size;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Models.Contracts.Product product) // Model binding
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'CommerceContext.Product'  is null.");
            }

            var prod = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Size = product.Size
            };

            // ChangeTracker

            _context.Products.Add(prod);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = prod.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
