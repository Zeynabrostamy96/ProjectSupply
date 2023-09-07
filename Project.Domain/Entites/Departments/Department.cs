using Project.Domain.Entites.Commons;
using System.Collections.Generic;

namespace Project.Domain.Entites.Departments
{
    public class Department : BaseEntity<long>
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        public User user { get; set; }
     
    }
}
