

namespace Auth.Application.Validations
{
    public static class ObjectValidations
    {
        public static void ObjectIsNull<T>(T obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException("Null Object is comeing : " + nameof(obj));
            }
        }


        public static void ProportyIsNull<Type>(Type type)
        {
            if (type is null)
            { throw new ArgumentNullException("null is comeing : "  + nameof(type)); }
        }
    }
}
