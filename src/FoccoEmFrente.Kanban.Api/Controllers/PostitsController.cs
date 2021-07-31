using FoccoEmFrente.Kanban.Api.Controllers.Attributes;
using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    [Authorize]

    public class PostitsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPostitService _postitService;

        public PostitsController(IPostitService postitService, UserManager<IdentityUser> userManager)
        {
            _postitService = postitService;
            _userManager = userManager;
        }

        protected Guid UserId => Guid.Parse(_userManager.GetUserId(User));

        [HttpGet]
        public async Task<IActionResult> ListarAsync()
        {
            var postits = await _postitService.GetAllAsync(UserId);

            return Ok(postits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarAsync(Guid id)
        {
            var postits = await _postitService.GetByIdAsync(id, UserId);
            if (postits == null)
                return NotFound();

            return Ok(postits);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(Postit postit)
        {
            postit.UserId = UserId;

            var newPostit = await _postitService.AddAsync(postit);

            return Ok(newPostit);
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(Postit postit)
        {
            postit.UserId = UserId;

            var dbPostit = await _postitService.UpdateAsync(postit);

            return Ok(dbPostit);
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(Postit postit)
        {
            postit.UserId = UserId;

            var oldActivity = await _postitService.RemoveAsync(postit);

            return Ok(oldActivity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirById(Guid id)
        {
            var oldPostit = await _postitService.RemoveAsync(id, UserId);

            return Ok(oldPostit);
        }
    }
}
