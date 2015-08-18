namespace ProcessViewer.Library.Common
{
    public class Utilities
    {
        /// <summary>
        ///  Releases Comm objects
        /// </summary>
        /// <param name="runtimeObject">Object to release</param>
        public static void NullAndRelease(object runtimeObject)
        {
            try
            {
                if (runtimeObject != null &&
                    System.Runtime.InteropServices.Marshal.IsComObject(runtimeObject))
                {

                    // The RCW's reference count gets incremented each time the
                    // COM pointer is passed from unmanaged to managed code.
                    // Call ReleaseComObject in a loop until it returns 0 to be
                    // sure that the underlying COM object gets released.
                    var referenceCount = System.Runtime.InteropServices.
                        Marshal.ReleaseComObject(runtimeObject);

                    while (0 < referenceCount)
                    {
                        referenceCount =
                         System.Runtime.InteropServices.Marshal.ReleaseComObject(runtimeObject);
                    }
                }
            }
            finally
            {
                runtimeObject = null;
            }
        }
    }
}
