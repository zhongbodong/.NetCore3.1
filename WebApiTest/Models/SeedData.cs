using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Datas;

namespace WebApiTest.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoContext>>()))
            {
                // Look for any movies.
                if (context.TodoItems.Any())
                {
                    return;   // DB has been seeded
                }

                context.TodoItems.AddRange(
                    new TodoItem
                    {
                       Name="数据结构",
                       IsComplete=false
                       
                    },
                     new TodoItem
                     {
                         Name = "计算机网络",
                         IsComplete = false

                     }


                );
                context.SaveChanges();
            }
        }
    }
}
