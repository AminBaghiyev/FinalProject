using FinalProject.BL.Utilities;
using FinalProject.Core.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FinalProject.BL.DTOs;

public record ProductCreateDto
{
    public int Group { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal DiscountedPrice { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public int? ColorId { get; set; }
    public int? SizeId { get; set; }
    public IFormFile Thumbnail { get; set; }
}

public class ProductCreateDtoValidation : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidation()
    {
        RuleFor(e => e.Group)
            .NotNull().GreaterThanOrEqualTo(0).WithMessage("Group must be a positive number!");

        RuleFor(e => e.Title)
            .NotEmpty().NotNull().WithMessage("Title cannot be empty!");

        RuleFor(e => e.DiscountedPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Discounted Price must be 0 or positive number!");

        RuleFor(e => e.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price must be 0 or positive number!");

        RuleFor(e => e.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock must be 0 or positive number!");

        RuleFor(e => e.CategoryId)
            .NotNull().GreaterThan(0).WithMessage("Category ID must be a positive number!");

        RuleFor(e => e.ColorId)
            .GreaterThanOrEqualTo(0).WithMessage("Color ID must be 0 or positive number!").When(e => e.ColorId.HasValue);

        RuleFor(e => e.SizeId)
            .GreaterThanOrEqualTo(0).WithMessage("Size ID must be a positive number!").When(e => e.SizeId.HasValue);

        RuleFor(e => e.Thumbnail)
            .NotNull().WithMessage("Thumbnail is required!")
            .Must(file => file.CheckType("image"))
            .WithMessage("Thumbnail must be an image file!")
            .When(e => e.Thumbnail is not null)
            .Must(file => file.CheckSize(5, FileSizeTypes.Mb))
            .WithMessage("Thumbnail size must not exceed 5 MB!")
            .When(e => e.Thumbnail is not null);
    }
}