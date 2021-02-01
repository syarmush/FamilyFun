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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSingleton(typeof(IPersistor<MitzvahOccurence>), s => new BinaryPersistor<MitzvahOccurence>("app_data/mitzvah_occurences.bin"));
            services.AddSingleton(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddSingleton<IMitzvahRepository, MitzvahRepository>();
            services.AddScoped<IPageColorDeterminer>(a => new PageColorDeterminer(new ColorRetriever().RetieveColors()));
            services.AddSingleton<IPrizeImageDirectoryPathRetriever>(new StaticPrizeImageDirectoryPathRetriever("/images/"));
            services.AddSingleton<IMitzvahImageDirectoryPathRetriever>(new StaticMitzvahImageDirectoryPathRetriever("/images/"));

            services.AddScoped<IMenuItemRetriever>(a =>
                new MenuItemRetriever(new List<MenuItem>
                {
                    new MenuItem(1, "Recipes", "Recipes", "Index", null),
                    new MenuItem(2, "I Did A Mitzvah", "Mitzvos", "Index", null),
                    new MenuItem(3, "Prizes", "Prize", "Index", null),
                }));

            services.AddScoped<IFamilyMembersRetriever>(a =>
                new FamilyMembersRetriever(new List<FamilyMember>
                {
                    new FamilyMember(3, "ESTHER",new DateTime(2000,1,1), "Doe"),
                    new FamilyMember(4, "TZVI",  new DateTime(2000,1,1), "Doe"),
                    new FamilyMember(1, "Mommy", new DateTime(2000,1,1), "Doe"),
                    new FamilyMember(2, "Tatty", new DateTime(2000,1,1), "Doe")
                }));

            services.AddScoped<IMitzvosRetriever>(a =>
                new MitzvosRetriever(new List<Mitzvah>
                {
                    new Mitzvah(1, "Said Modeh Ani", 10, "say-modeh-ani.jpg"),
                    new Mitzvah(2, "Wash Negel Vasser", 5, "wash-negel-vasser.png"),
                    new Mitzvah(3, "Dress With Zrizus", 7, "get-dressed.jpg"),
                    new Mitzvah(4, "Hang Up Coat and Backpack", 7, "hang-up.jpg"),
                    new Mitzvah(5, "Homework", 10, "homework.jpg"),
                    new Mitzvah(6, "Laundry", 7, "put-laudry-away.jpg"),
                    new Mitzvah(7, "Clean Up", 7, "clean-up.jpg"),
                    new Mitzvah(8, "Bring Negel Vaser to bed", 10, "prepare-negel-vasser.jpg"),
                    new Mitzvah(9, "Kiss The Mezuzah", 5, "mezuzah.jpg"),
                    new Mitzvah(10, "Say Shma Nicely", 10, "say-shema.jpg"),
                    new Mitzvah(11, "12 Pesukim", 10, "12-pesukim.jpg"),
                }));

            services.AddScoped<IPrizeRetriever>(a =>
                new PrizeRetriever(new List<Prize>
                {
                    new Prize(1, "Tablet", 7000, "tablet.jpg"),
                    new Prize(2, "Remote Control Robot", 7000, "remote-control-robot.jpg"),
                }));



            services.AddScoped<IFamilyMembersSelectorElementRetriever, FamilyMembersSelectorElementRetriever>();

            services.AddScoped<IMemberPrizeRetriever>(s =>
            {
                return new MemberPrizeRetriever(
                    s.GetService<IPrizeRetriever>(),
                    new Dictionary<int, int[]>()
                    {
                        [3] = new int[] { 1 },
                        [4] = new int[] { 2 },
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
                        [3] = new int[] { 2, 3 },
                        [4] = new int[] { 2, 3 },
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
                    },
                    s.GetService<IMitzvahImageDirectoryPathRetriever>());
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
