namespace AngularjsUploadingFileWeb.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularjsUploadingFileWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AngularjsUploadingFileWeb.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.UploadFiles.AddOrUpdate(
              p => p.FileName,
              new UploadedFile
              {
                  FileName = "CodeSpoken",
                  Description = "CodeSpoken logo site",
                  FilePath = "D:/Work",
                  FileSize = 60,
                  Estado = 0
              }
            );
            context.SaveChanges();
        }
    }
}
