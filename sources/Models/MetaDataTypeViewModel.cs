using SetMeta.Web.Data.Entities;

namespace SetMeta.Web.Models
{
    public class MetaDataTypeModel : BaseModel
    {
        public string Id { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public static MetaDataTypeModel Map(MetaDataType entity)
        {
            var model = new MetaDataTypeModel
            {
                Id = entity.PublicId, 
                IsActive = entity.IsActive,
                Name = entity.Name,
                Description = entity.Description,
                Code = entity.Code
            };
              
            return model;
        }
    }
}