using System;

namespace SetMeta.Web.ViewModels
{
    public class TokenViewModel : BaseViewModel
    {
        public string Token { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationDateStr
        {
            get
            {
                return CreationDate.ToString("f");
            }
        }

        public long UsageCount { get; set; }
        public long CreatedBy { get; set; }
        public string AppId { get; set; }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Token);
        }
    }
}