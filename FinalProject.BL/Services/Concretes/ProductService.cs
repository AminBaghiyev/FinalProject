using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.BL.Utilities;
using FinalProject.Core.Entities;
using FinalProject.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.BL.Services.Concretes;

public class ProductService : IProductService
{
    readonly UserManager<AppUser> _userManager;
    readonly IAuditableRepository<Product> _repository;
    readonly IAuditableRepository<Category> _categoryRepository;
    readonly IAuditableRepository<Color> _colorRepository;
    readonly IAuditableRepository<Size> _sizeRepository;
    readonly IWebHostEnvironment _webHostEnvironment;
    readonly IMapper _mapper;

    public ProductService(IAuditableRepository<Product> repository, IMapper mapper, UserManager<AppUser> userManager, IAuditableRepository<Category> categoryRepository, IAuditableRepository<Color> colorRepository, IAuditableRepository<Size> sizeRepository, IWebHostEnvironment webHostEnvironment)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
        _categoryRepository = categoryRepository;
        _colorRepository = colorRepository;
        _sizeRepository = sizeRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<Product> CreateAsync(ProductCreateDto dto, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Product product = _mapper.Map<Product>(dto);
        product.CreatedById = user.Id;

        if (await _categoryRepository.GetByIdAsNoTrackingAsync(product.CategoryId) is null)
            throw new EntityNotFoundException("Category not found!");

        if ((product.ColorId is not null && product.ColorId > 0) && await _colorRepository.GetByIdAsNoTrackingAsync((int)product.ColorId) is null)
            throw new EntityNotFoundException("Color not found!");

        if ((product.SizeId is not null && product.SizeId > 0) && await _sizeRepository.GetByIdAsNoTrackingAsync((int)product.SizeId) is null)
            throw new EntityNotFoundException("Size not found!");

        product.ThumbnailPath = await dto.Thumbnail.SaveAsync(_webHostEnvironment.WebRootPath, "productsThumbnails");

        await _repository.CreateAsync(product);
        return product;
    }

    public async Task<Product> UpdateAsync(ProductUpdateDto dto, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Product oldProduct = await _repository.GetByIdAsync(dto.Id) ?? throw new EntityNotFoundException();
        Product newProduct = _mapper.Map(dto, oldProduct);
        newProduct.UpdatedById = user.Id;

        if (await _categoryRepository.GetByIdAsNoTrackingAsync(newProduct.CategoryId) is null)
            throw new EntityNotFoundException("Category not found!");

        if ((newProduct.ColorId is not null && newProduct.ColorId > 0) && await _colorRepository.GetByIdAsNoTrackingAsync((int)newProduct.ColorId) is null)
            throw new EntityNotFoundException("Color not found!");

        if ((newProduct.SizeId is not null && newProduct.SizeId > 0) && await _sizeRepository.GetByIdAsNoTrackingAsync((int)newProduct.SizeId) is null)
            throw new EntityNotFoundException("Size not found!");

        File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "productsThumbnails", oldProduct.ThumbnailPath));
        newProduct.ThumbnailPath = await dto.Thumbnail.SaveAsync(_webHostEnvironment.WebRootPath, "productsThumbnails");

        _repository.Update(newProduct);
        return newProduct;
    }

    public async Task RecoverAsync(int id)
    {
        Product product = await GetByIdAsync(id);

        _repository.Recover(product);
    }

    public async Task SoftDeleteAsync(int id, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Product product = await GetByIdAsync(id);
        product.DeletedById = user.Id;

        _repository.SoftDelete(product);
    }

    public async Task HardDeleteAsync(int id)
    {
        Product product = await GetByIdAsync(id);
        File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "productsThumbnails", product.ThumbnailPath));

        _repository.HardDelete(product);
    }

    public async Task<ICollection<ProductListItemDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<ProductListItemDto>>(await _repository.GetAllAsync());
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        Product product = await _repository.GetByIdAsync(id) ?? throw new EntityNotFoundException();

        product.Category = await _categoryRepository.GetByIdAsNoTrackingAsync(product.CategoryId);
        product.Color = product.ColorId is null ? null :
            await _colorRepository.GetByIdAsNoTrackingAsync((int)product.ColorId);
        product.Size = product.SizeId is null ? null :
            await _sizeRepository.GetByIdAsNoTrackingAsync((int)product.SizeId);

        return product;
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
