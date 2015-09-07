using System;
using Fortis.Helpers;
using Sitecore.Data.Fields;
using Fortis.Providers;

namespace Fortis.Model.Fields
{
	public class RulesFieldWrapper : FieldWrapper, IRulesFieldWrapper
    {
		public string Value => _rawValue;

	    public RulesFieldWrapper(Field field, ISpawnProvider spawnProvider)
			: base(field, spawnProvider) { }

		public RulesFieldWrapper(string key, ref ItemWrapper item, ISpawnProvider spawnProvider, string value = null)
			: base(key, ref item, value, spawnProvider)
		{
		}

	    public bool Evaluate()
	    {
	        return RulesHelper.EvaluateRule(this.Field);
	    }
	}
}
