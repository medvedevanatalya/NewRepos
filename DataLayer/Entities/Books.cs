namespace DataLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public int? Pages { get; set; }

        public int? Price { get; set; }

        public virtual Authors Authors { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UsersAndBooks> UsersAndBooks { get; set; }

        public int GenreBookId { get; set; }
        public virtual GenresBooks GenresBooks { get; set; }
    }
}
