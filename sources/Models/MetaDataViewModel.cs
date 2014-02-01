using SetMeta.Web.Data.Entities;

namespace SetMeta.Web.Models
{
    public class MetaDataModel : BaseModel
    {
        public string TypeName { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }

        public string Id { get; set; }
        public override bool IsValid()
        {
            return true;
        }

        public static MetaDataModel Map(MetaData entity)
        {
            var model = new MetaDataModel
            {
                Id = entity.PublicId,
                Code = entity.Code,
                Url = entity.Url,
                Name = entity.Name,
                Description = entity.Description
            };

            return model;
        }

        
    }
}