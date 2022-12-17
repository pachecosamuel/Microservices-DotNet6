namespace MyAPI.Model
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Adress { get; private set; }
        public string Gender { get; private set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Person(string firstName, string lastName, string adress, string gender)
        {
            Id= Guid.NewGuid();
            FirstName=firstName;
            LastName=lastName;
            Adress=adress;
            Gender=gender;
        }
    }
}
