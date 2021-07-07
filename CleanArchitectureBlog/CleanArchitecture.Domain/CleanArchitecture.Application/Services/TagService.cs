using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModel;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository = null;
        private IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(TagViewModel entity)
        {
            var result = await _tagRepository.Add(_mapper.Map<Tag>(entity));
            if (result > 0) return true;
            else return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TagViewModel> GetAll()
        {
            return _mapper.Map<List<TagViewModel>>(_tagRepository.GetAll());
        }

        public TagViewModel GetById(int id)
        {
            return _mapper.Map<TagViewModel>(_tagRepository.GetById(id));
        }

        public bool Update(TagViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
