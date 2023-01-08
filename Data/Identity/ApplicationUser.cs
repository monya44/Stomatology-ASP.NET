using Microsoft.AspNetCore.Identity;

namespace Dent.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[]? ProfilePicture { get; set; }
        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser
            {
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
            };

            return user;
        }
    }
}
