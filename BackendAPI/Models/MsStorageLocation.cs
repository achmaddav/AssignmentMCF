using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class MsStorageLocation
    {
        [Key]
        public string LocationId { get; set; }

        public string LocationName { get; set; }
    }
}
