using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasteringEFCore.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MasteringEFCore.Web.Data
{
    public class DbInitializer
    {
        public static async void Initialize(BlogContext context)
        {
            context.Database.EnsureCreated();
            // Look for any blogs.
            if (context.Blogs.Any())
            {
                return;   // DB has been seeded
            }
            var dotnetBlog = new Blog
            {
                Url = "http://blogs.packtpub.com/dotnet"
            };
            var dotnetCoreBlog = new Blog
            {
                Url =
               "http://blogs.packtpub.com/dotnetcore"
            };
            var blogs = new Blog[]
            {
        dotnetBlog,
        dotnetCoreBlog
            };
            foreach (var blog in blogs)
            {
                context.Blogs.Add(blog);
            }
                        context.SaveChanges();

            var posts = new Post[]
            {
        new Post{/*Id= 1,*/Title="Dotnet 4.7 Released",Blog = dotnetBlog,
        Content = "Dotnet 4.7 Released Contents", PublishedDateTime =
         DateTime.Now},
        new Post{/*Id= 1,*/Title=".NET Core 1.1 Released",Blog=
        dotnetCoreBlog,
        Content = ".NET Core 1.1 Released Contents", PublishedDateTime =
         DateTime.Now},
        new Post{/*Id= 1,*/Title="EF Core 1.1 Released",Blog=
        dotnetCoreBlog,
        Content = "EF Core 1.1 Released Contents", PublishedDateTime =
         DateTime.Now}
            };
            foreach (var post in posts)
            {
                context.Posts.Add(post);
            }
            context.SaveChanges();
        }
    }
}
