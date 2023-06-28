
public abstract class AbstractSingleton<TypeBase, TypeImpl> where TypeBase : class where TypeImpl : TypeBase, new()
{
	protected static TypeBase instance = null;
	public static TypeBase Instance
	{
		get {
			if( instance == null )
			{
				instance = new TypeImpl();
			}
			return instance;
		}
	}

    public static void Init()
    {
        if (instance == null)
        {
            instance = new TypeImpl();
        }
    }

    public AbstractSingleton( )
	{
	}

	public virtual string SingletonName
	{
		get {
			return GetType().ToString();
		}
	}
}
