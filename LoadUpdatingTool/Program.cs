using LoadUpdatingTool.Core;
using LoadUpdatingTool.Data;
using LoadUpdatingTool.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LoadUpdatingTool
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            if (ProcessCommandLine(args))
                return;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static bool ProcessCommandLine(string[] args)
        {
            if (args.Any())
            {
                return true;
            }
            return false;
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddDbContext<LoadContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Load;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"));
            services.AddScoped<ILoadService, LoadService>();
            services.AddScoped<ILoadRepository, LoadRepository>();
            services.AddScoped<MainForm>();
        }
    }
}