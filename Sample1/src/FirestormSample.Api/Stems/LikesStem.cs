using Firestorm.Stems;
using FirestormSample.Domain.Models;

namespace FirestormSample.Api.Stems
{
    public class LikesStem : Stem<Like>
    {
        public override bool CanAddItem()
        {
            return true;
        }
    }
}