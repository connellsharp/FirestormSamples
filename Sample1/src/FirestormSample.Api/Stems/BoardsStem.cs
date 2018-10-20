using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Firestorm.Stems;
using Firestorm.Stems.Attributes.Basic.Attributes;
using FirestormSample.Domain.Messages;
using FirestormSample.Domain.Models;

namespace FirestormSample.Api.Stems
{
    public class BoardsStem : Stem<Board>
    {
        private readonly IMessagePublisher _publisher;

        public BoardsStem(IMessagePublisher publisher)
        {
            _publisher = publisher;
        }
        
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
        
        [Get]
        public static Expression Name
        {
            get { return Expression(b => b.Name); }
        }

        [Set]
        public void SetName(Board board, string name)
        {
            board.Name = name;
            
            if (string.IsNullOrEmpty(board.Slug) && name != null)
                board.Slug = name.ToLower().Replace(" ", "-");     
        }
        
        [Get, Substem(typeof(PostsStem))]
        public static Expression Posts
        {
            get { return Expression(b => b.Posts); }
        }

        public override void OnCreating(Board newItem)
        {
            newItem.CreatedDate = DateTime.UtcNow;       
        }

        public override async Task OnSavedAsync(Board item)
        {
            await _publisher.PublishAsync(new BoardCreatedEvent
            {
                Id = item.Id,
                Slug = item.Slug
            });
        }

        public override bool CanAddItem()
        {
            return true;
        }
    }
}