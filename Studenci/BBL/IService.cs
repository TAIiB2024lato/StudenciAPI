using Studenci.DTOs;

namespace Studenci.BBL
{
    public interface IService
    {
        IEnumerable<StudentResponseDTo> GetStudents(PaginationDTO paginationDTO);
        StudentResponseDTo GetStudent(int id);
        IEnumerable<GroupResponseDTO> GetGroups(PaginationDTO paginationDTO);
        void DeleteStudent(int id);
        void PutStudent(int id, StudentRequestDTO studentRequestDTO);
        void PostStudent(StudentRequestDTO studentRequestDTO);
    }
}
