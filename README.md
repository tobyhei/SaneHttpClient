# An opinionated approach to using .NETs HttpClient

This library aims to make using [HttpClient](https://msdn.microsoft.com/en-us/library/HttpClient) safer and easier, via explicitly typed interfaces and implementations.

# Whats wrong with HttpClient? 

There are 2 related problems with it. This library aims to address one of those issues and enable the user to easily address the second.

A) It is made to be thread safe and shareable, however it also adds state in via properties leaving users to manually remember to not using some of its functionality, depending on the context it is used in.

If you inject a HttpClient, the consumer can not tell whether they should or should not use these stateful
properties without knowing about the environment outside of the class, i.e HttpClient forces
tight coupling between its use and its lifecycle management.

This libraries solution to this problem is to split the stateless and stateful functionality into separate interfaces so that users can opt
into only the stateless behaviour to share the instance, unless the specifically require the stateful funcitonality.

If a HttpClient is meant to be shared amongst multiple consumers, it should use an [ISharedHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient.Abstractions/ISharedHttpClient.cs)
If a HttpClient is meant to be owned by a single consumer, it can use a [IUniqueHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient.Abstractions/IUniqueHttpClient.cs)

B) It is designed to be reused but also has confusing semantics around disposing and reusing. Creating and disposing HttpClients for every http request can cause significant errors in some cases, and decreases performance in general. (See 1 in footnotes)

The interfaces provided by this library purposefully do not implement IDisposable, as consumers should generally not call this themselves.
If you are using a DI container then that should properly dispose of the resource on your behalf.

# How to use

ISharedHttpClient is implemented by [SharedHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient/SharedHttpClient.cs)
IUniqueHttpClient is implemented by [UniqueHttpClient](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient/UniqueHttpClient.cs)

Both of which internally use [HttpClientPool](https://github.com/tobyhei/SaneHttpClient/blob/master/src/SaneHttpClient/HttpClientPool.cs) to reuse HttpClients as much as possible.
There is a static instance of the HttpClientPool that can be used by default when creating instances of SharedHttpClient and UniqueHttpClients,
alternatively a custom HttpClientPool can be created specifying which HttpMessageHandler to use for HttpClients.

Any HttpClientPool created must be long lived to effectively pool HttpClients. It is recommended that either the default static instance is used or that a custom instance is used as a singleton.

As both SharedHttpClient and UniqueHttpClient are designed to use long living HttpClients, while it is generally safe to do so, HttpClient does have an issue around DNS resolution (See 2 in footnotes)

1.
https://github.com/mspnp/performance-optimization/blob/27edbfd20f2906abd93da28aeb0d12f2c237a4e7/ImproperInstantiation/docs/ImproperInstantiation.md

https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/

2.
http://byterot.blogspot.com.au/2016/07/singleton-httpclient-dns.html
