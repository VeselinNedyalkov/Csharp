using MusicHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AlbumNamelength)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public decimal Price => this.Songs.Count > 0  ? this.Songs.Sum(x => x.Price) : 0m;

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
