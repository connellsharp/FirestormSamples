using System;
using System.Collections.Generic;

namespace FirestormSample.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        public Post Post { get; set; }
        
        public string Text { get; set; }
        
        public DateTime PostedDate { get; set; }
        
        public User PostedByUser { get; set; }
        
        public ICollection<Like> Likes { get; set; }
    }
}