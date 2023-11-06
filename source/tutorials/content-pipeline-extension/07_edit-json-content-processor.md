---
modificationDate: "10/16/2023"
_title: Edit the JsonContentProcessor | MonoGame Content Pipeline Extension Tutorial Series
_slug: tutorials/content-pipeline-extension/07_edit-json-content-processor
_description: Updating our JsonContentProcessor to process the results of the import.
---

# Edit the `JsonContentProcessor`
On the previous page we discussed the anatomy of a `ContentProcessor`.  Now that we have an understanding of this, let's make the changes necessary to our `JsonContentProcessor` class so that it imports the contents of a JSON file.

Open the `JsonContentProcessor.cs` file and make the following adjustments:

[!code-csharp[](JsonContentProcessor.cs?highlight=2-7,9,13,16-20,24-38,41-62)]

There are quite a few changes made here so let's go over what we're doing.
1. First, `using` statements were added to support different classes that we'll need for working with JSON and doing encoding.
2. Next, the `TOutput` **using alias** were changed to be our `JsonContentProcessorResult` class.
3. The `DisplayName` property in the `ContentProcessorAttribute` was changed to `JSON Processor - Aristurtle`.  This gives it a more descriptive name when displayed in the **MGCB Editor**.  It is common practice to include either your name or the name of your library at the end of the display name as I have done here with `- Aristurtle`.  You can change this to your name if you'd like.
4. The `public bool Minify` property was added.  This property defaults to true and will flag if the JSON content should be minified before it is sent to the `ContentWriter`.  The `DisplayNameAttribute` as also added to the property so we can give it a descriptive name when it's displayed in the **MGCB Editor**.
6. The `public string RuntimeType` property was added.  This property defaults to an empty string which we can use to validate that the user sets a value for this in the **MGCB Editor** making it a required property.  This will be used later in our `JsonContentTypeWriter` to identify the runtime reader used to read the content file.
5. The logic of the `Process(TInput, COntentProcessorContext)` method was adjusted to perform the processing of our content.  First we check if the user supplied a value for the `RuntimeType` property.  If not, we throw an exception since it's a required value.  Next, we check if minifying the JSON was enabled, and if so we call the `MinifyJson` method to perform this.  Finally, we return the JSON string that was input whether it was minified or not.
6. The `MinifyJson(string)` method was added to provide the logic of minifying the JSON string if needed.
7. Finally we create an instance of the `JsonContentProcessorResult` and set the appropriate property values and return it.

## Next Steps
That's it for our JSON processor.  Remember, the job of the `ContentProcessor` is to process the content of the file assets given to it by the `ContentImporter` and prepare it to be written to disk for the `ContentWriter`

On the next page, we'll go over the anatomy of a `ContentWriter` class.

