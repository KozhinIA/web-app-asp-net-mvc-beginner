using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAppAspNetMvcBeginner.Models
{
    public class Book
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        [Display(Name = "Название", Order = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Автор
        /// </summary>  
        [Required]
        [Display(Name = "Автор", Order = 10)]
        public string Author { get; set; }

        /// <summary>
        /// ISBN
        /// </summary>  
        [Required]
        [Display(Name = "ISBN", Order = 20)]
        public string Isbn { get; set; }

        /// <summary>
        /// Год издания книги
        /// </summary>  
        [Display(Name = "Год издания книги", Order = 30)]
        public int Year { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary> 
        [ScaffoldColumn(false)]
        public DateTime CreateAt { get; set; }
    }
}