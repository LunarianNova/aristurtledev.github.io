---
modificationDate: "10/16/2023"
---

# Edit The `JsonContentTypeReader`
On the previous page we discussed the anatomy of a `ContentTypeReader`.  Now that we have an understanding of this, let's make the changes necessary to our `JsonContentTypeReader` class so that it reads the `.xnb` file.and returns back the expected result.

Open the `JsonContentTypeReader.cs` file and make the following adjustments:

[!code-csharp[](JsonContentTypeReader.cs?highlight=2,10-12)]

For the purposes of the example being used in this tutorial, there was not much we needed to adjust here. We simply just needed the `Read(ContentReader, T)` method to to read the JSON string from the `.xnb` file and then serialize it to the `T` type object and return it.

## Next Steps
That's all for our `JsonContentTypeReader`.  It simply just reads the JSON string from the `.xnb` file and serializes it, then returns the object type.

Now that we have all of this setup, the next step is going to be creating a game project that we can use to test all of this and make sure it's working correctly. 