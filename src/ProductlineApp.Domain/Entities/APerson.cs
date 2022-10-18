namespace ProductlineApp.Domain.Entities
{
    public abstract class APerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
