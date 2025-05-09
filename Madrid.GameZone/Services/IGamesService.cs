namespace Madrid.GameZone.Services
{
    public interface IGamesService
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameFormViewModel model); // Task instead of void --> async method
        
        Task<Game?> Update(EditGameFormViewModel model);
        Task<bool> Delete(int id);
    }
}
