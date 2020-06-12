using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyStore.BLL
{
    class findandreplaceBLL
    {
       public string textToFind { get; set; }
        public string  textToReplace { get; set; }
        public  bool matchCase { get; set; }
        public bool  matchWholeWord { get; set; }
        public bool matchWildcards { get; set; }
        public bool matchSoundsLike { get; set; }
        public bool matchAllWordForms { get; set; }
        public bool forward { get; set; }
        public int wrap  { get; set; }
        public bool format { get; set; }
        public int  replace { get; set; }

    }
}
