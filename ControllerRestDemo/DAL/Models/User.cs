using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControllerRestDemo.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Group> Groups { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
            Groups = new HashSet<Group>();

        }

        public User()
        {
            Groups = new HashSet<Group>();
        }
    }
}
