using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcBlog.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<MvcBlog.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<MvcBlog.Models.GalleryCar> GalleryCars { get; set; }

        public System.Data.Entity.DbSet<MvcBlog.Models.Video> Videos { get; set; }

        public System.Data.Entity.DbSet<MvcBlog.Models.Comment> Comments { get; set; }
    }
}