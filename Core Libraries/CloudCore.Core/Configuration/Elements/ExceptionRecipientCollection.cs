using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CloudCore.Core.Configuration.Elements
{
    public class ExceptionRecipientCollection : ConfigurationElementCollection 
    {
        [ConfigurationProperty("postageAppApiKey", IsRequired = false)]
        public string PostageAppApiKey
        {
            get { return this["postageAppApiKey"].ToString(); }
            set { this["postageAppApiKey"] = value; }
        }

        public RecipientElement this[int index]
        {
            get { return (RecipientElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(RecipientElement recipientElement)
        {
            BaseAdd(recipientElement);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(RecipientElement recipientElement)
        {
            BaseRemove(recipientElement.RecipientAddress);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RecipientElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RecipientElement)element).RecipientAddress;
        }
    }
}
