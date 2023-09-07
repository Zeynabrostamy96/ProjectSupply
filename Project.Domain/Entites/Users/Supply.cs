using Project.Domain.Entites.Commons;
using Project.Domain.Entites.Departments;

namespace Project.Domain.Entites.Users
{
    public class Supply : BaseEntity<long>
    {
        public string Title { get; set; }
        public long DeparetmentId { get; set; }
        public long UserId { get; set; }
        public User user { get; set; }
        public Department department { get; set; }
        

    }
}
