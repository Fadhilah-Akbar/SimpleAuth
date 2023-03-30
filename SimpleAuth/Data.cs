namespace SimpleAuth
{
    public class Data
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Data() {
            this.FirstName = null;
            this.LastName = null;
            this.Username = null;
            this.Password = null;
        }
        public Data(string firstName, string lastName, string username , string password) {
            this.FirstName = firstName;
            this.LastName = lastName;   
            this.Username = username;   
            this.Password = password;
        }

        public void WriteData()
        {
            Console.WriteLine("Name     : " + $"{this.FirstName} {this.LastName}");
            Console.WriteLine("Username : " + this.Username);
            Console.WriteLine("Password : " + this.Password);
        }
    }
}
