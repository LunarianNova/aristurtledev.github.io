---
modificationDate: "10/16/2023"
_title: Edit the JsonContentImporter | MonoGame Content Pipeline Extension Tutorial Series
_slug: tutorials/content-pipeline-extension/05_edit-json-content-importer
_description: Updating our JsonContentImporter to import the contents of a JSON file.
---

# Edit the `JsonContentImporter`
On the previous page we discussed the anatomy of a `ContentImporter`.  Now that we have an understanding of this, let's make the changes necessary to our `JsonContentImporter` class so that it imports the contents of a JSON file.

Open the `JsonContentImporter.cs` file and make the following adjustments:

[!code-csharp[](JsonContentImporter.cs?highlight=2-4,9,14-17,20-37)]

These changes are pretty minimal but let's discuss what we're doing here.

1. Additional `using` statements were added that we'll need for reading the file content.
2. The `ContentImporterAttribute` was updated
    - The `fileExtension` parameter was changed from `.txt` to `.json` since we will be importing JSON files specifically
    - The `DisplayName` property was changed to `JSON Importer - Aristurtle`.  This gives it a more descriptive name when displayed in the **MGCB Editor**.  It is common practice to include either your name or the name of your library at the end of the display name as I have done here with `- Aristurtle`.  You can change this to your name if you'd like.
    - The `DefaultProcessor` was changed to be our `JsonContentProcessor` class.  Here, in this example, I am making use of the `nameof` keyword in C#, however you could hae just typed it as a string `"JsonContentProcessor"` if you had wanted.  The only thing that matters is that the name used for the `DefaultProcessor` is a string and is the correct casing and spelling of the class.
3. The logic of the `Import(string, ContentImporterContext)` method was updated to read all of the text from the JSON file into the `json` variable, validate that it is actually JSON, then return it.  The validation is done inside the `ThrowIfInvalidJson(string)` method that was added.

## Next Steps
That's it for our JSON importer.  Remember, the job of the `ContentImporter` is to import the content of the file assets and perform any validation that the content imported is what is expected.

On the next page, we'll go over the anatomy of a `ContentProcessor` class.

