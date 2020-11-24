using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class TodoItem 
    {
        public long Id {get; set;}
        [Required]
        public string Name {get; set;}
        [DefaultValue(false)]
        public bool IsComplete {get; set;}
        public string Secret {get; set;}
    }

    public class TodoItemDTO
    {
        public long Id {get; set;}
        public string Name {get; set;}
        public bool IsComplete {get; set;}
    }
}