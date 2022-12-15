using MyAPI.Model;

namespace MyAPI.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(Guid id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new();

            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            throw new NotImplementedException();
        }

        public Person GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
