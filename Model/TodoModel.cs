using System.ComponentModel.DataAnnotations ;
using System.ComponentModel.DataAnnotations.Schema ;
using System.Text.Json.Serialization ;

namespace TodoApi.Models
{
    public class TodoModel
    {
          public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        

    }
}