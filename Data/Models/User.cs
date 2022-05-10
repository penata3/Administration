namespace Administration.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Administration.Data.Models.Base;


    [Index(nameof(Username), IsUnique = true)]
    public class User : IDeletableEntity
    {

        public User()
        {
            Id = Guid.NewGuid().ToString();
            Roles = new HashSet<UserRole>();
        }

        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Username is required"), MinLength(5), MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
