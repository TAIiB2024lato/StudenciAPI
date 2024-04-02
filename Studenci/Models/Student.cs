namespace Studenci.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? GroupFK { get; set; }
        public int AlbumNo { get; set; }
    }
}
