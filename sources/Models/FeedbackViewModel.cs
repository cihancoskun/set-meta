using SetMeta.Web.Data.Entities;

namespace SetMeta.Web.Models
{
    public class FeedbackModel : BaseModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public bool IsActive { get; set; }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Email)
                   && !string.IsNullOrEmpty(Info);
        }

        public static FeedbackModel Map(Feedback entity)
        {
            var model = new FeedbackModel
            {
                Id = entity.PublicId,
                Email = entity.Email,
                IsActive = entity.IsActive,
                Info = entity.Info        
            };
            return model;
        }
    }
}