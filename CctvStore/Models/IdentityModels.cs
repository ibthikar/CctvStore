using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace CctvStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

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

        public System.Data.Entity.DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<SubCategory> SubCategories { get; set; }

        public System.Data.Entity.DbSet<Product> Products { get; set; }

        //public System.Data.Entity.DbSet<ProductProperty> ProductProperties { get; set; }

        public System.Data.Entity.DbSet<Catalog> Catalogs { get; set; }
        public System.Data.Entity.DbSet<FAQ> FAQ { get; set; }
        public DbSet<Upload> Uploads { get; set; }

        public System.Data.Entity.DbSet<ProductDownloads> ProductDownloads { get; set; }
        public System.Data.Entity.DbSet<Specification> Specifications { get; set; }

        public System.Data.Entity.DbSet<SpCamera> SpCameras { get; set; }
        public System.Data.Entity.DbSet<SpImage> SpImages { get; set; }
        public System.Data.Entity.DbSet<SpNetwork> SpNetworks { get; set; }

        public System.Data.Entity.DbSet<Accessories> Accessories { get; set; }

        public System.Data.Entity.DbSet<SpInterface> SpInterfaces { get; set; }

        public System.Data.Entity.DbSet<SpGeneral> SpGenerals { get; set; }

        public System.Data.Entity.DbSet<SpVideo> SpVideos { get; set; }

        public System.Data.Entity.DbSet<SpAudio> SpAudios { get; set; }

        public System.Data.Entity.DbSet<SpHardDisk> SpHardDisks { get; set; }

        public System.Data.Entity.DbSet<SpRecordPlayback> SpRecordPlaybacks { get; set; }

        public System.Data.Entity.DbSet<SpVideoAudioInput> SpVideoAudioInputs { get; set; }

        public System.Data.Entity.DbSet<SpVideoAudioOutput> SpVideoAudioOutputs { get; set; }

        public System.Data.Entity.DbSet<SuccessStory> SuccessStories { get; set; }

        public System.Data.Entity.DbSet<Support> Support { get; set; }

        public System.Data.Entity.DbSet<Download> Downloads { get; set; }

        public System.Data.Entity.DbSet<TroubleShooting> TroubleShootings { get; set; }
    }
}