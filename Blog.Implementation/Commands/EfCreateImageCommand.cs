using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfCreateImageCommand : ICreateImageCommand
    {
        private readonly BlogContext _context;

        public EfCreateImageCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Upload Image";

        public void Execute(ImageDto request)
        {
           

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }

            var image = new Images
            {
                Image = newFileName,
            };

            foreach (var item in request.ArticlesImages)
            {
                image.ArticlesImages.Add(new ArticlesImages
                {
                    ImageId = image.Id,
                    ArticleId = item.ArticleId
                });
            }
            _context.Images.Add(image);
            _context.SaveChanges();
        }
    }
}
