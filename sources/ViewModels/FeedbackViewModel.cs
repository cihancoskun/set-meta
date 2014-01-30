using System.Collections.Generic;
using System.Linq;

using SetMeta.Web.Models;

namespace SetMeta.Web.ViewModels
{
    public class FeedbackViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public bool IsActive { get; set; }

        public FeedbackViewModel()
        {
            
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Email)
                   && !string.IsNullOrEmpty(Info);
        }

        public static FeedbackViewModel Map(Feedback entity)
        {
            var model = new FeedbackViewModel
            {
                Id = entity.PublicId,
                Email = entity.Email,
                IsActive = entity.IsActive,
                Info = entity.Name        
            };
            return model;
        }
    }
}