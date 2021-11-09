﻿using System;
using System.Text;

namespace PCRD_KR_ArenaSim
{
    class Combination
    {
        private long n = 0;
        private long k = 0;
        private long[] data = null;

        public Combination(long n, long k)
        {
            if (n < 0 || k < 0)
            {
                throw new Exception("Negative parameter in constructor");
            }

            this.n = n;
            this.k = k;
            this.data = new long[k];

            for (long i = 0; i < k; ++i)
            {
                this.data[i] = i;
            }
        }

        public Combination Successor()
        {
            if (this.data.Length == 0 ||
                this.data[0] == this.n - this.k)
            {
                return null;
            }

            Combination answer = new Combination(this.n, this.k);

            long i;
            for (i = 0; i < this.k; ++i)
            {
                answer.data[i] = this.data[i];
            }

            for (i = this.k - 1; i > 0 && answer.data[i] == this.n - this.k + i; --i) ;

            ++answer.data[i];

            for (long j = i; j < this.k - 1; ++j)
            {
                answer.data[j + 1] = answer.data[j] + 1;
            }

            return answer;
        }

        public string[] ApplyTo(string[] strarr)
        {
            if (strarr.Length != this.n)
            {
                throw new Exception("Bad array size");
            }

            string[] result = new string[this.k];

            for (long i = 0; i < result.Length; ++i)
            {
                result[i] = strarr[this.data[i]];
            }

            return result;
        }

        public static long Choose(long n, long k)
        {
            if (n < 0 || k < 0)
            {
                throw new Exception("Invalid negative parameter in Choose()");
            }

            if (n < k)
            {
                return 0;
            }

            if (n == k)
            {
                return 1;
            }

            long delta, iMax;

            if (k < n - k)
            {
                delta = n - k;
                iMax = k;
            }
            else
            {
                delta = k;
                iMax = n - k;
            }

            long answer = delta + 1;

            for (long i = 2; i <= iMax; ++i)
            {
                checked { answer = (answer * (delta + i)) / i; }
            }

            return answer;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append("{ ");

            for (long i = 0; i < this.k; ++i)
            {
                sb.AppendFormat("{0} ", this.data[i]);
            }

            //sb.Append("}");

            return sb.ToString();
        }
    }
}
