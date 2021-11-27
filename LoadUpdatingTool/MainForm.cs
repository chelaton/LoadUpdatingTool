using LoadUpdatingTool.Core;
using Microsoft.Extensions.Logging;

namespace LoadUpdatingTool
{
    public partial class MainForm : Form
    {
        private readonly ILogger _logger;

        private readonly ILoadService _loadService;
        public MainForm(ILogger<MainForm> logger, ILoadService loadService)
        {
            _logger = logger;
            _loadService = loadService;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Form1 {BusinessLayerEvent} at {dateTime}", "Started", DateTime.UtcNow);

                // Perform Business Logic here 
                _loadService.PerformBusiness();

                MessageBox.Show("Hello .NET Core 6.0 . This is First Forms app in .NET Core");

                _logger.LogInformation("Form1 {BusinessLayerEvent} at {dateTime}", "Ended", DateTime.UtcNow);

            }
            catch (Exception ex)
            {
                //Log technical exception 
                _logger.LogError(ex.Message);
                //Return exception repsponse here
                throw;

            }

        }

        private void GB_LoadData_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}