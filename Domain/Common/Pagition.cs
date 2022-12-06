using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public class Pagition
    {
        private int page;
        private int rows;
        public Pagition(int page, int rows)
        {
            this.page = page;
            this.rows = rows;
        }
        public Pagition()
        {
            page = 1;
            rows = 10;
        }
        public int Page
        {
            get => page > 0 ? page : 1;
            set => page = value;
        }
        public int Rows
        {
            get => rows > 0 ? rows : 10;
            set => rows = value;
        }

    }
}
