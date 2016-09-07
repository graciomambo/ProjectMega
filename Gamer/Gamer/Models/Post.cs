using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamer.Models
{
    public class Post
    {
        private int PostId { get; set; }
        private String Title { get; set; }
        private int PostTypeId { get; set; }
        private PostType PostType { get; set; }
        private DateTime PostDate { get; set; }
        private String Content { get; set; }
        private int CategoryId { get; set; }
        private Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection <Comment> Coments { get; set; }
        private String Url { get; set; }
        private Boolean Active { get; set; }
        private int LayoutId { get; set; }
        private Layout Layout { get; set; }    
        private String Excerpt { get; set; }

        public Post() { Tags = new HashSet<Tag>(); }
    }
    public class Category
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }
        private int Id { get; set; }
        private String Name { get; set; }
        private String Slug { get; set; }
        private String Description { get; set; }
        public virtual ICollection <Post> Posts { get; set; }

    }
    public class Comment
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private String Slug { get; set; }
        private String Description { get; set; }
        private Post Post { get; set; }
        private int PostId { get; set; }

    }
    public partial class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
    public class PostType
    {
        public PostType()
        {
            this.Posts = new HashSet<Post>();
        }
        private int Id { get; set; }
        private String Name { get; set; }
        public virtual ICollection <Post> Posts { get; set; }
    }
    public partial class Layout
    {
        public Layout()
        {
            this.Posts = new HashSet<Post>();
        }
        private int Id { get; set; }
        private String Name { get; set; }
        public virtual ICollection <Post> Posts { get; set; }
    }
}