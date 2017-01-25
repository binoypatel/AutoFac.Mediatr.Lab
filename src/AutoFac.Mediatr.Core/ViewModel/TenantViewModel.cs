using System.ComponentModel.DataAnnotations;

namespace AutoFac.Mediatr.Core.ViewModel
{
    public class TenantViewModel
    {
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public string UnitName { get; set; }
    }
}