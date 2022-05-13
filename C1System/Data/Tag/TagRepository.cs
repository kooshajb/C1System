
﻿using AutoMapper;

using C1System.Dtos.Tag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System;

    public interface ITagRepository
    {
        Task<GenericResponse<GetTagDto>> Add(AddUpdateTagDto dto);
        Task<GenericResponse<IEnumerable<GetTagDto>>> Get();
        Task<GenericResponse<GetTagDto>> GetById(Guid id);
        Task<GenericResponse<GetTagDto>> Update(Guid id, AddUpdateTagDto dto);
        Task<GenericResponse> Delete(Guid id);
        bool ExistTag(string Title, Guid TagId);
    }

    public class TagRepository : ITagRepository
    {
        private readonly C1SystemContext _context;
        private readonly IMapper _mapper;
        public TagRepository(C1SystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenericResponse<GetTagDto>> Add(AddUpdateTagDto dto)
        {
            if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
            Tag entity = _mapper.Map<Tag>(dto);

            EntityEntry<Tag> i = await _context.Set<Tag>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return new GenericResponse<GetTagDto>(_mapper.Map<GetTagDto>(i.Entity));
        }

        public async Task<GenericResponse> Delete(Guid id)
        {
            GenericResponse<GetTagDto> i = await GetById(id);
            _context.Set<Tag>().Remove(_mapper.Map<Tag>(i.Result));
            await _context.SaveChangesAsync();
            return new GenericResponse(UtilitiesStatusCodes.Success,
                $"Podcast {i.Result.Title} delete Success {i.Result.TagId}");
        }

        public bool ExistTag(string Title, Guid TagId)
        {
            return _context.Tags.Any(p =>
               p.Title == Title && p.TagId != TagId);
        }

        public async Task<GenericResponse<IEnumerable<GetTagDto>>> Get()
        {
            IEnumerable<Tag> i = await _context.Set<Tag>().AsNoTracking().ToListAsync();
            return new GenericResponse<IEnumerable<GetTagDto>>(_mapper.Map<IEnumerable<GetTagDto>>(i));
        }

        public async Task<GenericResponse<GetTagDto>> GetById(Guid id)
        {
            Tag? i = await _context.Set<Tag>().AsNoTracking()
                .FirstOrDefaultAsync(i => i.TagId == id);
            return new GenericResponse<GetTagDto>(_mapper.Map<GetTagDto>(i));
        }

        public async Task<GenericResponse<GetTagDto>> Update(Guid id, AddUpdateTagDto dto)
        {
            var i = _context.Set<Tag>()
                  .Where(p => p.TagId == id).First();

           i.Title = dto.Title;
           i.Link = dto.Link;

            _context.Set<Tag>().Update(i);
            await _context.SaveChangesAsync();
            return new GenericResponse<GetTagDto>(_mapper.Map<GetTagDto>(i));
        }
    

}

