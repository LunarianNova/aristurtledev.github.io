---
modificationDate: "10/16/2023"
---

# The `ContentWriter`
The job of the `ContentWriter` is to take the input from the `ContentProcessor` and write it to disk as a binary encoded`.xnb` file.

## The Anatomy of a `ContentWriter`
When we created the **MonoGame Content Extension Project** it did not give us an out-of-box class for the `ContentWriter`. So for now so we can discuss it, please create a new class file in the project named `JsonContentTypeWriter` and replace the content inside it with the follow code:

```cs
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using TInput = System.String;

namespace JsonContentPipelineExtension
{
    [ContentTypeWriter]
    internal class JsonContentTypeWriter : ContentTypeWriter<TInput>
    {
        protected override void Write(ContentWriter output, TInput value)
        {
            
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return default(string);
        }
    }
}
```

This is the basic foundation of a `ContentWriter`.  So let's break it down into specific parts, discuss what they are, and why they matter.

### Using Aliases
At this point, seeing the **using aliases** should be familiar. 

```cs
using TInput = System.String;
```

For the `ContentWriter` we create on called `TInput` which is set as the type expected to be given to the `ContentWriter` as input to write.  This should match the type that is returned from the `ContentProcessor`.

### The `ContentTypeWriterAttribute`
The next pat is the `ContentTypeWriterAttribute` tha decorates the class declaration.

```cs
[ContentTypeWriter]
```

Unlike it's counterparts in the `ContentImporter` and `ContentProcessor`, there are no parameters or properties to configure for this attribute.  It is only required that the class be decorated with this attribute.

### The `ContentTypeWriter` Declaration
Next is the declaration of the class itself

```cs
internal class JsonContentTypeWriter : ContentTypeWriter<TInput>
```

From this we can see that we are inheriting from the `ContentTypeWRiter<T>` class.  This base class comes from the `Microsoft.Xna.Framework.Content.Pipeline` namespace.  It requires one generic `T` type that specifies the type that this writer expects as input that was returned from the processor.

In our specific case we have specified tha the type is `TInput`, which is the alias for `System.String`.  This means our writer expects a string value as input.

### The `Write(ContentWriter, TInput)` Method
This method is where all of the writing to the `.xnb` file happens.  The first parameter given is a `ContentWriter` instance, which is a derived class from the standard `BinaryWriter`.  So it provides you with the typical `BinaryWriter` methods to write common value types like `int`, `float`, `double`, `bool`, `string`, etc, but you will also have some common MonoGame specific types that can be written as well like `Color` and `Vector2`.  

The second parameter is the `TInput` parameter which is the input passed to the writer from the processor.  We use the values of this input with the `ContentWriter` to write them to the `.xnb` file

> [!NOTE]
> When writing the content to the `.xnb` file, it is important to note the order in which the content is written.  This is because later when reading the `.xnb` file with the `ContentTypeReader`, the read must read the data from the file in the same order that it was written too.


> [!NOTE]
> The instance of the `ContentWriter` that is given as a parameter here is created internally within the framework.  When it is created, it writes an initial header to the `.xnb` file that is being created that includes a signature to validate it as an `.xnb` file as well as meta data that specifies the `ContentTypeReader` to use when loading the `.xnb` file at runtime.  
>
> Due to this small header information that is written, sometimes the `.xnb` file you create may be sightly larger than the original input file.

### The `GetRuntimeReader(TargetPlatform)` Method.
This method is probably the one method that will cause you the most grief.  The reason being is because the return value from this method has to be exactly correct.  If this is not correct, then your content will build fine, but will not load at runtime.

Recall that I mentioned in the note above that the `ContentWriter` writes a small header ot the `.xnb` file, and that part of that header is the `ContentTypeReader` to use when loading the `.xnb` file at runtime?  Well, this method is where it gets that information from.  

The return value for this needs to be the **fully-qualified type path** of the `ContentTypeReader` that will be used to read the content.  A **fully-qualified type path** is a string formatted at `[Type Path], [Assembly Name]`.

For instance, if we have our `ContentTypeReader` in another class library who's assembly is named `ContentPipelineThings`, and within this assembly, the actual `ContentTypeReader` path, including namespaces, is `ContentPipelineThings.ContentReaders.MyContentReader`, then the **fully-qualified type path** would be `ContentPipelineThings.ContentReaders.MyContentReader, ContentPipelineThings`.

## Next Steps
On the next page, we'll edit the `JsonContentTypeWriter` class that we just created so that it performs all the logic necessary to write the results from the `JsonContentParser` to an `.xnb` file.