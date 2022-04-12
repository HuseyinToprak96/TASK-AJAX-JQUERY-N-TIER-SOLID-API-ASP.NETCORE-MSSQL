using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
  public  class ProductService:Service<Product>,IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IMapper mapper, IRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ProductCategoryDto>> getProductAsync()
        {
          var products=await  _productRepository.getProductAsync();
            var productsDto = _mapper.Map<List<ProductCategoryDto>>(products);
            return productsDto;
        }

        public ProductDto Remove(int id)
        {
         var product=  _productRepository.Remove(id);
            _unitOfWork.Commit();
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
