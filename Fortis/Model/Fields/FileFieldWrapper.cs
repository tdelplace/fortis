using Fortis.Providers;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System.Web;

namespace Fortis.Model.Fields
{
	public class FileFieldWrapper : FieldWrapper, IFileFieldWrapper
	{
		protected Item MediaItem => ((FileField)Field).MediaItem;

	    public FileFieldWrapper(Field field, ISpawnProvider spawnProvider)
			: base(field, spawnProvider) { }

		public FileFieldWrapper(string key, ref ItemWrapper item, ISpawnProvider spawnProvider, string value = null)
			: base(key, ref item, value, spawnProvider) { }

		public override IHtmlString Render(string parameters = null, bool editing = false)
		{
			var returnValue = string.Empty;

			if (MediaItem != null)
			{
				returnValue = "/" + MediaManager.GetMediaUrl(MediaItem);
			}

			return new HtmlString(returnValue);
        }

        public T GetTarget<T>() where T : IItemWrapper
        {
            if (Field == null || Field.Value.Length == 0)
            {
                return default(T);
            }

            if (MediaItem != null)
            {
                var target = SpawnProvider.FromItem<T>(new Item(MediaItem.ID, MediaItem.InnerData, MediaItem.Database));
                return (T)((target is T) ? target : null);
            }
            return default(T);
        }

        public string Value => Render().ToHtmlString();
	}
}
