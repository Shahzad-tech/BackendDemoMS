using Application.Dtos.ProgramDto;


namespace Application.Interfaces
{
    public interface IProgram
    {
        bool RegisterProgram(RegisterProgramDto programDto);
        List<GetProgramDto> GetPrograms();
        bool SaveChanges(); 
    }
}
