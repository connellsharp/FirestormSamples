using System.Linq.Expressions;
using Firestorm.Stems;
using Firestorm.Stems.Essentials;
using FirestormSample.Domain.Models;

namespace FirestormSample.Api.Stems
{
    public class UsersStem : Stem<User>
    {
        [Get, Identifier]
        public static Expression Id
        {
            get { return Expression(p => p.Id); }
        }
    }
}