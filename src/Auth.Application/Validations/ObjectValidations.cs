

namespace Auth.Application.Validations
{
    public static class ObjectValidations
    {
        public static void ObjectIsNull<T>(T obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
        }


        public static void ProportyIsNull<Type>(Type type)
        {
            if (type is null)
            { throw new ArgumentNullException(nameof(type)); }
        }
    }
}
