using Microsoft.Extensions.DependencyInjection;

namespace LoadUpdatingTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<TrainContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBusinessLayer, CBusinessLayer>();
                    //.AddScoped<IBusinessLayer, CBusinessLayer>()
                    //.AddSingleton<IDataAccessLayer, CDataAccessLayer>();
        }
    }
}