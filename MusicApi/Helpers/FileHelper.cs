using System.Reflection.Metadata;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Azure.Storage.Blobs;
using MusicApi.Models;

namespace MusicApi.Helpers
{
	public class FileHelper
	{
		public async Task<string> UploadImage(IFormFile file)
		{
			string connectionString = "";
			string containerName = "";

			BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
			BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
			var memoryStream = new MemoryStream();
			await file.CopyToAsync(memoryStream);
			memoryStream.Position = 0;
			await blobClient.UploadAsync(memoryStream);
			return blobClient.Uri.AbsoluteUri;
		}
	}
}
