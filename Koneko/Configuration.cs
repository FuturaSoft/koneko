using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Koneko
{
    class Configuration
    {
        public String applicationName = "Koneko";
        public String applicationUrl = "https://futurasoft.fr/";
        public Boolean searchConfigurationFile = true;

        public Configuration()
        {
            if (searchConfigurationFile == true)
            {
                Task<string> configurationFilePath = GetRemoteConfigurationFile();
            }
        }

        private async Task<string> GetRemoteConfigurationFile()
        {
            // Get the logical root folder for all external storage devices.
            StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;

            // Get the first child folder, which represents the SD card.
            StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();

            if (sdCard != null)
            {
                return sdCard.Path;
            }
            else
            {
                return null;
            }
        }
    }
}
