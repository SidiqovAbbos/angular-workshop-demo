using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBackend.Model
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }

        [JsonIgnore]
        public virtual List<Customer> Customers { get; set; } = new();
    }
}
