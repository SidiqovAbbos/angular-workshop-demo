using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBackend.Model
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
