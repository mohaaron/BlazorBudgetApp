using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;

namespace BudgetApp.Shared
{
	public static class EntityHelper
	{
		/// <summary>
		/// Use JsonSerializer to copy the entity to a new instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static T Clone<T>(T source)
		{
			var serialized = JsonSerializer.Serialize(source, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
			return JsonSerializer.Deserialize<T>(serialized, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
		}

		/// <summary>
		/// Make a copy of a collection. This didn't work as expected. Use Swap instead.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="col"></param>
		/// <param name="match"></param>
		/// <param name="newItem"></param>
		public static void ReplaceItem<T>(this Collection<T> col, Func<T, bool> match, T newItem)
		{
			var oldItem = col.FirstOrDefault(i => match(i));
			var oldIndex = col.IndexOf(oldItem);
			col[oldIndex] = newItem;
		}

		/// <summary>
		/// Make a copy of a collection.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="collection"></param>
		/// <param name="oldValue"></param>
		/// <param name="newValue"></param>
		public static void Swap<T>(this ICollection<T> collection, T oldValue, T newValue)
		{
			// In case the collection is ordered, we'll be able to preserve the order
			var collectionAsList = collection as IList<T>;
			if (collectionAsList != null)
			{
				var oldIndex = collectionAsList.IndexOf(oldValue);
				collectionAsList.RemoveAt(oldIndex);
				collectionAsList.Insert(oldIndex, newValue);
			}
			else
			{
				// No luck, so just remove then add
				collection.Remove(oldValue);
				collection.Add(newValue);
			}

		}
	}
}
