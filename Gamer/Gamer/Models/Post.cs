using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamer.Models
{
    public class Post
    {
        public Post()
        {
            Tags = new HashSet<Tag>();
            Comments = new HashSet<Comment>();
           

        }
    
        [Key]
        public int PostId { get; set; }

        [ForeignKey("PostType")]
        [DisplayName("Tipo")]
        public int PostTypeId { get; set; }
   
        [DisplayName("Categoria")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [DisplayName("Titulo")]
        [StringLength(75)]
        public String Title { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Data de Criação")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Data Publicada")]
        [DataType(DataType.Date)]
        public DateTime? PostedDate { get; set; }
        [DisplayName("Texto")]
        [DataType(DataType.MultilineText)]
        public String Content { get; set; }
        [DisplayName("Link")]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public String Url { get; set; }

       
        [ScaffoldColumn(false)]
        [DisplayName("Resumo")]
        [StringLength(140)]
        public String Excerpt { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Publicado")]
        public Boolean Active { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Visualização")]
        public int Views { get; set; }
        public virtual PostType PostType { get; set; }
        
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public void validateAttributes()
        {
            CreatedDate = System.DateTime.Now;
            if (Content.Count() > 140)
                Excerpt = Content.Substring(1, 130) + "...";
            else
                Excerpt = Content+"...";
            if (Active)
               PostedDate = System.DateTime.Now;
            else
                PostedDate = System.DateTime.Now;
        }

    }
    public partial class Category
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }
        [Key]
        [DisplayName("Categoria")]
        public int CategoryId { get; set; }
        [DisplayName("Categoria")]
        public String Name { get; set; }
        public String Slug { get; set; }
        public String Description { get; set; }
        public virtual ICollection <Post> Posts { get; set; }

    }
    public partial class Comment
    {
        [Key]
        [DisplayName("Comentario")]
        public int CommentId { get; set; }
        public string Author { get; set; }
        public String Content { get; set; }
        public virtual Post Post { get; set; }
        public int PostId { get; set; }

    }
    public partial class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }
        [Key]
        [DisplayName("Tag")]
        public int TagId { get; set; }
        [DisplayName("Tag")]
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
    public partial class PostType
    {
        public PostType()
        {
            this.Posts = new HashSet<Post>();
        }
        [Key]
        [DisplayName("Tipo")]
        public int PostTypeId { get; set; }
        [DisplayName("Tipo")]
        public String Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
  

}