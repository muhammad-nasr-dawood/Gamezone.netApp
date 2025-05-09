namespace ExaminationSystem.MVC.Services
{
  public interface IImageService
  {
	Task<(string fileId, string url)> UploadImageAsync(IFormFile file, string folderName = "/GameZone");

	Task<bool> DeleteImageAsync(string fileId);
  }
}
