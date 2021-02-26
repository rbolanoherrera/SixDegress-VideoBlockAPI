using VideoBlock.Entities;

namespace VideoBlock.API.Helpers
{
    /// <summary>
    /// Funciones utilizadas como extensiones
    /// </summary>
    public static class ExtensionMethods
    {
        public static User WithoutPassword(this User obj)
        {
            if (obj != null)
                obj.Password = null;

            return obj;
        }
    }
}