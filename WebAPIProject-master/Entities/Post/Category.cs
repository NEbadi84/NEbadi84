using Entities.Common;
using Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Post
{
    public class Category:BaseEntity
    {
       // [Required,StringLength(100)]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        
       // [ForeignKey(nameof(ParentCategoryId))]
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
        public ICollection<Post> Posts { get; set; }
        public int CreatedById { get; set; }
        public User.User CreatedBy { get; set; }
       
    }


    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(p => p.ChildCategories).WithOne(c => c.ParentCategory).HasForeignKey(p => p.ParentCategoryId);
            builder.HasMany(p => p.Posts).WithOne(q => q.Category).HasForeignKey(p => p.CategoryId);

            //builder.HasOne(p => p.CreatedBy).WithMany(c => c.Cate)
             
            
        }
    }
}
