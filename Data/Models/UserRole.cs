namespace Administration.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
