namespace ProjectManager.Model.Entities
{
    public class PTaskUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TaskId { get; set; }
        public PTask Task { get; set; }
    }
}
