---
modificationDate: "10/16/2023"
_title: Edit the JsonContentTypeWriter | MonoGame Content Pipeline Extension Tutorial Series
_description: Updating our JsonContentTypeWriter to write the results of the processor.
---

# Edit The `JsonContentTypeWriter`
On the previous page we discussed the anatomy of a `ContentTypeWriter`.  Now that we have an understanding of this, let's make the changes necessary to our `JsonContentTypeWriter` class so that it writes the results to an `.xnb` file.

Open the `JsonContentTypeWriter.cs` file and make the following adjustments:

[!code-csharp[](JsonContentTypeWriter.cs?highlight=4,13,18)]

For the purposes of the example being used in this tutorial, there was not much we needed to adjust here.

1. The `TInput` **using alias** was changed to our `JsonContentResult` type.
2. We updated the logic of the `Write(ContentWriter, TInput)` method to write out JSON string to the `.xnb` file.

Note, however, the value that we are returning for the `GetRuntimeReader(TargetPlatform)` method.  The **fully-qualified type path** uses an assembly name that is different than our `JsonContentPipelineExtension` assembly.  This is because we're going to place the reader in a separate project, which will be explained in the upcoming sections.

## Next Steps
That is it for our JSON writer.  It simply just takes in the data given from the `JsonContentProcessor` and writes the single JSON string to the `.xnb` file.

On the next page, we'll go over creating a new **MonoGame Game Library** project that we'll put our `JsonContentTypeReader` into and go over the reasons why we do this.
