using System.Linq.Expressions;
using Firestorm.Stems;
using Firestorm.Stems.Essentials;
using TodoBackend.Stems.Helpers;
using TodoBackend.Stems.Models;

namespace TodoBackend.Stems.Stems
{
    public class TodosStem : Stem<Todo>
    {
        [Get, Nested, Identifier]
        public static Expression Id => Expression(t => t.Id);
        
        [Get, Nested, Set]
        public static Expression Title => Expression(t => t.Title);
        
        [Get, Nested, Set]
        public static Expression Order => Expression(t => t.Order);
        
        [Get, Nested, Set]
        public static Expression Completed => Expression(t => t.Completed);
        
        [Get, Nested]
        public static Expression Url => Expression(t => "http://localhost:5000/todos/" + t.Id);

        public override void OnCreating(Todo newItem)
        {
            newItem.Completed = false;
            newItem.Id = AutoIncrement.PopTodoId();
        }
    }
}