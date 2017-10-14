using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MovieArchive.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }

        [DataType(DataType.MultilineText)]
        public string Review { get; set; }

        /*
         * Consider using url shortening as urls will be extremely long
         */ 
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
    }

    /*
     * The MovieDBContext class represents the Entity Framework movie database context, 
     * which handles fetching, storing, and updating Movie class instances in a database. 
     * The MovieDBContext derives from the DbContext base class provided by the Entity Framework.
     */
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}