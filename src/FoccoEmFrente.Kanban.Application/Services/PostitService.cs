using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Services
{
    public class PostitService : IPostitService
    {
        private readonly IPostitRepository _postitRepository;

        public PostitService(IPostitRepository postitRepository)
        {
            _postitRepository = postitRepository;
        }

        public async Task<IEnumerable<Postit>> GetAllAsync(Guid userId)
        {
            return await _postitRepository.GetAllAsync(userId);
        }

        public async Task<Postit> GetByIdAsync(Guid id, Guid userId)
        {
            return await _postitRepository.GetByIdAsync(id, userId);
        }

        public async Task<bool> ExistAsync(Guid id, Guid userId)
        {
            return await _postitRepository.ExistAsync(id, userId);
        }

        public async Task<Postit> AddAsync(Postit postit)
        {
            var newPostit = _postitRepository.Add(postit);

            await _postitRepository.UnitOfWork.CommitAsync();

            return newPostit;
        }

        public async Task<Postit> UpdateAsync(Postit postit)
        {
            var postitExists = await ExistAsync(postit.Id, postit.UserId);

            if (!postitExists)
                throw new Exception("Post-it não pode ser encontrado.");

            var updatePostit = _postitRepository.Update(postit);

            await _postitRepository.UnitOfWork.CommitAsync();

            return updatePostit;
        }

        public async Task<Postit> RemoveAsync(Postit postit)
        {
            var postitExists = await ExistAsync(postit.Id, postit.UserId);

            if (!postitExists)
                throw new Exception("Post-it não pode ser encontrado.");

            var oldPostit = _postitRepository.Delete(postit);

            await _postitRepository.UnitOfWork.CommitAsync();

            return oldPostit;
        }

        public async Task<Postit> RemoveAsync(Guid id, Guid userId)
        {
            var postitToBeRemoved = await GetByIdAsync(id, userId);

            if (postitToBeRemoved == null)
                throw new Exception("Atividade não pode ser encontrada.");

            var oldPostit = _postitRepository.Delete(postitToBeRemoved);

            await _postitRepository.UnitOfWork.CommitAsync();

            return oldPostit;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
