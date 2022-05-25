namespace Data.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public User()
        {
            Name = "";
            Number = "";
        }

        public User(string name, string number)
        {
            Name = name;
            Number = number;
        }
    }
}