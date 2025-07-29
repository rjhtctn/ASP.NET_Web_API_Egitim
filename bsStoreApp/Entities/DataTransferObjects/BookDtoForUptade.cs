using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record BookDtoForUptade : BookDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}