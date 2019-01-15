namespace TodoBackend.Stems.Models
{
    public class Todo
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public int Order { get; set; }
        
        public bool Completed { get; set; }
    }
}