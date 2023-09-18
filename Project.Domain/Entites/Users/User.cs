using Project.Domain.Entites.Commons;
using Project.Domain.Entites.Departments;
using System.Collections.Generic;

namespace Project.Domain.Entites
{
    public class User : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Department> department { get; set; }

    }
}
