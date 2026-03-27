using System.ComponentModel.DataAnnotations;

namespace CampusConnect.Models
{
    public class JoinModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
    }
}