namespace Fortis.Model.Fields
{
	public interface IFileFieldWrapper : IFieldWrapper<string>
	{
	    T GetTarget<T>() where T : IItemWrapper;
	}
}
