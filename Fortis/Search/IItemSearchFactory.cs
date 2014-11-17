﻿using Fortis.Model;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortis.Search
{
	public interface IItemSearchFactory
	{
		IQueryable<T> Search<T>(IProviderSearchContext context, IExecutionContext executionContext = null) where T : IItemWrapper;
	}
}
