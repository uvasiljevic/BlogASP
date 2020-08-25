using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class ImageDto
    {
        public IFormFile Image { get; set; }
        public IEnumerable<ArtileImagesDto> ArticlesImages { get; set; } = new List<ArtileImagesDto>();
    }
    public class ArtileImagesDto
    {
        public int ArticleId { get; set; }
        
    }
}
