using Application.Dtos.ProgramDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.Program;
using Persistance.context;


namespace Persistance.Repositries
{
    public class Program : IProgram
    {
   
        private DataContext _context;
        private IMapper _mapper;
        public Program(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool RegisterProgram(RegisterProgramDto programDto)
        {
            var model = _mapper.Map<Programs>(programDto);
            _context.Programs.Add(model);
            return (this.SaveChanges());

        }
        public List<GetProgramDto> GetPrograms()
        {
            var result = _context.Programs.ToList();
            return(_mapper.Map<List<GetProgramDto>>(result));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }


    }
}
