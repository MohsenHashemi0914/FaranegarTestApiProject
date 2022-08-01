using Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Application.Contracts.Province
{
    public class AddProvince
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Position { get; set; }

        [Range(1, ushort.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public ushort Scope { get; set; }
    }
}
