
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<ProductType> _typesRepo;
        private readonly IGenericRepository<ProductBrand> _brandsRepo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> brandsRepo,
        IGenericRepository<ProductType> typesRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productsRepo = productsRepo;
            _brandsRepo = brandsRepo;
            _typesRepo = typesRepo;
        }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
        [FromQuery]ProductSpecParams productParams)
    {
        // return mapped ListAllAsync method and pass the spec as param
        var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
        var countSpec = new ProductWithFiltersForCountSpecification(productParams);
        var totalItems = await _productsRepo.CountAsync(countSpec);
        var products = await _productsRepo.ListAsync(spec);
        var data = _mapper
            .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
        
        return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize,
        totalItems, data));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(id);
        var product = await _productsRepo.GetEntityWithSpec(spec);

        if (product == null)
        {
            return NotFound(new ApiResponse(404));
        }

        return _mapper.Map<Product, ProductToReturnDto>(product);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        // wrap response in 'Ok' when returning IReadOnlyList
        return Ok(await _brandsRepo.ListAllAsync());
    }


    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        // wrap response in 'Ok' when returning IReadOnlyList
        return Ok(await _typesRepo.ListAllAsync());
    }
}
}