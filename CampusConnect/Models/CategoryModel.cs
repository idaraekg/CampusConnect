using System.ComponentModel.DataAnnotations;

namespace CampusConnect.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Please select a category.")]
        public string SelectedCategory { get; set; }
    }
}