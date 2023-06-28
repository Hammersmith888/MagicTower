namespace ToolShed.Android.OS
{
    public class Build
    {
        public static class Version
        {
            public static int api { get; private set; }

            static Version()
            {
                using (UnityEngine.AndroidJavaClass buildClass = new UnityEngine.AndroidJavaClass("android.os.Build$VERSION"))
                {
                    api = buildClass.GetStatic<int>("SDK_INT");
                }
            }
        }
    }
}