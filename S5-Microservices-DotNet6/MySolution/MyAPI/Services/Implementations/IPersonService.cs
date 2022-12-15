using MyAPI.Model;

namespace MyAPI.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        Person GetById(Guid id);
        List<Person> FindAll();
        void Delete(Guid id);
    }
}
