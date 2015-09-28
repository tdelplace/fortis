namespace Fortis.Model.Fields
{
	public interface IRulesFieldWrapper : IFieldWrapper<string>
	{
	    bool Evaluate();
	}
}
