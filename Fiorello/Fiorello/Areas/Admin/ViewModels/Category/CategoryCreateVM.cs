using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Fiorello.Areas.Admin.ViewModels.Category
{
    public class CategoryCreateVM
    {
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(20)]
        public string ? Name { get; set; }
    }
}
