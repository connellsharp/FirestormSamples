using System;
using System.Collections.Generic;

namespace FirestormSample.Domain.Models
{
    public class Board
    {
        public int Id { get; set; }
        
        public string Slug { get; set; }
        
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}