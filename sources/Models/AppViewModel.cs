﻿using System.Collections.Generic;
using System.Linq;

using SetMeta.Web.Data.Entities;

namespace SetMeta.Web.Models
{
    public class AppModel : BaseModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public List<TokenModel> Tokens { get; set; }
        public string CreatedBy { get; set; }

        public long UsageCount
        {
            get { return Tokens.Sum(x => x.UsageCount); }
        }

        public AppModel()
        {
            Tokens = new List<TokenModel>();
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name)
                   && !string.IsNullOrEmpty(Url);
        }

        public static AppModel Map(App entity)
        {
            var model = new AppModel
            {
                Id = entity.PublicId,
                Email = entity.UserEmail,
                IsActive = entity.IsActive,
                Name = entity.Name,
                Description = entity.Description,
                Url = entity.Url != null && entity.Url.StartsWith("http") ? entity.Url
                                                                          : string.Format("http://{0}", entity.Url)
            };

            var tokens = entity.Tokens.Where(x => !x.IsDeleted);
            foreach (var token in tokens)
            {
                model.Tokens.Add(new TokenModel
                {
                    CreationDate = token.CreatedAt,
                    UsageCount = token.UsageCount,
                    Token = token.Key
                });
            }

            return model;
        }
    }
}