using System;
using System.ComponentModel.DataAnnotations;

namespace simpleWebApi.Models
{
    public class TodoItem
    {
        
        public int ID {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]

        public DateTime DueDate {get; set;}
    }
}