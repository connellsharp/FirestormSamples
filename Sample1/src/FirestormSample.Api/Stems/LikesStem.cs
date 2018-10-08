using Firestorm.Stems;
using FirestormSample.Models;

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