
using Microsoft.AspNetCore.Http;

namespace KuteTai.Models
{
    public class VideoInfoModel
    {
    
        public string VideoId { get; set; }
        public IFormFile Image { get; set; }
        public string UUID { get; set; }
     
    }
}
