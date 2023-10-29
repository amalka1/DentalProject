using System.ComponentModel.DataAnnotations;

namespace DentalDatabase.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
