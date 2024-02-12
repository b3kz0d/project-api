namespace ProjectAPI.Services
{
    public interface IAddService<T>
    {
        Task<T> Add(T dto);

    }
}
