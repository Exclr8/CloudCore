using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CloudCore.Core.Hosting.VirtualFiles;

namespace CloudCore.Core.Hosting
{
    public class VirtualFileBaseCollection : KeyedCollection<String, CloudCoreVirtualFile>
    {

        public static VirtualFileBaseCollection Files = new VirtualFileBaseCollection();

        public VirtualFileBaseCollection() : base(StringComparer.InvariantCultureIgnoreCase) { }

        public VirtualFileBaseCollection(IEqualityComparer<String> comparer) : base(comparer) { }

        public VirtualFileBaseCollection(IEqualityComparer<String> comparer, int dictionaryCreationThreshold) : base(comparer, dictionaryCreationThreshold) { }

        protected override string GetKeyForItem(CloudCoreVirtualFile item)
        {
            return item.VirtualPath;
        }
    }
}