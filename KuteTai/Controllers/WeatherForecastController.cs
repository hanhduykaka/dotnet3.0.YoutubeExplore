using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuteTai.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace KuteTai.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
  
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpPost("api/v2/youtube")]
        public async Task<ActionResult<MuxedStreamInfo>> YoutubeVersion2Async([FromForm]VideoInfoModel std)
        {
            // Getting Name
            string videoId = std.VideoId;

            // Getting UUID
            string uuid = std.UUID;

            // Getting Image
            var image = std.Image;
            // Saving Image on Server


            string currentDate = new DateTime().ToShortDateString();

            if (image.Length > 0)
            {

                var result = new StringBuilder();
                using (var reader = new StreamReader(image.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                        result.AppendLine(await reader.ReadLineAsync());
                }
                var youtubeRs = result.ToString();
                YoutubeClient client = new YoutubeClient(new System.Net.Http.HttpClient(), youtubeRs);
                var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videoId);
                var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();

                return streamInfo;
            }
            return null;
        }


        [HttpPost("api/v3/youtube")]
        public async Task<ActionResult<MuxedStreamInfo>> YoutubeVersion3Async([FromBody]VideoInfoModel std)
        {
            // Getting Name
            string videoId = std.VideoId;

            // Getting UUID
            string uuid = std.UUID;

            // Getting Image
            var contentFile = std.ContentFile;
            // Saving Image on Server


            string currentDate = new DateTime().ToShortDateString();

            if (!string.IsNullOrWhiteSpace(contentFile))
            {

                YoutubeClient client = new YoutubeClient(new System.Net.Http.HttpClient(), contentFile);
                var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videoId);
                var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();

                return streamInfo;
            }
            return null;
        }


    }



}
