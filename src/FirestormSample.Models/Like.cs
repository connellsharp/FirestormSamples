using System;

namespace FirestormSample.Models
{
    public class Like
    {
        public int Id { get; set; }
        
        public DateTime LikedDate { get; set; }
        
        public User LikedByUser { get; set; }
        
        public Post Post { get; set; }
        
        public Comment Comment { get; set; }
    }
}