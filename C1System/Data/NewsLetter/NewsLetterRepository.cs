using AutoMapper;
using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.NewsLetter;
using C1System.DataLayar.Entities.Responses;
using C1System.DataLayar.Entities.Utilities.Enums;
using C1System.Dtos.NewsLetter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.newsLetter
{
    public interface INewsLetterRepository
    {
        Task<GenericResponse<GetNewsLetterDto>> Add(AddUpdateNewsLetterDto dto);
        Task<GenericResponse<IEnumerable<GetNewsLetterDto>>> Get();
        Task<GenericResponse<GetNewsLetterDto>> GetById(Guid id);
        Task<GenericResponse<GetNewsLetterDto>> Update(Guid id, AddUpdateNewsLetterDto dto);
        Task<GenericResponse> Delete(Guid id);
        bool ExistNewsLetter(string FullName, Guid NewsLetterId);
    }
    public class NewsLetterRepository : INewsLetterRepository
    {
        private readonly C1SystemContext _context;
        private readonly IMapper _mapper;
        public NewsLetterRepository(C1SystemContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenericResponse<GetNewsLetterDto>> Add(AddUpdateNewsLetterDto dto)
        {
            if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
            NewsLetter entity = _mapper.Map<NewsLetter>(dto);

            EntityEntry<NewsLetter> i = await _context.Set<NewsLetter>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return new GenericResponse<GetNewsLetterDto>(_mapper.Map<GetNewsLetterDto>(i.Entity));
        }

        public async Task<GenericResponse> Delete(Guid id)
        {
            GenericResponse<GetNewsLetterDto> i = await GetById(id);
            _context.Set<NewsLetter>().Remove(_mapper.Map<NewsLetter>(i.Result));
            await _context.SaveChangesAsync();
            return new GenericResponse(UtilitiesStatusCodes.Success,
                $"Podcast {i.Result.FullName} delete Success {i.Result.NewsLetterId}");
        }

        public bool ExistNewsLetter(string FullName, Guid NewsLetterId)
        {
            return _context.NewsLetters.Any(p =>
                p.FullName == FullName && p.NewsLetterId != NewsLetterId);
        }

        public async Task<GenericResponse<IEnumerable<GetNewsLetterDto>>> Get()
        {
            IEnumerable<NewsLetter> i = await _context.Set<NewsLetter>().AsNoTracking().ToListAsync();
            return new GenericResponse<IEnumerable<GetNewsLetterDto>>(_mapper.Map<IEnumerable<GetNewsLetterDto>>(i));
        }

        public async Task<GenericResponse<GetNewsLetterDto>> GetById(Guid id)
        {
            NewsLetter? i = await _context.Set<NewsLetter>().AsNoTracking()
                .FirstOrDefaultAsync(i => i.NewsLetterId == id);
            return new GenericResponse<GetNewsLetterDto>(_mapper.Map<GetNewsLetterDto>(i));
        }

        public async Task<GenericResponse<GetNewsLetterDto>> Update(Guid id, AddUpdateNewsLetterDto dto)
        {
            var i = _context.Set<NewsLetter>()
                 .Where(p => p.NewsLetterId == id).First();

            i.FullName = dto.FullName;
            i.Email = dto.Email;

            _context.Set<NewsLetter>().Update(i);
            await _context.SaveChangesAsync();
            return new GenericResponse<GetNewsLetterDto>(_mapper.Map<GetNewsLetterDto>(i));
        }
    }
}
