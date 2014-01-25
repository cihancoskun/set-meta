using SetMeta.Web.Domain.Entities;

namespace SetMeta.Web.Models
{
    public class DayModel : BaseMetaModel
    {
        public static DayModel MapEntityToModel(Day entity)
        {
            return new DayModel
            {
                Code = entity.Code,
                Value = entity.Value,
                Description = entity.Description
            };
        }
    }
}