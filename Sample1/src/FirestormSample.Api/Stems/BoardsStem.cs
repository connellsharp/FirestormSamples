using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Firestorm.Stems;
using Firestorm.Stems.Attributes.Basic.Attributes;
using FirestormSample.Models;

namespace FirestormSample.Api.Stems
{
    public class BoardsStem : Stem<Board>
    {
        [Get, Identifier]
        public static Expression Id
        {
            get { return Expression(b => b.Id); }
        }
        
        [Get, Set, Identifier]
        public static Expression Slug
        {
            get { return Expression(b => b.Slug); }
        }
        
        [Get, Set]
        public static Expression Name
        {
            get { return Expression(b => b.Name); }
        }
        
        [Get, Substem(typeof(PostsStem))]
        public static Expression Posts
        {
            get { return Expression(b => b.Posts); }
        }

        public override bool CanAddItem()
        {
            return true;
        }
    }
}