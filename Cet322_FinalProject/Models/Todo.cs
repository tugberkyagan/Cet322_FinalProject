using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cet322_FinalProject.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Doldur burayı kardeş")]
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<SubTodo> SubTodos { get; set; }
        public bool isComplete { get; set; }
        public int isHundread { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
