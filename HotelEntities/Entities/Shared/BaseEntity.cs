using System.ComponentModel.DataAnnotations;

namespace HotelEntities.Entities.Shared;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}