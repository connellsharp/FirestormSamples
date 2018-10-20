namespace FirestormSample.Domain.Messages
{
    public class BoardCreatedEvent
    {
        public int Id { get; set; }
        public string Slug { get; set; }
    }
}