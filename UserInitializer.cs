using InficareTask.Models;

namespace InficareTask
{
    public class UserInitializer
    {
        private List<User> users = new List<User>();
        public void CreateUser(string username,string password)
        {
            User user = new User{Username = username,Password=password};
            users.Add(user);
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}