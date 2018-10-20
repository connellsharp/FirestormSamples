using System;
using System.Linq.Expressions;
using Firestorm.Stems;
using Firestorm.Stems.Attributes.Basic.Attributes;
using Firestorm.Stems.Attributes.Definitions;
using FirestormSample.Domain.Models;

namespace FirestormSample.Api.Stems
{
    public class PostsStem : Stem<Post>
    {
        [Get, Identifier]
        public static Expression Id
        {
            get { return Expression(p => p.Id); }
        }
        
        [Get, Set, Identifier]
        public static Expression Slug
        {
            get { return Expression(p => p.Slug); }
        }
        
        [Get, Set]
        public static Expression Text
        {
            get { return Expression(p => p.Text); }
        }
        
        [Get]
        public static Expression TotalLikes
        {
            get { return Expression(b => b.Likes.Count); }
        }
        
        [Get(Display.Hidden), Substem(typeof(LikesStem))]
        public static Expression Likes
        {
            get { return Expression(b => b.Likes); }
        }
        
        [Get, Substem(typeof(CommentsStem))]
        public static Expression Comments
        {
            get { return Expression(b => b.Comments); }
        }
        
        [Get, Substem(typeof(UsersStem))]
        public static Expression PostedByUser
        {
            get { return Expression(b => b.PostedByUser); }
        }
        
        [Get]
        public static Expression PostedDate
        {
            get { return Expression(b => b.PostedDate); }
        }

        public override void OnCreating(Post newItem)
        {
            newItem.PostedDate = DateTime.UtcNow;
        }

        public override bool CanAddItem()
        {
            return true;
        }
    }
}