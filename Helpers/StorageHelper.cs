using System.Threading.Tasks;
using System.IO;
using Azure.Storage;
using Azure.Storage.Blobs;


namespace Practica_14_02_2024.Helpers
{
    public class StorageHelper
    {
        public const string URL_Image = "https://mayteygustavo.blob.core.windows.net/sergiouwu/detalle1.png ";
        public static async Task<string> SubirArchivo(Stream contenido, string nombre, AzureStorageConfig config)
        {
            string url = $"https://{config.Cuenta}.blob.core.windows.net/{config.Contenedor}/{nombre}";
            Uri uri = new Uri(url);
            var credenciales = new StorageSharedKeyCredential(config.Cuenta, config.Llave);
            var cliente = new BlobClient(uri, credenciales);
            await cliente.UploadAsync(contenido);
            return url;
        }

        public static async Task<bool> EliminarArchivo(string url, AzureStorageConfig config)
        {
            Uri uri = new Uri(url);
            var credenciales = new StorageSharedKeyCredential(config.Cuenta, config.Llave);
            var cliente = new BlobClient(uri, credenciales);
            var respuesta = await cliente.DeleteIfExistsAsync(Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots);
            return respuesta.Value;
        }

        public static string GetURLfromName(string name, AzureStorageConfig config)
        {
            return $"https://{config.Cuenta}.blob.core.windows.net/{config.Contenedor}/{name}";
        }
    }
}
