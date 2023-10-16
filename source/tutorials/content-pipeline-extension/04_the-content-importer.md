# The `ContentImporter`
The job of the `ContentImporter` is to read the contents of the file being imported from disk and pass that data to the `ContentProcessor` where it can be processed.  You will, when able, want to perform some type of validation on the data that is imported to ensure it is the correct type of data expected so that there are no issues during the processing stage.  

> [!NOTE]
> This can sometimes be tricky to balance when validation of the data also means processing the data.  Just keep in mind there is no right or wrong way to do it, whether you place that validation in the importer or during the processing stage.
>
> The goal of doing validation in the import stage is so that if an exception needs to be thrown, it's clear to the end user that it occurred during and due to the import stage.

## The Anatomy of a `ContentImporter`
Let's take a look at the anatomy of a `ContentImporter` by taking a look at the `JsonContentImporter` class.  If you open this file, you will see the following:

```cs
using Microsoft.Xna.Framework.Content.Pipeline;

using TImport = System.String;

namespace JsonContentPipelineExtension
{
    [ContentImporter(".txt", DisplayName = "Importer1", DefaultProcessor = "Processor1")]
    public class JsonContentImporter : ContentImporter<TImport>
    {
        public override TImport Import(string filename, ContentImporterContext context)
        {
            return default(TImport);
        }
    }
}
```

So let's break this down into specific parts, discuss what they are, and why they matter.

### Using Alias
The first part we'll look at is the **using alias**

```cs
using TImport = System.String;
```

This is not something that is MonoGame specific, but rather a C# language feature. The short explanation is that we are creating an alias here for `System.STring` called `TImport`.  This means anywhere in **this** code file that we use the keyword `TImport` it is the same thing as if we said `System.String`. 

If you're not familiar with the **using alias** concept in C#, you can read more about it on the [using directive - C# Reference | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive#using-alias) official page.

### The `ContentImporterAttribute`
The next part we'll look at is the `ContentImporterAttribute` that decorates the class declaration.

```cs
[ContentImporter(".txt", DisplayName = "Importer1", DefaultProcessor = "Processor1")]
```

This attribute **must** be added to the class that will serve as our content importer.  The first parameter in the attribute, `.txt`, defines the file extension that our `ContentImporter` will be associated with.  The `DisplayName` property allows us to set the display name shown for the importer inside the **MGCB Editor**.  Finally the `DefaultProcessor` property allows us to set which `ContentProcessor` will be selected as the default processor in the **MGCB Editor** for the content being imported.

We'll change the values in a moment, for now we're just discussing what they do.

### The `ContentImporter` Declaration
Next, let's take a look at the declaration of the class itself

```cs
public class JsonContentImporter : ContentImporter<TImport>
```

From this we can see that we are inheriting from `ContentImporter<T>`.  This base class comes from the `Microsoft.Xna.Framework.Content.Pipeline` namespace.  It also requires a generic `T` type which specifies the type expected to be returned back from our importer once it finishes importing.

In our specific case we have specified this type to be `TInput`, which is the alias for `System.String`.  This means our importer is expected to return back a string value.

### The `Import(string, ContentImporterContext)` Method
Inside the class, we are provided with a single method that is overriding from the base class.  This is the `Import(string, ContentImporterContext)` method

```cs
public override TImport Import(string filename, ContentImporterContext context)
```

This method is where we'll do the actual importing of the contents for the file.  This method must also return the `<T>` type defined in the inheritance, which in our case is `TInput`, the alias for `System.String`.  So we must return a string value for this importer.

> [!TIP]
> Sometimes you may want to return more than just a simple string value of the content read.  For instance, maybe you want to import not just the file content, but also meta data about the file such as the file name, creation date, etc.
>
> In these situations, you can create a simple model class that holds all the information you need and use that as the return type for the `ContentImporter`.

This method also contains the `ContentImporterContext` parameter.  This parameter provides additional context for the importer which allows us to do things like adding additional files as dependencies when importing.  This is not something we'll be needing in this tutorial, but I can cover the concepts of doing this in a future one.

## Next Steps
On the next page, we'll edit the `JsonContentImporter` so that it performs all the logic necessary to import the contents of a JSON file.


