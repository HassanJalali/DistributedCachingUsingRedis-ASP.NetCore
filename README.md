* Distributed Caching in ASP.NET Core

Distributed caching is a mechanism in which we maintain the cache as an external service that multiple app servers can use. This is different from In-Memory Caching where we cache the data in the app server’s memory.

Distributed caching can greatly improve the performance and scalability of an app and is a great choice when we host our application on multiple servers or in the cloud.

Here a day ASP.NET Core supports different types of distributed cache implementations and it is very easy to change the implementation later by just changing the configuration. Regardless of the implementation that we choose, for working with the distributed cache, we always use the IDistributedCache interface.

* IDistributedCache interface

This interface has methods, which allow us to add, remove, and retrieve the distributed cache. This interface contains synchronous and asynchronous methods. 

1.	Get, GetAsync - Gets the Value from the Cache Server based on the passed key, it returns byte [], if the key is not found in to cache.
2.	Set, SetAsync - Accepts a key and Value and sets it to the Cache server.
3.	Refresh, RefreshAsync - It refreshes the item in the cache and also resets its sliding expiration timeout, if any.
4.	Remove, RemoveAsync - Deletes the cache data based on the key.

* Different Distributed Caching Services in ASP.NET Core

Now let’s have a look at the different distributed caching services that ASP.NET Core supports:

1: Distributed Memory Cache

2: SQL Server Cache

3: Redis Cache (Remote Dictionary Server)

4: NCache Cache
