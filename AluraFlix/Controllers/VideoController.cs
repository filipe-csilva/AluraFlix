using AutoMapper;
using AluraFlix.Data;
using AluraFlix.Data.Dtos;
using AluraFlix.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private VideoContext _context;
        private IMapper _mapper;

        public VideoController(VideoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] CreateVideoDto videoDto)
        {
            Video video = _mapper.Map<Video>(videoDto);
            _context.Videos.Add(video);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaVideoPorId),
                new { id = video.Id },
                video);
        }

        [HttpGet]
        public IEnumerable<ReadVideoDto> ConsultarVideos()
        {
            return _mapper.Map<List<ReadVideoDto>>(_context.Videos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVideoPorId(int id)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video == null) return NotFound();
            var videoDto = _mapper.Map<ReadVideoDto>(video);
            return Ok(videoDto);
        }

        [HttpPut("id")]
        public IActionResult AtualizaVideo(int id, [FromBody] UpdateVideoDto videoDto)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if(video == null) return NotFound();
            _mapper.Map(videoDto, video);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("id")]
        public IActionResult AtualizaVideoParcial(int id, JsonPatchDocument<UpdateVideoDto> patch)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video == null) return NotFound();

            var videoParaAtualizar = _mapper.Map<UpdateVideoDto>(video);

            patch.ApplyTo(videoParaAtualizar, ModelState);

            if (!TryValidateModel(videoParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(videoParaAtualizar, video);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVideo(int id)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video == null) return NotFound();
            _context.Remove(video);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
