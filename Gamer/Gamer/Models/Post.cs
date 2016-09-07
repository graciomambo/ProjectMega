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
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
          
        }
    
        [Key]
        public int PostId { get; set; }

        [ForeignKey("PostType")]
        [DisplayName("Tipo")]
        public int PostTypeId { get; set; }
        [DisplayName("Template")]
        [ForeignKey("Layout")]
        public int LayoutId { get; set; }
        [DisplayName("Categoria")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [DisplayName("Titulo")]
        [StringLength(160)]
        public String Title { get; set; }
        [DisplayName("Data de Criação")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Data de Publicação")]
        [DataType(DataType.Date)]
        public DateTime PostedDate { get; set; }
        public String Content { get; set; }
        [DisplayName("Link")]
        public String Url { get; set; }
        [DisplayName("Resumo")]
        public String Excerpt { get; set; }
        [DisplayName("Publicado?")]
        public Boolean Active { get; set; }
        public virtual PostType PostType { get; set; }
        public virtual Template Layout { get; set; }  
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }



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
    public partial class Template
    {
        public Template()
        {
            this.Posts = new HashSet<Post>();
        }
        [Key]
        [DisplayName("Template")]
        public int LayoutId { get; set; }
        [DisplayName("Template")]
        public String Name { get; set; }
        public virtual ICollection <Post> Posts { get; set; }
    }
}