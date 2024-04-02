using Studenci.DTOs;
using Studenci.Models;

namespace Studenci.BBL
{
    public class Service : IService
    {
        readonly List<Student> students = new()
        {
            new Student { Id = 1, Name = "Jan", Surname = "Kowalski", GroupFK = 1, AlbumNo = 12345 },
            new Student { Id = 2, Name = "Anna", Surname = "Nowak", GroupFK = 2, AlbumNo = 23456 },
            new Student { Id = 3, Name = "Piotr", Surname = "Wiśniewski", GroupFK = 3, AlbumNo = 34567 },
            new Student { Id = 4, Name = "Magdalena", Surname = "Wójcik", GroupFK = 4, AlbumNo = 45678 },
            new Student { Id = 5, Name = "Katarzyna", Surname = "Kamińska", GroupFK = null, AlbumNo = 56789 },
            new Student { Id = 6, Name = "Michał", Surname = "Lewandowski", GroupFK = 1, AlbumNo = 67890 },
            new Student { Id = 7, Name = "Krzysztof", Surname = "Dąbrowski", GroupFK = 2, AlbumNo = 78901 },
            new Student { Id = 8, Name = "Małgorzata", Surname = "Zielińska", GroupFK = 3, AlbumNo = 89012 },
            new Student { Id = 9, Name = "Tomasz", Surname = "Szymański", GroupFK = null, AlbumNo = 90123 },
            new Student { Id = 10, Name = "Agnieszka", Surname = "Woźniak", GroupFK = 1, AlbumNo = 11223 },
            new Student { Id = 11, Name = "Marcin", Surname = "Kozłowski", GroupFK = 2, AlbumNo = 22334 },
            new Student { Id = 12, Name = "Marianna", Surname = "Jankowska", GroupFK = 3, AlbumNo = 33445 },
            new Student { Id = 13, Name = "Rafał", Surname = "Wojciechowski", GroupFK = 4, AlbumNo = 44556 },
            new Student { Id = 14, Name = "Monika", Surname = "Lis", GroupFK = null, AlbumNo = 55667 },
            new Student { Id = 15, Name = "Mateusz", Surname = "Kowalczyk", GroupFK = 1, AlbumNo = 66778 },
            new Student { Id = 16, Name = "Jan", Surname = "Kowalski", GroupFK = 1, AlbumNo = 12345 },
            new Student { Id = 17, Name = "Anna", Surname = "Nowak", GroupFK = 2, AlbumNo = 23456 },
            new Student { Id = 18, Name = "Piotr", Surname = "Wiśniewski", GroupFK = 3, AlbumNo = 34567 },
            new Student { Id = 19, Name = "Magdalena", Surname = "Wójcik", GroupFK = 4, AlbumNo = 45678 },
            new Student { Id = 20, Name = "Katarzyna", Surname = "Kamińska", GroupFK = null, AlbumNo = 56789 }
        };
        readonly List<Group> groups = new()
        {
            new Group { Id = 1, Name = "Grupa pierwsza" },
            new Group { Id = 2, Name = "Grupa druga" },
            new Group { Id = 3, Name = "Grupa trzecia" },
            new Group { Id = 4, Name = "Grupa czwarta" }
        };

        public void DeleteStudent(int id)
        {
            Student student = FindStudent(id);
            students.Remove(student);
        }

        public IEnumerable<GroupResponseDTO> GetGroups(PaginationDTO paginationDTO)
        {
            int count = paginationDTO?.Count ?? 10;
            int page = paginationDTO?.Page ?? 0;
            return groups.Skip(count * page).Take(count).Select(x => new GroupResponseDTO { Id = x.Id, Name = x.Name });
        }

        public StudentResponseDTo GetStudent(int id)
        {
            Student student = FindStudent(id);
            return ToStudentResponseDTo(student);
        }

        public IEnumerable<StudentResponseDTo> GetStudents(PaginationDTO paginationDTO)
        {
            int count = paginationDTO?.Count ?? 10;
            int page = paginationDTO?.Page ?? 0;
            return students.Skip(count * page).Take(count).Select(x => ToStudentResponseDTo(x));
        }

        public void PostStudent(StudentRequestDTO studentRequestDTO)
        {
            Student student = new()
            {
                Surname = studentRequestDTO.Surname,
                AlbumNo = studentRequestDTO.AlbumNo,
                Id = students.Max(x => x.Id) + 1,
                Name = studentRequestDTO.Name,
                GroupFK = studentRequestDTO.GroupId
            };
            students.Add(student);
        }

        public void PutStudent(int id, StudentRequestDTO studentRequestDTO)
        {
            Student student = FindStudent(id);
            student.Surname = studentRequestDTO.Surname;
            student.AlbumNo = studentRequestDTO.AlbumNo;
            student.Name = studentRequestDTO.Name;
            student.GroupFK = studentRequestDTO.GroupId;
        }

        Student FindStudent(int id)
        {
            Student student = students.Find(x => x.Id == id);
            if (student == null)
            {
                throw new Exception($"Nie znaleziono studenta o id = {id}");
            }

            return student;
        }

        StudentResponseDTo ToStudentResponseDTo(Student student)
        {
            return new StudentResponseDTo
            {
                AlbumNo = student.AlbumNo,
                GroupId = student.GroupFK,
                GroupName = student.GroupFK > 0 ? groups.Find(x => x.Id == student.GroupFK).Name : "",
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname
            };
        }
    }
}
