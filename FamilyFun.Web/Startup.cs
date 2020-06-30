using FamilyFun.Persistance;
using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using FamilyFun.Web.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace FamilyFun.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton(typeof(IPersistor<MitzvahOccurence>), s => new BinaryPersistor<MitzvahOccurence>("MitzvahOccurences.bin"));
            services.AddSingleton(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddSingleton<IMitzvahRepository, MitzvahRepository>();
            services.AddScoped<IPageColorDeterminer>(a => new PageColorDeterminer(new ColorRetriever().RetieveColors()));

            services.AddScoped<IMenuItemRetriever>(a =>
                new MenuItemRetriever(new List<MenuItem>
                {
                    new MenuItem(1, "Recipes", "Recipes", "Index", null),
                    new MenuItem(2, "I Did A Mitzvah", "Mitzvos", "Index", null),
                    new MenuItem(2, "Prizes", "Mitzvos", "Prizes", null),
                }));

            services.AddScoped<IFamilyMembersRetriever>(a =>
                new FamilyMembersRetriever(new List<FamilyMember>
                {
                    new FamilyMember(3, "ESTHER",new DateTime(2000,1,1), "Yarmush"),
                    new FamilyMember(4, "TZVI",  new DateTime(2000,1,1), "Yarmush"),
                    new FamilyMember(1, "Mommy", new DateTime(2000,1,1), "Yarmush"),
                    new FamilyMember(2, "Tatty", new DateTime(2000,1,1), "Yarmush")
                }));

            services.AddScoped<IMitzvosRetriever>(a =>
                new MitzvosRetriever(new List<Mitzvah>
                {
                    new Mitzvah(1, "Kiss The Mezuzah", 1),
                    new Mitzvah(2, "Said Modeh Ani", 2),
                }));

            services.AddScoped<IPrizeRetriever>(a =>
                new PrizeRetriever(new List<Prize>
                {
                    new Prize(1, "Small Toy", 1),
                    new Prize(2, "Big Toy", 2),
                    new Prize(3, "Car", 2),
                }));



            services.AddScoped<IFamilyMembersSelectorElementRetriever, FamilyMembersSelectorElementRetriever>();

            services.AddScoped<IMemberPrizeRetriever>(s =>
            {
                return new MemberPrizeRetriever(
                    s.GetService<IPrizeRetriever>(),
                    new Dictionary<int, int[]>()
                    {
                        [3] = new int[] { 1, 2 },
                        [4] = new int[] { 1, 2, 3 },
                    });
            });

            services.AddScoped<IMenuItemSelectorElementRetriever>(s =>
            {
                return new MenuItemSelectorElementRetriever(
                    s.GetService<IMenuItemRetriever>().RetriveMenuItems(),
                    s.GetService<IPageColorDeterminer>(),
                    new Dictionary<int, int[]>()
                    {
                        [1] = new int[] { 1 },
                        [2] = new int[] { 1 },
                        [3] = new int[] { 2 },
                        [4] = new int[] { 2 },
                    });
            });

            services.AddScoped<IMitzvosSelectorElementRetriever>(s =>
            {
                return new MitzvosSelectorElementRetriever(
                    s.GetService<IMitzvosRetriever>().RetrieveMitzvos(),
                    s.GetService<IPageColorDeterminer>(),
                    new Dictionary<int, int[]>()
                    {
                        [1] = new int[] { 1 },
                        [2] = new int[] { 1 },
                        [3] = new int[] { 1,2 },
                        [4] = new int[] { 1,2 },
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
