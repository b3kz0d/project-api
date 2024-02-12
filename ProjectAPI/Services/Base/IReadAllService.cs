namespace ProjectAPI.Services
{
    public interface IReadAllService<T>
    {
        Task<List<T>> GetAll();
    }
}
