using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_SearchWord
    {
        private long _totalSearch;
        public long totalSearch
        {
            get { return _totalSearch; }
            set { _totalSearch = value; }
        }

        private String _KeySearch;
        public String KeySearch
        {
            get { return _KeySearch; }
            set { _KeySearch = value; }
        }

        private long _totalGoogle;
        public long totalGoogle
        {
            get { return _totalGoogle; }
            set { _totalGoogle = value; }
        }


        private long _totalBing;
        public long totalBing
        {
            get { return _totalBing; }
            set { _totalBing = value; }
        }
    }
}
