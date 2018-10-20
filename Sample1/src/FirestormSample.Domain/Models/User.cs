using System.Collections.Generic;

namespace FirestormSample.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}