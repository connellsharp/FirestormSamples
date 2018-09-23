using System;
using System.Collections.Generic;

namespace FirestormSample.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        public string Slug { get; set; }
        
        public Board Board { get; set; }
        
        public string Text { get; set; }
        
        public DateTime PostedDate { get; set; }
        
        public User PostedByUser { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
        
        public ICollection<Like> Likes { get; set; }
    }
}