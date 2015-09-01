﻿using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using Fortis.Providers;

namespace Fortis.Model
{
	public partial interface IItemFactory
	{
		Guid GetTemplateID(Type type);
		Type GetInterfaceType(Guid templateId);
		void Publish(IEnumerable<IItemWrapper> wrappers);
		void Publish(IEnumerable<IItemWrapper> wrappers, bool children);
		T GetSiteHome<T>() where T : IItemWrapper;
		T GetSiteRoot<T>() where T : IItemWrapper;
		T GetContextItem<T>() where T : IItemWrapper;
		IRenderingModel<TPageItem, TRenderingItem> GetRenderingContextItems<TPageItem, TRenderingItem>(IItemFactory factory = null)
			where TPageItem : IItemWrapper
			where TRenderingItem : IItemWrapper;
		IRenderingModel<TPageItem, TRenderingItem, TRenderingParametersItem> GetRenderingContextItems<TPageItem, TRenderingItem, TRenderingParametersItem>(IItemFactory factory = null)
			where TPageItem : IItemWrapper
			where TRenderingItem : IItemWrapper
			where TRenderingParametersItem : IRenderingParameterWrapper;
		T GetContextItemsItem<T>(string key) where T : IItemWrapper;
		T Create<T>(IItemWrapper parent, string itemName) where T : IItemWrapper;
		T Create<T>(string parentPath, string itemName) where T : IItemWrapper;
		T Create<T>(Guid parentId, string itemName) where T : IItemWrapper;
		
		T Select<T>(string path) where T : IItemWrapper;
		T Select<T>(Guid id) where T : IItemWrapper;
		T Select<T>(string path, string database) where T : IItemWrapper;
		T Select<T>(Guid id, string database) where T : IItemWrapper;
		T Select<T>(Guid id, string database, string language) where T : IItemWrapper;

		IEnumerable<T> SelectAll<T>(string path) where T : IItemWrapper;
		IEnumerable<T> SelectAll<T>(string path, string database) where T : IItemWrapper;
		T SelectChild<T>(IItemWrapper item) where T : IItemWrapper;
		T SelectChild<T>(string path) where T : IItemWrapper;
		T SelectChild<T>(Guid id) where T : IItemWrapper;
		T SelectChildRecursive<T>(string path) where T : IItemWrapper;
		T SelectChildRecursive<T>(Guid id) where T : IItemWrapper;
		IEnumerable<T> SelectChildren<T>(IItemWrapper item) where T : IItemWrapper;
		IEnumerable<T> SelectChildren<T>(string path) where T : IItemWrapper;
		IEnumerable<T> SelectChildren<T>(Guid id) where T : IItemWrapper;
		IEnumerable<T> SelectChildrenRecursive<T>(IItemWrapper wrapper) where T : IItemWrapper;
		T SelectSibling<T>(IItemWrapper wrapper) where T : IItemWrapper;
		IEnumerable<T> SelectSiblings<T>(IItemWrapper wrapper) where T : IItemWrapper;
		T GetRenderingDataSource<T>(Control control) where T : IItemWrapper;
        ISpawnProvider SpawnProvider { get; }
    }
}
