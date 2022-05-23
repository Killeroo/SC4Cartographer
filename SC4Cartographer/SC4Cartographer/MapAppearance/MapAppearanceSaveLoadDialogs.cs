using System;
using System.IO;
using System.Windows.Forms;

namespace SC4CartographerUI
{
    internal class MapAppearanceSaveLoadDialogs
    {
        private const string DEFAULT_FILENAME = "map_appearance.sc4cart";
        private const string FILE_FILTER = "SC4Cartographer properties file (*.sc4cart)|*.sc4cart";
        private readonly IWin32Window owner;
        private readonly MapAppearanceSerializer serializer;
        
        public MapAppearanceSaveLoadDialogs(IWin32Window owner, MapAppearanceSerializer serializer)
        {
            this.owner = owner;
            this.serializer = serializer;
        }

        public void SaveMapParametersWithDialog(MapCreationParameters parameters)
        {
            // Create generic name at current directory
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_FILENAME);
            filePath = Helper.GenerateFilename(filePath);

            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Title = "Save SC4Cartographer map properties";
                fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                fileDialog.FileName = Path.GetFileName(filePath);
                fileDialog.RestoreDirectory = true;
                //fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = FILE_FILTER;
                if (fileDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    TrySaveAndShowResults(parameters, fileDialog.FileName);
                }
            }
        }

        private void TrySaveAndShowResults(MapCreationParameters parameters, string path)
        {
            try
            {
                serializer.SaveToFile(parameters, path);

                var successForm = new SuccessForm(
                    "Map appearance saved",
                    $"Map appearance file '{Path.GetFileName(path)}' has been successfully saved to:",
                    Path.GetDirectoryName(path),
                    path);

                successForm.StartPosition = FormStartPosition.CenterParent;
                successForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorForm form = new ErrorForm(
                    "Could not save map properties",
                    $"An error occured while trying to save map properties file ({path})",
                    ex,
                    false);

                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
        }

        public bool TryLoadMapParametersWithDialog(out MapCreationParameters parameters)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Load SC4Cartographer map properties";
                fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                fileDialog.RestoreDirectory = true;
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = FILE_FILTER;
                
                if (fileDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    if(TryLoadWithErrorDialog(fileDialog.FileName, out parameters))
                    {
                        return true;
                    }
                }                
            }
            
            parameters = null;
            return false;
        }

        /// <summary>
        /// Common function called when loading map parameters/properties/appearance from file
        /// </summary>
        /// <param name="path"></param>
        public bool TryLoadWithErrorDialog(string path, out MapCreationParameters parameters)
        {
            try
            {
                parameters = serializer.LoadFromFile(path);
                return true;
            }
            catch (Exception ex)
            {
                ErrorForm form = new ErrorForm(
                    "Could not load map properties",
                    $"An error occured while trying to load map properties from file ({path})",
                    ex,
                    false);

                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();

                parameters = null;
                return false;
            }
        }
    }
}
