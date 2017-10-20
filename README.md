# An opinionated approach to using .NETs HttpClient safely

This library aims to make using [HttpClient](https://msdn.microsoft.com/en-us/library/HttpClient) safer and easier, via explicitly typed interfaces and implementations.

# Whats wrong with HttpClient?

There are 2 related problems with it. This library aims to address one of those issues and enable the user to easily address the second.

### A) It is made to be thread safe and shareable, however it also adds state in via properties leaving users to manually remember to not using some of its functionality, depending on the context it is used in.

If you inject a HttpClient, the consumer can not tell whether they should or should not use these stateful
properties without knowing about the environment outside of the class, i.e HttpClient forces
tight coupling between its use and its lifecycle management.

This libraries solution to this problem is to split the stateless and stateful functionality into separate classes so that users can opt
into only the stateless behaviour to share the instance, unless the specifically require the stateful funcitonality.

If a HttpClient is meant to be shared amongst multiple consumers, it should use an [ISharedHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient.Abstractions/ISharedHttpClient.cs)
If a HttpClient is meant to be owned by a single consumer, it can use a [IUniqueHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient.Abstractions/IUniqueHttpClient.cs)

UniqueHttpClient configuiration should be done via a [IHttpClientBuilder](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient.Abstractions/IUniqueHttpClient.cs)
as the functionality is not exposed in the client itself. This is because if an attempt to set a configuration property after sending a http request, an InvalidOperationException is thrown (See footnote 2)

### B) It is designed to be reused but also has confusing semantics around disposing and reusing. Creating and disposing HttpClients for every http request can cause significant errors in some cases, and decreases performance in general. (See 1 in footnotes)

The interfaces provided by this library purposefully do not implement IDisposable, as consumers should generally not call this themselves.
If you are using a DI container then that should properly dispose of the resource on your behalf.

Additionally SingleHttpClient shares a single http client between all instances. This allows consumers of the library to replace existing uses of 

```
using (var client = new HttpClient)
...
```

with

```
(var client = new SingleHttpClient)
...
```

and avoids the issue described in footnote 1. 

# How to use

ISharedHttpClient is implemented by [SingleHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient/SingleHttpClient.cs) and [DefaultHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient/DefaultHttpClient.cs)
IUniqueHttpClient is implemented by [UniqueHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient/UniqueHttpClient.cs)

SingleHttpClient internally uses a single HttpClient to allow regular creation of clients without exhausting the systems sockets. It is a good default choice, as it is hard to use incorrectly.

DefaultHttpClient and UniqueHttpClient do not reuse HttpClients and as so care must be taken not to create too many.

# TODO

### Other issues related to HttpClient should be investigated and fixed, known things that need addressing

DefaultConnectionLimit should be increased when a significant amount of traffic is going to a few servers.
https://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit(v=vs.110).aspx

https://blogs.msdn.microsoft.com/jpsanders/2009/05/20/understanding-maxservicepointidletime-and-defaultconnectionlimit/

https://github.com/dotnet/corefx/issues/2332

ConnectionLeaseTimeout should be set to avoid DNS refresh issues

https://msdn.microsoft.com/en-us/library/system.net.servicepoint.connectionleasetimeout(v=vs.110).aspx

http://byterot.blogspot.com.au/2016/07/singleton-httpclient-dns.html

https://github.com/dotnet/corefx/issues/11224

### IUniqueHttpClient should add readonly access to DefaultRequestHeaders

Currently IUniqueHttpClient doesn't allow reading DefaultRequestHeaders as the objects returned are mutable and would allow other consumers to interfere with each other.

Should create a read only snapshot of these headers to allow consumers to read without modifying the values.

### To allow better reuse of HttpClients without restricting configuration changes

Investigate separating config completely from HttpClient and then modifying HttpRequestMessage to add custom configuration before forwarding to shared HttpClient

# Footnotes

### 1.
https://github.com/mspnp/performance-optimization/blob/27edbfd20f2906abd93da28aeb0d12f2c237a4e7/ImproperInstantiation/docs/ImproperInstantiation.md

https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/

### 2.
https://github.com/dotnet/corefx/blob/819da8af67f04867012a3fb274e1eca6078a048e/src/System.Net.Http/src/System/Net/Http/HttpClient.cs#L594

