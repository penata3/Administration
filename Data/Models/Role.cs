namespace Administration.Data.Models
{   
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Administration.Data.Models.Base;

    public class Role : DeletableEntity
    {
        public Role()
        {
            Users = new HashSet<UserRole>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }
    }
}
