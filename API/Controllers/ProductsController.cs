using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class ProductsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        public ProductsController(DataContext context, IPhotoService photoService
        , IMapper mapper)
        {
            _mapper = mapper;
            _photoService = photoService;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var prods = await _context.Products
                .Include(p => p.Photos)
                .ToListAsync();

            var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(prods);

            return Ok(productsToReturn);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var prod = await _context.Products
                        .Include(p => p.Photos)
                        .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ProductDto>(prod);
        }

        [AllowAnonymous]
        [HttpPost]
        public async void AddProduct(ProductDto productDto)
        {
            var product = new AppProduct
            {
                Title = productDto.Title.ToLower(),
                Price = productDto.Price,
                Discount = productDto.Discount,
                Quantity = productDto.Quantity,
                Description = productDto.Description,
                Photos = new List<Photo>() // Initialize the Photos collection
            };

            // Create a new Photo object for each photo in the productDto.Photos list
            for (int i = 0; i < productDto.Photos.Count; i++)
            {
                var photo = new Photo
                {
                    Url = productDto.Photos[i].Url,
                    PublicId = productDto.Photos[i].PublicId
                };
                product.Photos.Add(photo); // Add the new Photo object to the Photos collection
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        [AllowAnonymous]
        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);


            return new PhotoDto
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
        }
        [AllowAnonymous]
        [HttpPut("update-product")]
        public async void UpdateProduct(ProductDto productDto)
        {
            var product = await _context.Products
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.Id == productDto.Id);

            // if(product == null) return NotFound();

            _mapper.Map(productDto, product);

            _context.SaveChangesAsync();

            // return BadRequest("Failed to update user");
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async void DeletePhoto(int id)
        {
            var product = await _context.Products
            .SingleOrDefaultAsync(x => x.Id == id);
            //         if (book == null)    // {    //     return NotFound();    // }
            for(int i=0 ; i<product.Photos.Count ; i++)
            {
                var result = await _photoService.DeletePhotoAsync(product.Photos[i].PublicId);
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            //return NoContent();         }
        }
    }
}