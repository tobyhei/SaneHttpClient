using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SaneHttpClient
{
    /// <summary>
    /// Base functionality shared by <see cref="DefaultHttpClient"/>> and <see cref="UniqueHttpClient"/>
    /// which does not expose it's internal <see cref="System.Net.Http.HttpClient"/> or any of it's stateful methods
    /// 
    /// Not intended to be used externally, just for code reuse within the library
    /// </summary>
    public abstract class HttpClientBase
    {
        
    }
}
