using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControllerRestDemo.DAL.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        public Group()
        {
            Users = new HashSet<User>();
        }

    }
}
