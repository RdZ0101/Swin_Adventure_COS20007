using System;
using System.Collections.Generic;
using System.Linq;

namespace Swin_Adventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents) 
        {
            foreach (string S in idents)
            {
                _identifiers.Add(S.ToLower());
            }
        } 
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                    return "";
                else
                    return _identifiers[0];
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
