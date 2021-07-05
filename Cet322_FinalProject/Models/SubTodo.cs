using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cet322_FinalProject.Models
{
    public class SubTodo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        //public Todo DependedTodo { get; set; }
        [ForeignKey(nameof(TodoId))]
        public Todo Todo { get; set; }
        public int TodoId { get; set; }
        public bool isComplete { get; set; }
        public int EffectRateOnTodo { get; set; }


    }
}
