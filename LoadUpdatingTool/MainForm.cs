using LoadUpdatingTool.Core;
using LoadUpdatingTool.Data.DTO;
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

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBoxFiles.Items.Add(openFileDialog1.FileName);
            }

        }

        private void listBoxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null)
            {
                foreach (string file in files)
                    listBoxFiles.Items.Add(file);
            }
        }

        private void listBoxFiles_DragEnter(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var selectedItems = new ListBox.SelectedObjectCollection(listBoxFiles);
            selectedItems = listBoxFiles.SelectedItems;

            if (listBoxFiles.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBoxFiles.Items.Remove(selectedItems[i]);
            }
            else
                MessageBox.Show("bla");
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            var verifiedCurveDataList = new List<CurveUpdate>();
            foreach (string item in listBoxFiles.Items)  //pokud by jich byly tisice tak urcte provedu v Parallel.ForEach
            {
                var inputStringData = _loadService.ParseInputFile(item);
                var verifiedCurveData = _loadService.VerifyData(inputStringData);

                if (verifiedCurveData.VerificationErrors.Count == 0)
                {
                    verifiedCurveDataList.Add(verifiedCurveData);
                }
                else
                {
                    _logger.LogError($"Cannot process file {item}:");
                    ErrorListBox.Items.Add($"Cannot process file {item}:");
                    listBoxFiles.Items.Remove(item);
                    foreach (var error in verifiedCurveData.VerificationErrors)
                    {
                        ErrorListBox.Items.Add(error);

                        _logger.LogError(error);
                    }
                }
            }
            try
            {
                var updatedServicePointCount = _loadService.ProcessUpdateData(verifiedCurveDataList);
                listBoxFiles.Items.Clear();
                UpdatedCountLabel.Text = $"Updated {updatedServicePointCount} service points";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            var deletedRecords = _loadService.Clear();
            clearCountLabel.Text = $"Deleted {deletedRecords} records";
        }
    }
}