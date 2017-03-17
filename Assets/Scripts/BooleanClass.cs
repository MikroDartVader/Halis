public class Boolean
{
    bool f;

    public Boolean(bool flag)
    {
        f = flag;
    }

    public static Boolean operator !(Boolean val)
    {
        return new Boolean(!val.f);
    }

    public static bool operator true(Boolean val)
    {
        return val.f;
    }

    public static bool operator false(Boolean val)
    {
        return val.f;
    }
}

